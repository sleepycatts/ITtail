using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Assembly Module { get; set; } 
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                Module = Assembly.LoadFrom(dlg.FileName);
                comboBox1.DataSource = Module.GetTypes();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = ((Type)comboBox1.SelectedItem).GetMethods();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MethodInfo method = (MethodInfo)comboBox2.SelectedItem;
            var pars = method.GetParameters();
            object[] args = new object[pars.Length];
            for(int i = 0; i < args.Length; i++)
            {
                switch (pars[i].ParameterType.Name)
                {
                    case "Point":
                        var frm = new AskPoint(pars[i].Name);
                        frm.ShowDialog();
                        object point = Activator.CreateInstance(pars[i].ParameterType,frm.X,frm.Y);
                        args[i] = point;
                        break;
                    case "Double":
                        var frmDouble = new AskDouble(pars[i].Name);
                        frmDouble.ShowDialog();
                        args[i] = frmDouble.Result;
                        break;
                    case "String":
                        var frmString = new AskString(pars[i].Name);
                        frmString.ShowDialog();
                        args[i] = frmString.Result;
                        break;
                }
            }

            var type = (Type)comboBox1.SelectedItem;
            object instance = Activator.CreateInstance(type);
            var iCircle = type.GetInterfaces().Where(it => it.Name == "ICircle").FirstOrDefault();
            if (iCircle != null)
            {
                var frmDouble = new AskDouble("Radius");
                frmDouble.ShowDialog();
                
                var frmPoint = new AskPoint("Center");
                frmPoint.ShowDialog();
                type.GetMethod("SetRadius").Invoke(instance, new object[] { frmDouble.Result });
                type.GetMethod("SetCenter").Invoke(instance, new object[] { Activator.CreateInstance(Module.GetTypes().Where(t=>t.Name == "Point").FirstOrDefault(), frmPoint.X, frmPoint.Y)  });
            }
            MessageBox.Show(method.Invoke(instance, args)?.ToString());

        }
    }
}
