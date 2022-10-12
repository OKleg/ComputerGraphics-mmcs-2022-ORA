using System;
using System.Collections;
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
        bool SelectingPoint = false;
        Point AffinePoint;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            PaintEventArgs ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
            BtnSetCenter.Enabled = false;
            trackBar1.Value = 90;
            buttonRotate.Text = String.Format("Rotate on {0}°", trackBar1.Value.ToString());
            button2.Enabled = false;
        }
        List<Point> points = new List<Point>(); // лист вершин полигона
        List<Point> intersect = new List<Point>();
        Point[] p;
        Point center;

        double[,] shift = new double[3, 3] {
        {1,0,0 },
        {0,1,0 },
        {0,0,1 }
        };
        double [,] rotate = new double[3, 3] {
        {0,  1, 0 },
        {-1, 0, 0 },
        {0,  0, 1 }
        };
        AffineMatrix AffineMatr = new AffineMatrix();

        //===============================================================================
        private void Draw()
        {
            ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
            if (p.Length > 1)
            {
                ev.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                ev.Graphics.DrawPolygon(Pens.Red, p);
            }
            else if (p.Length == 1)
                (pictureBox1.Image as Bitmap).SetPixel(p[0].X, p[0].Y, Pens.Red.Color);
            pictureBox1.Invalidate();
        }
        private Point MultMatrix(Point p,double[,] m)
        {
            double[] pp = new double[3] { p.X, p.Y ,1};
            double[] result = new double[3] {0,0,0};
            for (int i = 0; i < 3; i++)//i < 2
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i] += pp[j] * m[i, j];
                }
            }
            return new Point((int)Math.Round(result[0]),(int)Math.Round(result[1]));
        }
        private void Change(AffineMatrix mat)
        {
            for (int i = 0; i < p.Length; i++)
            {
                //p[i] = MultMatrix(p[i], mat);// перемножаем матрицу на точку и получаем новое положение точки
                AffineMatrix res = new AffineMatrix(p[i]) * mat;
                p[i] = new Point((int)Math.Round(res[0, 0]), (int)Math.Round(res[0, 1]));
            }
        }

        private string PointPos(Point[] edge, Point b)
        {
            Point O = edge[0];
            Point a = edge[1];
            int sign = (b.X - O.X) * (a.Y - O.Y) - (b.Y - O.Y) * (a.X - O.X);

            if (sign > 0)
                return "left";
            if (sign < 0)
                return "right";
            else return "error";
        }
        private void Shift(int dx, int dy)
        {
            AffineMatr.SetShift(dx, dy);
            Change(AffineMatr);
        }
        private void Rotate(Point A,double angle)
        {
            Shift(-A.X, -A.Y);
            Point c = RadioBtnAffine.Checked ? AffinePoint : center;
            AffineMatr.SetRotateAngle(angle,c);
            Change(AffineMatr);
            Shift(A.X, A.Y);
            Draw();
        }
        //==================================================================================================
        /*struct Vector
        {
            Point a;
            Point b;
            public Vector(Point A, Point B)
            {
                a = A;
                b = B;
            }
            public static Vector operator *(Vector ab1, Vector ab2)
            {
                Point newA = new Point(ab1.a.X*ab2.a.X, ab1.a.Y * ab2.a.Y);
                Point newB = new Point(ab1.b.X * ab2.b.X, ab1.b.Y * ab2.b.Y);
                return new Vector(newA, newB);
            }
            public static Vector operator /(Vector ab1, Vector ab2)
            {
                Point newA = new Point(ab1.a.X / ab2.a.X, ab1.a.Y / ab2.a.Y);
                Point newB = new Point(ab1.b.X / ab2.b.X, ab1.b.Y / ab2.b.Y);
                return new Vector(newA, newB);
            }
            public static Vector operator +(Vector ab1, Vector ab2)
            {
                Point newA = new Point(ab1.a.X + ab2.a.X, ab1.a.Y + ab2.a.Y);
                Point newB = new Point(ab1.b.X + ab2.b.X, ab1.b.Y + ab2.b.Y);
                return new Vector(newA, newB);
            }

        }*/
        static public Point Intersection(Point A, Point B, Point C, Point D)
        {
            int xo = A.X, yo = A.Y;
            int p = B.X - A.X, q = B.Y - A.Y;

            int x1 = C.X, y1 = C.Y;
            int p1 = D.X - C.X, q1 = D.Y - C.Y;
            if ((q * p1 - q1 * p)!= 0 && (p * q1 - p1 * q) != 0){
                int x = (xo * q * p1 - x1 * q1 * p - yo * p * p1 + y1 * p * p1) /
                (q * p1 - q1 * p);
                int y = (yo * p * q1 - y1 * p1 * q - xo * q * q1 + x1 * q * q1) /
                    (p * q1 - p1 * q);

            
            return new Point(x, y);
            }
            else return new Point(-1, -1);
        }
        bool DinamicPoint = false;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectingPoint)
            {
                SelectingPoint = false;
                AffinePoint = e.Location;
                SelectedPointLabel.Text = String.Format("Selected point:\n{0};{1}", e.Location.X.ToString(), e.Location.Y.ToString());                           
            }
            else if (RadioPointPos.Checked)
            {
                var output = PointPos(p, new Point(e.X, e.Y));
                MessageBox.Show(output);
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
                    if (intersect.Count == 3)
                        DinamicPoint = true;
                    if (intersect.Count == 4)//!!!!!!!!!!!!!!!!!  Пересечение 
                    {
                        DinamicPoint = false;
                        g.DrawLine(pen, intersect[2], intersect[3]);
                        pictureBox1.Invalidate();
                        int t = 0;// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  Слайд 37  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        int nx = 0, ny = 0;
                        t = T(intersect[0].X, intersect[1].X, intersect[2].X, intersect[3].X, nx);
                        for (int x = intersect[0].X; x < intersect[1].X; x++)
                        {

                        }
                        int Pt1x = intersect[0].X + t * (intersect[1].X - intersect[0].X);
                        int Pt1y = intersect[0].Y + t * (intersect[1].Y - intersect[0].Y);
                        int Pt2x = intersect[2].X + t * (intersect[3].X - intersect[2].X);
                        int Pt2y = intersect[2].Y + t * (intersect[3].Y - intersect[2].Y);

                        if (Pt1x == Pt2x && Pt1y == Pt2y)
                        {
                           // g.DrawLine(Pens.Orange, intersect[0].X, intersect[0].Y, Pt1x, Pt1y);
                           //g.DrawLine(Pens.Orange, intersect[2].X, intersect[2].Y, Pt1x, Pt1y);
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
                //if (p.Length == 2) button2.Enabled = true;
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
            RadioPointPos.Checked = false;
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
            if (p.Length !=0)
            {
                BtnSetCenter.Enabled = true;
            }
            if (p.Length == 2) button2.Enabled = true;
        }
        //=================Button: Up, Down, Left, Right, Shift ===========================================================
        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (p != null && p.Length > 0)
            {
                int y = textBox2.Text != "" ? int.Parse(textBox2.Text) : 0;
                AffineMatr.Shift(p, 0, -y);
                Draw();
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (p != null && p.Length > 0)
            {
                int y = textBox2.Text != "" ? int.Parse(textBox2.Text) : 0;
                AffineMatr.Shift(p, 0, y);
                Draw();
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (p != null && p.Length > 0)
            {
                int x = textBox1.Text != "" ? int.Parse(textBox1.Text) : 0;
                AffineMatr.Shift(p, -x, 0);
                Draw();
            }
        }
       
        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (p != null && p.Length > 0)
            {
                int x = textBox1.Text != "" ? int.Parse(textBox1.Text) : 0;
                AffineMatr.Shift(p, x, 0);
                Draw();
            }
        }
        private void buttonShift_Click(object sender, EventArgs e)
        {
            if (p != null && p.Length > 0 && textBox1.Text!="" && textBox2.Text!="")
            {
                AffineMatr.Shift(p, int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                Draw();
            }
        }
        // _______________________ Button: Up, Down, Left, Right, Shift __________________________________________

        // Масштабирование - увеличение
        private void button6_Click(object sender, EventArgs e)//!!!!!!!!!!!!!!!! buttonScaleUp !!!!!!!!!!!!!!!!
        {
            if (p != null && p.Length > 0)
            {
                Point c = RadioBtnAffine.Checked ? AffinePoint : center;
                AffineMatr.Scale(p,c, 2, 2);
                Draw();
            }
        }
        // Масштабирование - уменьшение
        private void button2_Click(object sender, EventArgs e)//!!!!!!!!!!!!!!!! buttonScaleDown !!!!!!!!!!!!!!!!
        {
            if (p != null && p.Length > 0)
            {
                Point c = RadioBtnAffine.Checked ? AffinePoint : center;
                AffineMatr.Scale(p,c, 1.0/2, 1.0/2);
                Draw();
            }
        }

        // поворот на 90 градусов
        private void buttonRotate_Click(object sender, EventArgs e)// buttonRotate
        {
            if (p != null && p.Length > 0)
            {
                var angle = Math.PI / 180 * trackBar1.Value;
                Point c = RadioBtnAffine.Checked ? AffinePoint : center;
                AffineMatr.Rotate(p, c, angle);
                Draw();
            }
        }

        private void button3_Click(object sender, EventArgs e) // пересечение
        {
            RadioPointPos.Checked = false;
            radioButtonIntersect.Checked = radioButtonIntersect.Checked ? false : true;
        }

        //Clear
        private void button4_Click(object sender, EventArgs e) 
        {
            g.Clear(pictureBox1.BackColor);
            points.Clear();           
            center = AffinePoint;
            BtnSetCenter.Text = "Set Centroid";
            BtnSetCenter.Enabled = false;
            RadioPointPos.Checked = false;
            button2.Enabled = false;
            pictureBox1.Invalidate();
            //RadioPointPos.Checked = RadioPointPos.Checked ? false : true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RadioBtnAffine.Checked = RadioBtnAffine.Checked ? false : true;
            SelectedPointLabel.Text = String.Format("Selected point:\n{0};{1}", AffinePoint.X.ToString(), AffinePoint.Y.ToString());
            SelectingPoint = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {        
            buttonRotate.Text = String.Format("rotate on {0}", trackBar1.Value);
        }

        private void BtnSetCenter_Click(object sender, EventArgs e)
        {          
            
            RadioBtnCenter.Checked = RadioBtnCenter.Checked ? false : true;
            center = FindCentroid();
        }
        private Point FindCentroid()
        {
            if (p.Length > 1)
            {

                //Point res = p.Aggregate((current, point) => new Point(current.X + point.X, current.Y + point.Y));
                //(res.X, res.Y) = (res.X / p.Count(), res.Y / p.Count());
                //center = res;
                /*
                int X = (int)Math.Round(p.Average(p => p.X));
                int Y = (int)Math.Round(p.Average(p => p.Y));*/
                Point res = new Point((int)Math.Round(p.Average(p => p.X)), (int)Math.Round(p.Average(p => p.Y)));
                SelectedPointLabel.Text = String.Format("Selected Point:\n{0};{1}", res.X.ToString(), res.Y.ToString());
                return res;
            }
            else return AffinePoint;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (DinamicPoint)
            {  
                g.Clear(pictureBox1.BackColor);
                g.DrawLine(pen, intersect[1], intersect[0]);
                g.DrawLine(pen, intersect[2], e.Location);
                SortedSet<Point> sp = new SortedSet<Point>();
                
                Point intersection = Intersection(intersect[0], intersect[1], intersect[2], e.Location);
                if (intersection.X != -1)
                {
                    g.DrawEllipse(Pens.OrangeRed, intersection.X - 2, intersection.Y - 2, 4, 4);
                }
                pictureBox1.Invalidate();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RadioPointPos.Checked = RadioPointPos.Checked ? false : true;
        }
    }
}
