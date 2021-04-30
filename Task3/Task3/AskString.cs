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
    public partial class AskString : Form
    {
        public string Result { get; set; }
        public AskString(string argName)
        {
            InitializeComponent();
            label1.Text = argName + ":";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = textBox1.Text;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
