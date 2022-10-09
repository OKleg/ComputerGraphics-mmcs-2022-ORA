using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3Affinis
{
    public partial class Form1 : Form
    {
        Graphics g;
        Color color ;
        Pen pen;
        PaintEventArgs ev;
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            PaintEventArgs ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
        }
        List<Point> points = new List<Point>();
        List<Point> intersect = new List<Point>();
        Point[] p;
        Point center;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButtonIntersect.Checked)
            {
                intersect.Add(e.Location);
                
                if (intersect.Count < 4)
                {
                    if (intersect.Count == 2)
                    {
                        g.DrawLine(pen,intersect[0], intersect[1]);
                        pictureBox1.Invalidate();
                    }
                    
                }
                if (intersect.Count == 4)//!!!!!!!!!!!!!!!!!
                {
                    g.DrawLine(pen, intersect[2], intersect[3]);
                    pictureBox1.Invalidate();
                    int t = 0;// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  Слайд 37  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    int nx=0, ny=0;
                    t = T(intersect[0].X, intersect[1].X, intersect[2].X, intersect[3].X, nx);
                    int Pt1x = intersect[0].X + t * (intersect[1].X - intersect[0].X);
                    int Pt1y = intersect[0].Y + t * (intersect[1].Y - intersect[0].Y);
                    int Pt2x = intersect[2].X + t * (intersect[3].X - intersect[2].X);
                    int Pt2y = intersect[2].Y + t * (intersect[3].Y - intersect[2].Y);
                    
                    if (Pt1x == Pt2x && Pt1y == Pt2y)
                    {
                        g.DrawLine(Pens.Orange, intersect[0].X, intersect[0].Y, Pt1x, Pt1y);
                        g.DrawLine(Pens.Orange, intersect[2].X, intersect[2].Y, Pt1x, Pt1y);
                        g.DrawEllipse(Pens.Orange, Pt1x - 1, Pt1y - 1, 3, 3);
                    }
                    intersect.Clear();
                   // points.Clear();
                }

            }else points.Add(e.Location);
                var bmp = (pictureBox1.Image as Bitmap);
                bmp.SetPixel(e.X, e.Y, color);
                g.DrawEllipse(pen, e.X - 1, e.Y - 1, 2, 2);
                
                pictureBox1.Invalidate();
            
        }
        private int T(int a,int b,int c, int d, int n)
        {
            int z = n * (b - a);
            if (z != 0)
                return n * (a - c) / z;
            return 0;
        }
        private void button1_Click(object sender, EventArgs e) // Задать примитив
        {
           // g.Clear(Color.White);
            var bmp = (pictureBox1.Image as Bitmap);
            p = new Point[points.Count];
            if (points.Count >1)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    //g.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                    p[i] = points[i];
                }
                //g.DrawLine(pen, points.ElementAt(points.Count-1), points.ElementAt(0));

                //PaintEventArgs ev =  new PaintEventArgs(g,pictureBox1.ClientRectangle);
                ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
                ev.Graphics.DrawPolygon(pen, p);
            }
            g = Graphics.FromImage(pictureBox1.Image);
            pictureBox1.Invalidate();
            //center =                        !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            points.Clear();
        }

        private void Shift(int x, int y)
        {
            using (Matrix m = new Matrix())
            {
                ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
                x = textBox1.Text != "" ? int.Parse(textBox1.Text) : 0;
                y = textBox2.Text != "" ? int.Parse(textBox2.Text) : 0;
                m.Reset();
                m.Translate(x, 0);
                m.TransformPoints(p);
                ev.Graphics.DrawPolygon(pen, p);
                pictureBox1.Invalidate();
            }
        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            int y = textBox2.Text != "" ? int.Parse(textBox2.Text) : 0;
            Shift(0, y);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int y = textBox2.Text != "" ? int.Parse(textBox2.Text) : 0;
            Shift(0, y);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            
             int x = textBox1.Text != "" ? int.Parse(textBox1.Text) : 0;
             Shift(x, 0);
            
        }
       
        private void buttonRight_Click(object sender, EventArgs e)
        {
                int x = textBox1.Text != "" ? int.Parse(textBox1.Text) : 0;
                Shift(x, 0);
            }

        private void button6_Click(object sender, EventArgs e)//!!!!!!!!!!!!!!!! buttonScaleUp !!!!!!!!!!!!!!!!
        {
            using (Matrix m = new Matrix())
            {
                ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
                m.Reset();
                m.Scale(2f, 2f);
                m.TransformPoints(p);
                ev.Graphics.DrawPolygon(pen, p); 
                pictureBox1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)//!!!!!!!!!!!!!!!! buttonScaleDown !!!!!!!!!!!!!!!!
        {
            using (Matrix m = new Matrix())
            {
                ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
                m.Reset();
                m.Scale(0.5f, 0.5f);
                m.TransformPoints(p);
                ev.Graphics.DrawPolygon(pen, p);
                pictureBox1.Invalidate();
            }
        }

        private void buttonRotate_Click(object sender, EventArgs e)// buttonRotate
        {
            using (Matrix m = new Matrix())
            {
                center = p[1];//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Need center
                m.RotateAt(90, center);
                m.TransformPoints(p);
             
                ev.Graphics.DrawPolygon(pen, p);
                pictureBox1.Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e) // пересечение
        {
            radioButtonIntersect.Checked = radioButtonIntersect.Checked ? false : true;
        }

        private void button4_Click(object sender, EventArgs e) //Clear
        {
            g.Clear(PictureBox.DefaultBackColor);
            points.Clear();
            pictureBox1.Invalidate();
        }
    }
}
