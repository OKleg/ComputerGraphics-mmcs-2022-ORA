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
        List<Edge> edges = new List<Edge>();

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

       
        private void F()
        {

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
            p = e.Location;
            g.DrawEllipse(pen, e.X - 1, e.Y - 1, 3, 3); 
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
            LandscapeBox.Checked = false;
            g.Clear(pictureBox1.BackColor);
            pictureBox1.Invalidate();
        }
    }
}
