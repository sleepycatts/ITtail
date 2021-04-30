using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class AskPoint : Form
    {
        public double X { get; set; }
        public double Y { get; set; }
        public AskPoint(string argName)
        {
            InitializeComponent();
            label1.Text = argName + ":";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                X = double.Parse(textBox1.Text);
                Y = double.Parse(textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
    }
}
