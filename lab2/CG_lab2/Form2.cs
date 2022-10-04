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
            
            //pictureBox1.MouseMove += pictureBox1_MouseMove;
        }

        int OldX=0, oldY=0;
         private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButPen.Checked)
            {
                OldX = e.X;
                oldY = e.Y;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
//
            if ( radioButPen.Checked &&
                e.Button == MouseButtons.Left)
            {
               
                Pen p = new Pen(colorDialog1.Color,2);
                //g.DrawEllipse(p, e.X, e.Y, 3, 3);
                g.DrawLine(p, OldX, oldY, e.X, e.Y);
                //pen.Dispose();
                g = Graphics.FromImage(pictureBox1.Image);
                pictureBox1.Invalidate();
                OldX = e.X;
                oldY = e.Y;
            }
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
            //pictureBox1.MouseMove -= pictureBox1_MouseMove;
            

        }
        //bool backetPaint = false;
        Color bucketColor;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        { 
            Bitmap holst = new Bitmap(pictureBox1.Image);
            if (radioButBuc.Checked )//|| backetPaint
            {
               // backetPaint = true;
                bucketColor = colorDialog1.Color;
                Pen p = new Pen(bucketColor);
                ReDrawUp(e.Location,p, holst);
                pictureBox1.Invalidate();
                ReDrawDown(e.Location, p, holst);
                pictureBox1.Invalidate();
            }

        }
        private void ReDrawUp(Point start, Pen p, Bitmap holst)
        {
            Point left = start, right = start;
            Color startColor = holst.GetPixel(start.X, start.Y);
            while ( left.X>2 && holst.GetPixel(left.X-1, left.Y)== startColor)
            {
                --left.X;
            }
            while ( right.X<holst.Width-2 && holst.GetPixel(right.X + 1, right.Y) == startColor)
            {
                ++right.X;
            }
            g.DrawLine(p,left,right);
            Point up = left;
            if (up.Y + 1 < holst.Height - 1)
                ++up.Y;
            else return;
            for (int i = left.X; i < right.X; i++)
            {
                if (holst.GetPixel(i, up.Y) == startColor )
                {
                    up.X = i;
                    ReDrawUp(up, p, holst);
                    break;
                }
            }
        }
        private void ReDrawDown(Point start, Pen p, Bitmap holst)
        {
            Point left = start, right = start;
            Color startColor = holst.GetPixel(start.X, start.Y);
            while (left.X > 2 && holst.GetPixel(left.X - 1, left.Y) == startColor)
            {
                left.X--;
            }
            while (right.X < holst.Width - 2 && holst.GetPixel(right.X + 1, right.Y) == startColor)
            {
                right.X++;
            }
            g.DrawLine(p, left, right);
            Point down = left;
            if (down.Y - 1 > 1)
                --down.Y;
            else return;
            for (int i = left.X; i < right.X; i++)
            {
                if (holst.GetPixel(i, down.Y) == startColor)
                {
                    down.X = i;
                    ReDrawDown(down, p, holst);
                    break;
                }

            }
        }
        /*     private void ReDraw(Point start,Pen p, Bitmap holst)
         {   
             if (start.X <= 0 || start.Y<=0 
                 || start.X>=holst.Width || start.Y>=holst.Height) return;
             Color now = holst.GetPixel(start.X, start.Y);
             Point left = start, right = start;
             if (left.X>1)
                 left.X--;
             if (right.X < holst.Width-1)
                 right.X++;
             Color previous = holst.GetPixel(left.X, left.Y);
             while (left.X > 1 && previous == now )
             {
                 // if (holst.GetPixel(left.X, left.Y)!=bucketColor)\

                 left.X--;
                 previous = holst.GetPixel(left.X-1, left.Y);
             }
             Color leftCol = holst.GetPixel(left.X, left.Y);
             Color next = holst.GetPixel(right.X, right.Y);
             while (right.X < pictureBox1.Width-1 && next == now)
             {
                 // if (holst.GetPixel(left.X, left.Y)!=bucketColor)

                 right.X++;
                 next = holst.GetPixel(right.X, right.Y);
             }
             g.DrawLine(p, left, right);
             pictureBox1.Invalidate();
             Point up = left, down = left;
             up.Y++;
             down.Y--;
             //bool u = true,d = true;
             //ReDraw(up, p);
             for (int i = ++left.X; i <= --right.X; i++)
             {
                 if ( holst.GetPixel(up.X, up.Y) == now && up.Y < holst.Height-1)
                 { 
                     ReDraw(up, p,holst);
                     up.Y++;
                     break;
                 }
             }
             for (int i = ++left.X; i <= --right.X; i++)
             {
                 if ( holst.GetPixel(down.X, down.Y) == now && down.Y > 1)
                 {
                     ReDraw(down, p, holst);
                     down.Y--;
                     break;
                 }
             }
         }*/
        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColor.BackColor = colorDialog1.Color;
        }

      
    }
}
