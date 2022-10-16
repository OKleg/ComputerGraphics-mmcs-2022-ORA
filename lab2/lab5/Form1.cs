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

        void MidPointNew(double R)
        {
            
        }
        public Point[] GetRect()
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
        }


        private void buttonMidpoint_Click(object sender, EventArgs e)
        {
            if (edges.Count < 1)
            {
                int lh, rh;
                if (!(int.TryParse(LeftHeight.Text, out lh) || lh <0 || lh > pictureBox1.Height)) lh = 250;
                if (!(int.TryParse(RightHeight.Text, out rh) || rh < 0 || rh > pictureBox1.Height)) rh = 250;
                edges.Add(new Edge(new Point(0, lh), new Point(pictureBox1.Width, rh)));

                LinearGradientBrush mybrush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.FromArgb(255, 0, 128, 128),
                                                               Color.FromArgb(255, 222, 239, 239),
                                                               90F);

                g.FillRectangle(mybrush, pictureBox1.ClientRectangle);

                g.DrawLine(pen, edges[0].left, edges[0].right);
                pictureBox1.Invalidate();           
            }
            else
            {
                double R;
                if (!(double.TryParse(Roughness.Text, out R) || R < 0 || R > 3)) R = 0.1;
                MidPoint(R);
                LinearGradientBrush mybrush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.FromArgb(255, 0, 128, 128),
                                                               Color.FromArgb(255, 222, 239, 239),
                                                               90F);

                g.FillRectangle(mybrush, pictureBox1.ClientRectangle); 
                for (int i = 0; i < edges.Count; i++)
                {                  
                    g.DrawLine(pen, edges[i].left, edges[i].right);
                    //var myBrush = new SolidBrush(Color.Black);
                    //
                    pictureBox1.Invalidate();
                    
                }
                //ev.Graphics.FillPolygon(Brushes.Black, GetRect());
                //ev.Graphics.DrawLines(Pens.Black, GetRect());
                //g.FillPolygon()

                //g.DrawLines(pen);
                
                
                pictureBox1.Invalidate();
            }
        }

        private void LeftHight_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
