using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public string TPath { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = GetFileName();
            if(path != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(File.ReadAllLines(path));
                TPath = path;
            }
            
        }
        private string GetFileName()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = GetFileName();
            if (path != null)
            {
                listBox2.Items.Clear();
                listBox2.Items.AddRange(File.ReadAllLines(path));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] lines = new string[listBox1.Items.Count];
            for(int i = 0; i < lines.Length;i++)
            {
                if(listBox2.Items.Count > i)
                {
                    lines[i] = $"{listBox2.Items[i]}|{listBox1.Items[i]}|{listBox2.Items[i]}";
                }
                else
                {
                    lines[i] = listBox1.Items[i].ToString();
                }
                
            }
            File.WriteAllLines(TPath, lines);
            string filename = TPath.Split('\\').Last();
            MessageBox.Show("Результат сохранен в файл: "+ filename);
        }
    }
}
