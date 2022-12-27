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
        Color color;
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
        List<Point[]> polygons = new List<Point[]>();
        LinkedList<Point> poligon = new LinkedList<Point>();
        Point[] p;
        Point center;

        double[,] shift = new double[3, 3] {
        {1,0,0 },
        {0,1,0 },
        {0,0,1 }
        };
        double[,] rotate = new double[3, 3] {
        {0,  1, 0 },
        {-1, 0, 0 },
        {0,  0, 1 }
        };
        AffineMatrix AffineMatr = new AffineMatrix();


        private Point fourWay(int j, int x, int y)
        {
            switch (j)
            {
                case 0: { /*g.DrawLine(Pens.Yellow, new Point(x, y), new Point(x, 0)); pictureBox1.Invalidate();*/ return new Point(x, 0); }
                case 1: { /*g.DrawLine(Pens.Yellow, new Point(x, y), new Point(0, y)); pictureBox1.Invalidate();*/ return new Point(0, y); }
                case 2: { /*g.DrawLine(Pens.Yellow, new Point(x, y), new Point(x, pictureBox1.Height - 1)); pictureBox1.Invalidate();*/ return new Point(x, pictureBox1.Height - 1); }
                case 3: {/*g.DrawLine(Pens.Yellow, new Point(x, y), new Point(pictureBox1.Width - 1, y)); pictureBox1.Invalidate();*/ return new Point(pictureBox1.Width - 1, y); }
                default: {/*g.DrawLine(Pens.Yellow, new Point(x, y), new Point(0, 0)); pictureBox1.Invalidate();*/ return new Point(0, 0); }
            }
        }

        //===============================================================================
        private bool isPointInner(Point point)
        {
            int count = 0;
           
            if (p != null && p.Length > 2)
            {
                Point p1 = p[p.Length - 1];
                Point shine;
                shine = new Point(point.X, 0); 
                for (int i = 0; i < p.Length; i++)
                {
                    Point p2 = p[i];
                    int x1 = p1.X, y1 = p1.Y, x2 = p2.X, y2 = p2.Y;
                    int x3 = point.X, y3 = point.Y, x4 = shine.X, y4 = shine.Y;
                    double k1 = 0, k2 = 0;
                    if ((y2 - y1) != 0)
                        k1 = 1.0 * (x2 - x1) / (y2 - y1);
                    if ((y4 - y3) != 0)
                        k2 = 1.0 * (x4 - x3) / (y4 - y3);

                    if (Math.Abs(k1 - k2) > 0.001)
                    {
                        Point Intersect = Intersection(p1, p2, point, shine);

                        if ((Math.Abs(x1 - x2) == Math.Abs(x1 - Intersect.X) + Math.Abs(x2 - Intersect.X)
                            && Math.Abs(y1 - y2) == Math.Abs(y1 - Intersect.Y) + Math.Abs(y2 - Intersect.Y))
                             && (Math.Abs(x3 - x4) == Math.Abs(x3 - Intersect.X) + Math.Abs(x4 - Intersect.X)
                            && Math.Abs(y3 - y4) == Math.Abs(y3 - Intersect.Y) + Math.Abs(y4 - Intersect.Y))

                            )
                        {
                            count++;
                        }

                        if ( Intersect == p1)
                        {
                            count--;
                        }

                    }
                    p1 = p2;
                }
                //}
            }

            return count % 2 != 0;// countIntersect[0] % 2 != 0 && countIntersect[1] % 2 != 0 && countIntersect[2] % 2 != 0 && countIntersect[3] % 2 != 0;
        }
        private bool isPointInner(Point point, LinkedList<Point> p)
        {
            int count = 0;
           
            if (p != null && p.Count > 2)
            {
                Point p1 = p.Last.Value;
                Point shine = new Point(point.X, 0);
                var node = p.First;
                while (node != null)
                {
                    Point p2 = node.Value;
                    int x1 = p1.X, y1 = p1.Y, x2 = p2.X, y2 = p2.Y;
                    int x3 = point.X, y3 = point.Y, x4 = shine.X, y4 = shine.Y;
                    double k1 = 0, k2 = 0;
                    if ((y2 - y1) != 0)
                        k1 = 1.0 * (x2 - x1) / (y2 - y1);
                    if ((y4 - y3) != 0)
                        k2 = 1.0 * (x4 - x3) / (y4 - y3);

                    if (Math.Abs(k1 - k2) > 0.001)
                    {
                        Point Intersect = Intersection(p1, p2, point, shine);

                        if ((Math.Abs(x1 - x2) == Math.Abs(x1 - Intersect.X) + Math.Abs(x2 - Intersect.X)
                            && Math.Abs(y1 - y2) == Math.Abs(y1 - Intersect.Y) + Math.Abs(y2 - Intersect.Y))
                             && (Math.Abs(x3 - x4) == Math.Abs(x3 - Intersect.X) + Math.Abs(x4 - Intersect.X)
                            && Math.Abs(y3 - y4) == Math.Abs(y3 - Intersect.Y) + Math.Abs(y4 - Intersect.Y))

                            )
                        {
                            count++;
                        }
                        if (Intersect == p1)
                        {
                            count--;
                        }
                    }
                    p1 = p2;
                    node = node.Next;
                }
                //}
            }

            return count % 2 != 0;// countIntersect[0] % 2 != 0 && countIntersect[1] % 2 != 0 && countIntersect[2] % 2 != 0 && countIntersect[3] % 2 != 0;
        }
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
        private void Draw(Point[] poligon)
        {
            ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
            Pen ps = new Pen(Color.Blue, 1.8f);
            foreach (Point z in poligon)
            {
                g.DrawEllipse(ps, z.X - 2, z.Y - 2, 4, 4);
            }
            ps.Dispose();
            if (poligon.Length > 1)
            {
                ev.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                ev.Graphics.DrawPolygon(Pens.Red, poligon);
            }
            else if (poligon.Length == 1)
                (pictureBox1.Image as Bitmap).SetPixel(poligon[0].X, poligon[0].Y, Pens.Red.Color);
            pictureBox1.Invalidate();
        }
        private Point MultMatrix(Point p, double[,] m)
        {
            double[] pp = new double[3] { p.X, p.Y, 1 };
            double[] result = new double[3] { 0, 0, 0 };
            for (int i = 0; i < 3; i++)//i < 2
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i] += pp[j] * m[i, j];
                }
            }
            return new Point((int)Math.Round(result[0]), (int)Math.Round(result[1]));
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
        /*  private void Rotate(Point A,double angle)
          {
              Shift(-A.X, -A.Y);
              Point c = RadioBtnAffine.Checked ? AffinePoint : center;
              AffineMatr.SetRotateAngle(angle,c);
              Change(AffineMatr);
              Shift(A.X, A.Y);
              Draw();
          }*/
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
            if ((q * p1 - q1 * p) != 0 && (p * q1 - p1 * q) != 0) {
                int x = (xo * q * p1 - x1 * q1 * p - yo * p * p1 + y1 * p * p1) /
                (q * p1 - q1 * p);
                int y = (yo * p * q1 - y1 * p1 * q - xo * q * q1 + x1 * q * q1) /
                    (p * q1 - p1 * q);

                if ((Math.Abs(A.X - B.X) == Math.Abs(A.X - x) + Math.Abs(B.X - x)
                                   && Math.Abs(A.Y - B.Y) == Math.Abs(A.Y - y) + Math.Abs(B.Y - y))
                                    && (Math.Abs(C.X - D.X) == Math.Abs(C.X - x) + Math.Abs(D.X - x)
                                   && Math.Abs(C.Y - D.Y) == Math.Abs(C.Y - y) + Math.Abs(D.Y - y)))
                {
                    return new Point(x, y);
                }
                else return new Point(-1, -1);
            }
            else return new Point(-1, -1);
        }
        static public List<Point> Intersection(Point A, Point B, Point[] polig, ref LinkedList<Point> ps)
        {
            List<Point> list = new List<Point>();
            if (polig.Length > 0)
            {
                Point p0 = polig[polig.Length - 1];
                for (int i = 0; i < polig.Length; i++)
                {
                    Point t = Intersection(A, B, p0, polig[i]);
                    if (t.X != -1)
                    {
                        list.Add(t);
                        ps.AddLast(t);
                    }
                    p0 = polig[i];
                }
               /* if (list.Count > 0)
                {
                    Point res = NearInersect(list, A);
                    ps.AddLast(res);
                }*/
            }
            return list;
        }
       

        static public List<Point> Intersection(Point A, Point B, List<Point> polig)
        {
            List<Point> ps = new List<Point>();
            Point p0 = polig[0];
            for (int i = 1; i < polig.Count; i++)
            {
                Point t = Intersection(A, B, p0, polig[i]);
                if (t.X != -1)
                {
                    ps.Add(t);
                }
                p0 = polig[i];
            }
            return ps;
        }
        static public LinkedList<Point> Intersection(Point[] p1, Point[] p2)
        {
            LinkedList<Point> ps = new LinkedList<Point>();
           
            if (p1.Length-1 < 0 || p2.Length-1 <0) return ps;
            Point p0 = p1[p1.Length - 1];
            ps.AddLast(p0);
            for (int i = 0; i < p1.Length; i++)
            {
                Intersection(p0, p1[i], p2, ref ps);

                p0 = p1[i];
                ps.AddLast(p0);
            }
            /*   LinkedList<Point> a = new LinkedList<Point>();
               for (int i = 0; i < ps.Count; i++)
               {
                   a.AddLast(ps[i]);
               }*/
            return ps;
        }
         public void IntersectionTwo(Point A, Point B, Point[] polig, ref LinkedList<Point> ps, ref LinkedList<Point> ps2)
        {
            List<Point> list = new List<Point>();
            Dictionary<Point, LinkedListNode<Point>> dict = new Dictionary<Point, LinkedListNode<Point>>();
            if (polig.Length > 0)
            {
                Point p0 = polig[polig.Length - 1];
              /*  for (int i = 0; i < polig.Length; i++)
                {
                    Point t = Intersection(A, B, p0, polig[i]);
                    if (t.X != -1)
                    {
                        list.Add(t);
                        dict[t] = p0; 
                       // ps2.AddBefore(ps2.Find(polig[i]), t );
                    }
                    p0 = polig[i];
                }*/
                var node = ps2.Last;
                do
                {
                    Point t = Intersection(A, B, node.Value, NextOrFirst(node).Value);
                    if (t.X != -1)
                    {
                        list.Add(t);
                        dict[t] = node;
                       
                    }
                    node = NextOrFirst(node);
                }
                while (node!=ps2.Last);

                while (list.Count > 0)
                {
                    Point add = NearInersect(A,ref list);
                 

                    ps.AddLast(add);
                    ps2.AddAfter(dict[add], add);
                  
                    
                }

                /* if (list.Count > 0)
                 {
                     Point res = NearInersect(list, A);
                     ps.AddLast(res);
                 }*/
            }
           // return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
         public void IntersectionTwo(Point[] p1, Point[] p2,out LinkedList<Point> ps1,out LinkedList<Point> ps2)
        {
            ps1 = new LinkedList<Point>();
            ps2 = new LinkedList<Point>();
           foreach (var item in p2)
            {
                ps2.AddLast(item);
            }
            if (p1.Length < 1 || p2.Length  < 1) return;// ps;
            Point p0 = p1[p1.Length - 1];
            ps1.AddLast(p0);
            for (int i = 0; i < p1.Length; i++)
            {
                IntersectionTwo(p0, p1[i], p2, ref ps1, ref ps2);

                p0 = p1[i];
                ps1.AddLast(p0);
            }
          //  return ps;
        }

        static public void Intersection(Point[] p1, Point[] p2,out LinkedList<Point> ps1,out LinkedList<Point> ps2)
        {
            ps1 = new LinkedList<Point>();
            ps2 = new LinkedList<Point>();

            if (p1.Length - 1 < 0 || p2.Length - 1 < 0) return ;
            Point pp0 = p1[p1.Length - 1];
            Point pp1 = p1[p1.Length - 1];
            ps1.AddLast(pp0);
            ps2.AddLast(pp1);

            for (int i = 0; i < p1.Length; i++)
            {
                Intersection(pp0, p1[i], p2, ref ps1);
                Intersection(pp1, p2[i], p1, ref ps2);
                pp0 = p1[i];
                ps1.AddLast(pp0);
                ps1.AddLast(pp1);

            }
            /*   LinkedList<Point> a = new LinkedList<Point>();
               for (int i = 0; i < ps.Count; i++)
               {
                   a.AddLast(ps[i]);
               }*/
        }
        bool DinamicPoint = false;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectingPoint)
            {
                SelectingPoint = false;
                g.DrawEllipse(new Pen(pictureBox1.BackColor), AffinePoint.X - 2, AffinePoint.Y - 2, 4, 4);
                AffinePoint = e.Location;
                g.DrawEllipse(Pens.Red, e.X - 2, e.Y - 2, 4, 4);
                pictureBox1.Invalidate();
                SelectedPointLabel.Text = String.Format("Selected point:\n{0};{1}\n{2}", e.Location.X.ToString(), e.Location.Y.ToString(), isPointInner(AffinePoint) ? " Внутри " : " Снаружи ");
            }
            else if (RadioPointPos.Checked)
            {
                var output = PointPos(p, new Point(e.X, e.Y));
                g.DrawEllipse(Pens.OrangeRed, e.X - 2, e.Y - 2, 4, 4);
                g.DrawEllipse(pen, p[1].X - 2, p[1].Y - 2, 4, 4);
                pictureBox1.Invalidate();
                if (MessageBox.Show(output) == DialogResult.OK)
                {
                    Pen penBackCol = new Pen(pictureBox1.BackColor);
                    g.DrawEllipse(penBackCol, e.X - 2, e.Y - 2, 4, 4);
                    g.DrawEllipse(penBackCol, p[1].X - 2, p[1].Y - 2, 4, 4);
                    g.DrawLine(pen, p[0], p[1]);
                    pictureBox1.Invalidate();
                }
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

        // Задать примитив
        private void button1_Click(object sender, EventArgs e)
        {
            // g.Clear(Color.White);
            poligon.Clear();
            RadioPointPos.Checked = false;
            var bmp = (pictureBox1.Image as Bitmap);
            p = new Point[points.Count];
            if (points.Count > 1)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    //g.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                    poligon.AddLast(points[i]);
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
            polygons.Add(p);
            points.Clear();
            if (p.Length != 0)
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
            if (p != null && p.Length > 0 && textBox1.Text != "" && textBox2.Text != "")
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
                AffineMatr.Scale(p, c, 2, 2);
                Draw();
            }
        }
        // Масштабирование - уменьшение
        private void button2_Click(object sender, EventArgs e)//!!!!!!!!!!!!!!!! buttonScaleDown !!!!!!!!!!!!!!!!
        {
            if (p != null && p.Length > 0)
            {
                Point c = RadioBtnAffine.Checked ? AffinePoint : center;
                AffineMatr.Scale(p, c, 1.0 / 2, 1.0 / 2);
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
            polygons.Clear();
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
                    int x = intersection.X, y = intersection.Y;
                    int x1 = intersect[0].X, y1 = intersect[0].Y, x2 = intersect[1].X, y2 = intersect[1].Y;
                    int x3 = intersect[2].X, y3 = intersect[2].Y, x4 = e.X, y4 = e.Y;
                    if ((Math.Abs(x1 - x2) == Math.Abs(x1 - x) + Math.Abs(x2 - x)
                                && Math.Abs(y1 - y2) == Math.Abs(y1 - y) + Math.Abs(y2 - y))
                                 && (Math.Abs(x3 - x4) == Math.Abs(x3 - x) + Math.Abs(x4 - x)
                                && Math.Abs(y3 - y4) == Math.Abs(y3 - y) + Math.Abs(y4 - y)))
                    {
                        g.DrawEllipse(Pens.OrangeRed, intersection.X - 2, intersection.Y - 2, 4, 4);
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RadioPointPos.Checked = RadioPointPos.Checked ? false : true;
        }
        //
        LinkedListNode<Point> Start(LinkedList<Point> p1, LinkedList<Point> p2, out bool who)
        {
            var node1 = p1.First;
            var node2 = p2.First;
            while (isPointInner(node1.Value, p2) && isPointInner(node2.Value, p1))
            {
                node1 = node1.Next;
                node2 = node2.Next;
            }
            if (!isPointInner(node1.Value, p2))
            {
                who = true;
                return node1;
            }
            if (!isPointInner(node2.Value, p1))
            {
                who = false;
                return node2;
            }
            who = true;
            return p1.First;
        }
        LinkedListNode<Point> LeftPoint(LinkedList<Point> p1)
        {
            var node1 = p1.First;
            LinkedListNode<Point> node = p1.First;
            while (node1 != null)
            {
                if (node1.Value.X < node.Value.X)
                {
                    node = node1;
                }
                node1 = node1.Next;
            }
            return node;
        }
        LinkedListNode<Point> TopPoint(LinkedList<Point> p1)
        {
            var node1 = p1.First;
            LinkedListNode<Point> node = p1.First;
            while (node1 != null)
            {
                if (node1.Value.Y < node.Value.Y)
                {
                    node = node1;
                }
                node1 = node1.Next;
            }
            return node;
        }
        LinkedListNode<Point> DownPoint(LinkedList<Point> p1)
        {
            var node1 = p1.First;
            LinkedListNode<Point> node = p1.First;
            while (node1 != null)
            {
                if (node1.Value.Y > node.Value.Y)
                {
                    node = node1;
                }
                node1 = node1.Next;
            }
            return node;
        }
        LinkedListNode<Point> StartLeft(LinkedList<Point> p1, LinkedList<Point> p2, out bool who)
        {
            who = true;
            LinkedListNode<Point> node = p1.First;
            var node1 = LeftPoint(p1);
            var node2 = LeftPoint(p2);
            if (node2.Value.X < node1.Value.X)
            {
                who = false;
                node = node2;
            }
            else
            {
                node = node1;
            }
            return node;
        }
        LinkedListNode<Point> NextOrFirst(LinkedListNode<Point> node)
        {
            if (node.Next == null)
            {
                return node.List.First;
            }
            else
            {
                return node.Next;
            }
        }
        LinkedListNode<Point> PrevOrLast(LinkedListNode<Point> node)
        {
            if (node.Previous == null)
            {
                return node.List.Last;
            }
            else
            {
                return node.Previous;
            }
        }
        int CountNodeNext(LinkedListNode<Point> start, LinkedListNode<Point> down)
        {
            int count = 0;
            var last = start.List.Last.Next; 
            last = start.List.First;
            while (start!=down)
            {
                count++;
               start = NextOrFirst(start);
            }

            return count;
        }
        int CountNodePrevious(LinkedListNode<Point> start, LinkedListNode<Point> down)
        {
            int count = 0;
            while (start != down)
            {
                count++;
                start = PrevOrLast(start);
            }

            return count;
        }
        LinkedList<Point>  Reverse(LinkedList<Point> list)
        {
            LinkedList<Point> newList = new LinkedList<Point>();
            var node = list.First;
            while (node != null)
            {
                newList.AddFirst(node.Value);
                node = node.Next;
            }
            return newList;
        }
        public LinkedList<Point> Normalize(LinkedList<Point> list)
        {
            LinkedListNode<Point> start = LeftPoint(list);
            LinkedListNode<Point> down  = DownPoint(list); 
            LinkedListNode<Point> top   = TopPoint(list);
            if (CountNodeNext(start,down) > CountNodePrevious(start, down)  || CountNodeNext(start, top) < CountNodePrevious(start, top))
            {
                return Reverse(list);
            }
            return list;
        }
        public static Point NearInersect(Point p,ref List<Point> p1)
        {
            if (p1.Count > 0)
            {
                Point r = p1[0];
                foreach (var i in p1)
                {
                    if (Math.Sqrt(Math.Pow(Math.Abs(i.X - p.X), 2) + Math.Pow(Math.Abs(i.Y - p.Y), 2)) <
                        Math.Sqrt(Math.Pow(Math.Abs(r.X - p.X), 2) + Math.Pow(Math.Abs(r.Y - p.Y), 2)) )
                    {
                        r = i;
                    }
                }
                p1.Remove(r);
                return r;
            }
            else
            {
                return new Point(-1, -1);
            }
        }
        public Point[] unionpolygons(Point[] p1, Point[] p2)
        {
            List<Point> ps = new List<Point>();
            LinkedList<Point> p1new;
            LinkedList<Point> p2new;
            IntersectionTwo(p1, p2, out p1new,out p2new);

            p1new = Normalize(p1new);
            p2new = Normalize(p2new);

            bool u = true;
            
            var start = StartLeft(p1new, p2new, out u);
          
            var node = start;

            ps.Add(node.Value);
            node = NextOrFirst(node);
            while (node != start )//&& node != null )//&& (ps.Count<p1new.Count+p2new.Count || !ps.Contains(node.Value))
            {
                if (u)
                {
                    var t = p2new.Find(node.Value);
                    if (t != null)
                    {
                        ps.Add(t.Value);
                        u = false;
                        node = NextOrFirst(t);
                    }
                    else
                    {
                        {
                            ps.Add(node.Value);
                            node = NextOrFirst(node);
                        }
                    }
                }
                else
                {
                    var t = p1new.Find(node.Value);
                    if (t != null)
                    {
                        ps.Add(t.Value);
                        u = true;
                        node = NextOrFirst(t);
                    }
                    else
                    {
                        {
                            ps.Add(node.Value);
                            node = NextOrFirst(node);
                        }
                    }
                }
            }
            Point[] a = new Point[ps.Count];
            for (int i = 0; i < ps.Count; i++)
            {
                a[i] = ps[i];
            }
            polygons.Add(a);
            p = a;
            return a;
        }

            private void button6_Click_1(object sender, EventArgs e)
        {
            if (polygons.Count >= 2 && polygons[polygons.Count - 2].Length>2 && polygons[polygons.Count - 1].Length>2)
             Draw(unionpolygons(polygons[polygons.Count-2], polygons[polygons.Count - 1]));
        }
    }

}
