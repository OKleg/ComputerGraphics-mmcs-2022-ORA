using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_lab2
{
    public partial class Form2 : Form
    {
        public Form1 f1;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();

        }
        private void lab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();

        }
        private void Form2_FormClosed(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
