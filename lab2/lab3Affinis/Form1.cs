﻿using System;
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
        //for affine point
        bool AffineClick = false;
        Point AffinePoint;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            PaintEventArgs ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
        }
        List<Point> points = new List<Point>(); // лист вершин полигона
        List<Point> intersect = new List<Point>();
        Point[] p;
        Point center;

        int[,] shift = new int[3, 3] {
        {1,0,0 },
        {0,1,0 },
        {0,0,1 }
        };
        int[,] rotate = new int[3, 3] {
        {0,  1, 0 },
        {-1, 0, 0 },
        {0,  0, 1 }
        };
        //===============================================================================
        private void Draw()
        {
            ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
            if (p.Length > 1)
                ev.Graphics.DrawPolygon(Pens.Red, p);
            else if (p.Length == 1)
                (pictureBox1.Image as Bitmap).SetPixel(p[0].X, p[0].Y, Pens.Red.Color);
            pictureBox1.Invalidate();
        }
        private Point MultMatrix(Point p,int[,] m)
        {
            int[] pp = new int[3] { p.X, p.Y ,1};
            int[] result = new int[3] {0,0,0};
            for (int i = 0; i < 3; i++)//i < 2
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i] += pp[j] * m[i, j];
                }
            }
            return new Point(result[0],result[1]);
        }
        private void Change(int[,] mat)
        {
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = MultMatrix(p[i], mat);// перемножаем матрицу на точку и получаем новое положение точки
            }
        }
        private void Shift(int dx, int dy)
        {
            shift[0, 2] = dx;
            shift[1, 2] = dy;
            Change(shift);
        }
        private void Rotate(Point A,double angl)
        {
            int sin = (int)Math.Round(Math.Sin(angl));
            int cos = (int)Math.Round(Math.Cos(angl));
            rotate[0, 0] = cos;
            rotate[0, 1] = -sin;
            rotate[1, 0] = sin;
            rotate[1, 1] = cos;
            Shift(-A.X, -A.Y);
            Change(rotate);
            Shift(A.X, A.Y);
            Draw();
        }
        //==================================================================================================
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (AffineClick)
            {
                AffineClick = false;
                AffinePoint = e.Location;
                button5.Text = String.Format("Set Affine Point\nCurrent: {0};{1}", e.Location.X.ToString(), e.Location.Y.ToString());
            }
            else
            {
                if (radioButtonIntersect.Checked)
                {
                    intersect.Add(e.Location);

                    if (intersect.Count < 4)
                    {
                        if (intersect.Count == 2)
                        {
                            g.DrawLine(pen, intersect[0], intersect[1]);
                            pictureBox1.Invalidate();
                        }

                    }
                    if (intersect.Count == 4)//!!!!!!!!!!!!!!!!!  Пересечение 
                    {
                        g.DrawLine(pen, intersect[2], intersect[3]);
                        pictureBox1.Invalidate();
                        int t = 0;// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  Слайд 37  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        int nx = 0, ny = 0;
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

                }
                else points.Add(e.Location);
                var bmp = (pictureBox1.Image as Bitmap);
                bmp.SetPixel(e.X, e.Y, color);
                g.DrawEllipse(pen, e.X - 1, e.Y - 1, 2, 2);

                pictureBox1.Invalidate();
            }
        }
        private int T(int a,int b,int c, int d, int n)
        {
            int z = n * (b - a);
            if (z != 0)
                return n * (a - c) / z;
            return 0;
        }
        // Задать примитив
        private void button1_Click(object sender, EventArgs e) 
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
        //=================Button: Up, Down, Left, Right, Shift ===========================================================
        private void buttonUp_Click(object sender, EventArgs e)
        {
            int y = textBox2.Text != "" ? int.Parse(textBox2.Text) : 0;
            Shift(0, -y);
            Draw();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int y = textBox2.Text != "" ? int.Parse(textBox2.Text) : 0;
            Shift(0, y);
            Draw();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            int x = textBox1.Text != "" ? int.Parse(textBox1.Text) : 0;
            Shift(-x, 0);
            Draw();
        }
       
        private void buttonRight_Click(object sender, EventArgs e)
        {
            int x = textBox1.Text != "" ? int.Parse(textBox1.Text) : 0;
            Shift(x, 0);
            Draw();
        }
        private void buttonShift_Click(object sender, EventArgs e)
        {
            Shift(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            Draw();
        }
        // _______________________ Button: Up, Down, Left, Right, Shift __________________________________________

        // Масштабирование - увеличение
        private void button6_Click(object sender, EventArgs e)//!!!!!!!!!!!!!!!! buttonScaleUp !!!!!!!!!!!!!!!!
        {
            /*using (Matrix m = new Matrix())
            {
                ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
                m.Reset();
                m.Scale(2f, 2f);
                m.TransformPoints(p);
                ev.Graphics.DrawPolygon(pen, p); 
            }*/
            pictureBox1.Invalidate();
        }
        // Масштабирование - уменьшение
        private void button2_Click(object sender, EventArgs e)//!!!!!!!!!!!!!!!! buttonScaleDown !!!!!!!!!!!!!!!!
        {
            /*using (Matrix m = new Matrix())
            {
                ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
                m.Reset();
                m.Scale(0.5f, 0.5f);
                m.TransformPoints(p);
                ev.Graphics.DrawPolygon(pen, p);
            }*/
            pictureBox1.Invalidate();
        }

        // поворот на 90 градусов
        private void buttonRotate_Click(object sender, EventArgs e)// buttonRotate
        {
            Rotate(p[0],Math.PI/2);// Центр !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1 
            Draw();
        }

        private void button3_Click(object sender, EventArgs e) // пересечение
        {
            radioButtonIntersect.Checked = radioButtonIntersect.Checked ? false : true;
        }

        //Clear
        private void button4_Click(object sender, EventArgs e) 
        {
            g.Clear(pictureBox1.BackColor);
            points.Clear();
            pictureBox1.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AffineClick = true;
        }
    }
}