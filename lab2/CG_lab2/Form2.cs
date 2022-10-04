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
        private Graphics g;
        public Form2()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Paint += Draw;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            
        }
        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(colorDialog1.Color);
            g.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
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

        

        private void pen_Click(object sender, EventArgs e)
        {
            radioButPen.Checked = radioButPen.Checked ?  false : true;
        }
        int OldX=0, oldY=0;
         private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            OldX= e.X;
            oldY= e.Y;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (radioButPen.Checked && e.Button == MouseButtons.Left)
            {
               
                Pen p = new Pen(colorDialog1.Color);
                //g.DrawEllipse(p, e.X, e.Y, 3, 3);
                g.DrawLine(p, OldX, oldY, e.X, e.Y);
                //pen.Dispose();
                g = Graphics.FromImage(pictureBox1.Image);
                pictureBox1.Invalidate();
                OldX = e.X;
                oldY = e.Y;
            }
        }
       





        private void pen_Enter(object sender, EventArgs e)
        {

        }

        private void pen_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButBuc.Checked = radioButBuc.Checked ? false : true;
        }


        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColor.BackColor = colorDialog1.Color;
        }

      
    }
}
