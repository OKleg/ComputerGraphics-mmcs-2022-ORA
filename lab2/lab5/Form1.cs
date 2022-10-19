using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;

namespace lab5
{
    public partial class Form1 : Form
    {
        Graphics g;
        Color color;
        Pen pen;
        PaintEventArgs ev;
        Point p;
        public Random rnd = new Random();
        //2
        List<Edge> edges = new List<Edge>();
        //3
        List<BezierPoint> bPoints = new List<BezierPoint>();
       // List<Point> Points = new List<Point>();
        double tb;

        public LinearGradientBrush SkyBrush { get; private set; }
        public LinearGradientBrush LandBrush {get; private set;}

        //List<Point> MidPoints = new List<Point>();
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            PaintEventArgs ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
            Point p = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            LeftHeight.Text = (pictureBox1.Height/2).ToString();
            RightHeight.Text = (pictureBox1.Height / 2).ToString();
            Roughness.Text = "0.1".ToString();

            SkyBrush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.FromArgb(255, 14, 29, 58),
                                                               Color.FromArgb(255, 82, 99, 127),
                                                               90F);

            LandBrush = new LinearGradientBrush(this.ClientRectangle,
                                                              Color.FromArgb(255, 85, 92, 111),
                                                              Color.FromArgb(255, 5, 5, 13),
                                                              90F);
        }
        private PointF calculate(double t, PointF p1, PointF p2, PointF p3, PointF p4)

        {

            double f = (1 - t);

            double x = Math.Pow(f, 3) * p1.X +

                 3 * Math.Pow(f, 2) * t * p2.X +

                 3 * f * Math.Pow(t, 2) * p3.X +

                 Math.Pow(t, 3) * p4.X;

            double y = Math.Pow(f, 3) * p1.Y +

                 3 * Math.Pow(f, 2) * t * p2.Y +

                 3 * f * Math.Pow(t, 2) * p3.Y +

                 Math.Pow(t, 3) * p4.Y;

            return new PointF((float)x, (float)y);

        }
        private void drawcurveBy4pts(PointF p1, PointF p2, PointF p3, PointF p4)

        {

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            double t = 0.0;


            PointF prev = calculate(t, p1, p2, p3, p4);

            while (t <= 1.0)

            {

                PointF next = calculate(t, p1, p2, p3, p4);

                g.DrawLine(Pens.Blue, prev, next);

                t += 0.001;

                prev = next;

            }

            pictureBox1.Invalidate();


        }

        /* private double[,] MultMatrix1(double[,] pp, double[,] m)
         {
             double[,] result = new double[3, 4] { {0, 0, 0, 0 },{ 0, 0, 0, 0 },{ 0, 0, 0, 0 } };
             for (int i = 0; i < 3; i++)//i < 2
             {
                 for (int j = 0; j < 4; j++)
                 {
                     result[i,j] += pp[i,j] * m[i, j];
                 }
             }
             return result;
         }
         private double[,] MultMatrix2(double[,] pp, double[,] m)
         {
             double[,] result = new double[3, 1] { { 0}, { 0 }, { 0 } };
             for (int i = 0; i < 3; i++)//i < 2
             {
                 for (int j = 0; j < 1; j++)
                 {
                     result[i, j] += pp[i, j] * m[i, j];
                 }
             }
             return result;
         }
         double[,] M = new double[4, 4]
                 {
                     {1,-3, 3, 1 },
                     {0, 3,-6, 3 },
                     {0, 0, 3,-3 },
                     {0, 0, 0, 1 }
                 };
         public void DrawBez()
         {
             int t1 = 0;
             Point b1 = bPoints[0].r;
             for (int t = 1; t < 99; t++)
             {
                 for (int i = 0; i < bPoints.Count-4; i++)
                 {
                     double[,] V = new double[3, 4]
                     {
                         {bPoints[i].r.X,bPoints[i+1].r.X, bPoints[i+2].r.X, bPoints[i+3].r.X },
                         {bPoints[i].r.Y,bPoints[i+1].r.Y, bPoints[i+2].r.Y, bPoints[i+3].r.Y  },
                         {1, 1, 1,1 }
                     };

                     double[,] T = new double[4, 1]
                     {
                     {1},
                     {tb},
                     {Math.Pow(tb,2)},
                     {Math.Pow(tb,3)}
                     };
                     double[,] VM = MultMatrix1(V, M);
                     double[,] VMT = MultMatrix2(VM, T);
                     Point b2 = new Point((int)VMT[0,0], (int)VMT[1, 0]);
                     g.DrawLine(Pens.Blue,b1, b2);
                     pictureBox1.Invalidate();
                     b1 = b2;
                     t1 = t;
                 }
             }
         }*/
        void DrawBPoint()
        {
            g.Clear(pictureBox1.BackColor);
            Queue<BezierPoint> q = new Queue<BezierPoint>();
            foreach (BezierPoint e in bPoints)
            {
                q.Enqueue(e);
                g.DrawEllipse(pen, e.r.X - 1, e.r.Y - 1, 3, 3);
                g.DrawEllipse(Pens.Blue, e.p1.X - 1, e.p1.Y - 1, 3, 3);
                g.DrawEllipse(Pens.Blue, e.p2.X - 1, e.p2.Y - 1, 3, 3);
                g.DrawLine(Pens.Red, e.p1, e.p2);
                if (bPoints.Count > 1 )
                {
                    
                    if (q.Count > 1)
                    {
                        BezierPoint br1 = q.Dequeue();
                        BezierPoint br2 = q.Peek();

                        drawcurveBy4pts(br1.r,br1.p2,br2.p1,br2.r);
                    }
                }
            }
            
            pictureBox1.Invalidate();
           // DrawBez();
        }
        private void buttonL_Click(object sender, EventArgs e)
        {
         using ( FileStream fs = File.OpenRead("../../L.txt")){
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    textBox1.Text += temp.GetString(b)+"\n";

                }
            };
            g.DrawLine(pen, p.X, p.Y, (int)((p.X)+10*Math.Tan(45)),  (int)((p.Y) + 10*Math.Tan(45)) );
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           // p = e.Location;
           // g.DrawEllipse(pen, e.X - 1, e.Y - 1, 3, 3); 
            pictureBox1.Invalidate();
           
        }

        void MidPoint(double R = 0.1)
        {           
            for (int i = 0; i < edges.Count; i+=2)
            {                
                //h = (hL + hR) / 2 + random(- R * l, R * l)               
                //midpoint calculate
                var midX = edges[i].MidX();                
                var lenght = edges[i].Lenght();
                var midY = edges[i].MidY() + rnd.Next((int)Math.Round(-R * lenght), (int)Math.Round(R * lenght));
                //spli edge to two edges by midpoint
                var mid = new Point(midX, midY);
                var NewEdge = new Edge(new Point(midX, midY), edges[i].right);                 
                edges[i].right = mid;
                //insert new edge
                edges.Insert(i + 1, NewEdge);
            }
        }

        /*public Point[] GetRect()
        {
            Point[] ps = new Point[edges.Count *2];
            ps.Append(new Point(0, pictureBox1.Height));
            foreach ( Edge edge in edges)
            {
                ps.Append(edge.left);
                ps.Append(edge.right);
            }
            ps.Append(new Point(pictureBox1.Width, pictureBox1.Height));

            return ps;
        }*/


        private void buttonMidpoint_Click(object sender, EventArgs e)
        {
            if (edges.Count < 1)
            {
                int lh, rh; //leftheight, rightheight
                //parse user input
                if (!(int.TryParse(LeftHeight.Text, out lh) || lh <0 || lh > pictureBox1.Height)) lh = 250; 
                if (!(int.TryParse(RightHeight.Text, out rh) || rh < 0 || rh > pictureBox1.Height)) rh = 250;
                //adding 1st edge (lh;rh)
                edges.Add(new Edge(new Point(0, lh), new Point(pictureBox1.Width, rh)));

                
                if (LandscapeBox.Checked)
                {
                    // типо красиво
                    g.FillRectangle(SkyBrush, pictureBox1.ClientRectangle);
                    DrawTer(edges);
                }
                else
                {     
                    //просто линия
                    g.DrawLine(pen, edges[0].left, edges[0].right);
                    pictureBox1.Invalidate();
                }
            }
            else
            {
                double R;
                if (!(double.TryParse(Roughness.Text.Replace(".",","), out R) || R < 0 || R > 3)) R = 0.1;
                MidPoint(R);

                if (LandscapeBox.Checked)
                {
                    // типо красиво
                    g.FillRectangle(SkyBrush, pictureBox1.ClientRectangle);
                    DrawTer(edges);
                }
                else
                {
                    //перерисовка линии
                    g.Clear(pictureBox1.BackColor);
                    
                    edges.ForEach(edge => {
                        g.DrawLine(pen, edge.left, edge.right);                        
                        pictureBox1.Invalidate();
                    });
                }
      
                //ev.Graphics.FillPolygon(Brushes.Black, GetRect());
                //ev.Graphics.DrawLines(Pens.Black, GetRect());
                //g.FillPolygon()

                //g.DrawLines(pen);
                //               
            }
        }

        private void DrawTer(List<Edge> edges)
        {
            //...
            LinkedList<Point> pp = new LinkedList<Point>(edges.Select(e => e.left).Append(edges.Last().right));

            //pp.AddLast(edges.Last().right);
            //adding points to draw land
            pp.AddFirst(new Point(0, pictureBox1.Height));
            pp.AddLast(new Point(pictureBox1.Width, pictureBox1.Height));    
            //fill land
            g.FillPolygon(LandBrush, pp.ToArray());
            pictureBox1.Invalidate();
        }

        private void LeftHight_TextChanged(object sender, EventArgs e)
        {

        }

        private void LandscapeBox_CheckedChanged(object sender, EventArgs e)
        {
            //переключатель красоты на не красоту
            if (LandscapeBox.Checked && edges.Count !=0)
            {
                g.FillRectangle(SkyBrush, pictureBox1.ClientRectangle);
                DrawTer(edges);
            }
            else
            {
                g.Clear(pictureBox1.BackColor);
                edges.ForEach(edge => {
                    g.DrawLine(pen, edge.left, edge.right);
                    pictureBox1.Invalidate();
                });

            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            edges.Clear();
            bPoints.Clear();
            LandscapeBox.Checked = false;
            g.Clear(pictureBox1.BackColor);
            pictureBox1.Invalidate();
        }

        private void buttonBezier_Click(object sender, EventArgs e)
        {
            radioBezier.Checked = radioBezier.Checked ? false : true;
        }

      
        int SelectedId;
        int SelectedNum;
        bool rotaeBPoint = false, moveBPoint = false;
        bool PointIsNear(Point p0, Point e)
        {
            return (Math.Abs(p0.X - e.X) < 3 && Math.Abs(p0.Y - e.Y) < 3);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < bPoints.Count; i++)
            {
                if (PointIsNear(bPoints[i].p1, e.Location))
                {
                    SelectedId = i;
                    SelectedNum = 1;
                    rotaeBPoint = true;
                }
                else if (PointIsNear(bPoints[i].p2, e.Location))
                {
                    SelectedId = i;
                    SelectedNum = 2;
                    rotaeBPoint = true;
                }
                else if (PointIsNear(bPoints[i].r, e.Location))
                {
                    SelectedId = i;
                    moveBPoint = true;
                }
                
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (rotaeBPoint)
            {
                if (SelectedNum == 1) 
                 bPoints[SelectedId].SetP1(e.Location);
                else if (SelectedNum == 2)
                    bPoints[SelectedId].SetP2(e.Location);
                DrawBPoint();
            }
            else if (moveBPoint)
            {
                bPoints[SelectedId].SetR(e.Location);
                DrawBPoint();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!rotaeBPoint && !moveBPoint)
            {
                if (radioBezier.Checked)
                {
                    BezierPoint b = new BezierPoint(e.Location);
                    // Points.Add(b.p1);
                    // Points.Add(b.r);
                    // Points.Add(b.p2);
                    bPoints.Add(b);
                    DrawBPoint();
                }
            }
            rotaeBPoint = false;
            moveBPoint = false;
        }
    }
}
