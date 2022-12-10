using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace lab6
{
    public partial class Form1 : Form
    {
        Graphics g;
        Color color = Color.Black;
        Pen pen = new Pen(Color.Black);
        PaintEventArgs ev;

        List<Polyhedron> polyhedrons;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            PaintEventArgs ev = new PaintEventArgs(g, pictureBox1.ClientRectangle);
            polyhedrons = new List<Polyhedron>();
        }
        private void Draw(Polyhedron polyhedron)
        {
            g.Clear(Color.White);
            List<Edge> edges = polyhedron.edges;
            //AffineMatrix m = new AffineMatrix();
            
            foreach (var e in edges)
            {
                if (e.p1 == 0 || e.p2 == 0)
                {
                    pen = Pens.Red;
                }
                else if (e.p1 == 6 || e.p2 == 6)
                {
                    pen = Pens.Blue;
                }
                else   pen = new Pen(color); 
                g.DrawLine(pen,
                     polyhedron.vertices[e.p1].x,
                     polyhedron.vertices[e.p1].y,
                     polyhedron.vertices[e.p2].x,
                     polyhedron.vertices[e.p2].y);
            }
            pictureBox1.Invalidate();
        }
       
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            (hx.Enabled, hy.Enabled, hz.Enabled,button4.Enabled) 
                = (true, true, true, true);
            if (comboBox1.SelectedItem.ToString() == "Куб")
            {
                polyhedrons.Add(new Cube());
               // AffineMatrix m = new AffineMatrix();
                Matrix matr = 
                      Matrix.getRotationX(20)
                    * Matrix.getRotationY(20)
                    * Matrix.getTranslation(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
                Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, matr);
                // m.Rotate(polyhedrons[polyhedrons.Count - 1].vertices, 180, 0, 0);
                //m.Rotate(polyhedrons[polyhedrons.Count - 1].vertices, 20, 20, 0);
                /*m.Translation(polyhedrons[polyhedrons.Count - 1].vertices,
                    pictureBox1.Width / 2, pictureBox1.Height / 2, 0);*/

                Draw(polyhedrons[polyhedrons.Count - 1]);
            }
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar2.Value.ToString();
            // AffineMatrix m = new AffineMatrix();
          
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[polyhedrons.Count - 1].vertices);
            // m.Rotate(sceneVertices, trackBar2.Value, trackBar1.Value, 0);
            Matrix m = Matrix.getRotationX(trackBar2.Value);
            Matrix.Transform(sceneVertices, m);
            Draw(new Polyhedron(sceneVertices, polyhedrons[polyhedrons.Count - 1].edges));

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[polyhedrons.Count - 1].vertices);
            Matrix m = Matrix.getRotationY(trackBar2.Value);
            Matrix.Transform(sceneVertices, m);
            //AffineMatrix m = new AffineMatrix();
            // m.Rotate(sceneVertices, trackBar2.Value, trackBar1.Value, 0);
            Draw(new Polyhedron(sceneVertices, polyhedrons[polyhedrons.Count - 1].edges));
        }
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            // AffineMatrix m = new AffineMatrix();
            // m.Rotate(polyhedrons[polyhedrons.Count - 1].vertices, trackBar2.Value, trackBar1.Value,  0);
            Matrix m = Matrix.getRotationY(trackBar2.Value);
            Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m); 
            Draw(polyhedrons[polyhedrons.Count - 1]);
            trackBar1.Value = 0;
        }
        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            /*  AffineMatrix m = new AffineMatrix();
              m.Rotate(polyhedrons[polyhedrons.Count - 1].vertices, trackBar2.Value, trackBar1.Value,  0);*/
            Matrix m = Matrix.getRotationX(trackBar2.Value);
            Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
            Draw(polyhedrons[polyhedrons.Count - 1]);
            trackBar2.Value = 0;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color =  colorDialog1.Color;
            button5.BackColor = color;
            pen = new Pen(color);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AffineMatrix m = new AffineMatrix();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[polyhedrons.Count - 1].vertices);
            sceneVertices = m.Scale(sceneVertices, 2, 2, 2);
            //Draw(new Polyhedron(sceneVertices, polyhedrons[polyhedrons.Count - 1].edges));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AffineMatrix m = new AffineMatrix(); 
            m.Scale(polyhedrons[polyhedrons.Count - 1].vertices, 0.5f, 0.5f, 0.5f);
           // Draw(polyhedrons[polyhedrons.Count - 1]);
        }

        
        //Смещение
        private void button4_Click(object sender, EventArgs e)
        {
            if (hx.Text!="" && hy.Text != "" && hz.Text != "" )
            {
                AffineMatrix m = new AffineMatrix();
                m.Translation(polyhedrons[polyhedrons.Count - 1].vertices,int.Parse(hx.Text), int.Parse(hy.Text), int.Parse(hz.Text));
              //  Draw(polyhedrons[polyhedrons.Count - 1]);
            }
        }

      
    }
}
