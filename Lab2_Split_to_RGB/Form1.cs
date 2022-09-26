using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Split_to_RGB
{
    public partial class Form1 : Form
    {
        Image SelectedImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SelectedImage = Image.FromFile(dlg.FileName);
                }

            }
            pictureBox1.Image = SelectedImage;
        }
    }
}
