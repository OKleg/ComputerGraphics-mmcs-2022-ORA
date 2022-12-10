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
        Pen penX = new Pen(Color.IndianRed);
        Pen penY = new Pen(Color.LightGreen);
        Pen penZ = new Pen(Color.LightBlue);


        List<Polyhedron> polyhedrons;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            polyhedrons = new List<Polyhedron>();
        }
        private void Draw(Polyhedron polyhedron)
        {
            g.Clear(Color.White);
            List<Edge> edges = polyhedron.edges;
            float HY = pictureBox1.Height;
            //AffineMatrix m = new AffineMatrix();
            List<Vector> sceneVertices = new List<Vector>(polyhedron.vertices);
            Matrix matr = Matrix.getTranslation(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
            Matrix.Transform(sceneVertices, matr);
            /*g.DrawLine(penX,
                    sceneVertices[sceneVertices.Count-1].x,
                    sceneVertices[sceneVertices.Count - 1].y,
                    sceneVertices[sceneVertices.Count - 1].x+ 150,
                    sceneVertices[sceneVertices.Count - 1].y);
            g.DrawLine(penY,
                    sceneVertices[sceneVertices.Count - 1].x,
                    sceneVertices[sceneVertices.Count - 1].y,
                    sceneVertices[sceneVertices.Count - 1].x,
                    sceneVertices[sceneVertices.Count - 1].y + 150);
            Vector zVector = new Vector(-1, -1, 0);
            Vector zCoords = sceneVertices[sceneVertices.Count - 1] + (zVector.normalize() * 150);
            
            g.DrawLine(penZ,
               sceneVertices[sceneVertices.Count - 1].x,
               sceneVertices[sceneVertices.Count - 1].y,
              zCoords.x, 
              zCoords.y
            );*/
            foreach (var e in edges)
            {
                if (e.p1 == 0 || e.p2 == 0)
                {
                    pen = new Pen(Color.Red);
                }
                else if (e.p1 == 6 || e.p2 == 6)
                {
                    pen = new Pen(Color.Blue);
                }
                else   pen = new Pen(color); 
                g.DrawLine(pen,
                     sceneVertices[e.p1].x,
                     sceneVertices[e.p1].y,
                     sceneVertices[e.p2].x,
                     sceneVertices[e.p2].y);
            }
           
            pictureBox1.Invalidate();
        }
       private void SetZero(List<Vector> v, out float dx,out float  dy,out float dz)
        {
            dx = polyhedrons[polyhedrons.Count - 1].vertices.Last().x;
            dy = polyhedrons[polyhedrons.Count - 1].vertices.Last().y;
            dz = polyhedrons[polyhedrons.Count - 1].vertices.Last().z;

            Matrix.Transform(v, Matrix.getTranslation(-dx, -dy, -dz));
        }
        private void ReSetZero(List<Vector> v, float dx,  float dy,  float dz)
        {
            Matrix.Transform(v, Matrix.getTranslation(dx, dy, dz));

        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            (hx.Enabled, hy.Enabled, hz.Enabled,button4.Enabled) 
                = (true, true, true, true);
            if (comboBox1.SelectedItem.ToString() == "Гексаэдр")
            {
                polyhedrons.Add(new Cube());

                Draw(polyhedrons[polyhedrons.Count - 1]);
            }
            else if (comboBox1.SelectedItem.ToString() == "Тетраэдр")
            {
                polyhedrons.Add(new Tetrahedron());
                Draw(polyhedrons[polyhedrons.Count - 1]);
            }
            else if (comboBox1.SelectedItem.ToString() == "Октаэдр")
            {
                polyhedrons.Add(new Octahedron());
                Draw(polyhedrons[polyhedrons.Count - 1]);
            }


        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            // AffineMatrix m = new AffineMatrix();
           // m.Rotate(sceneVertices, trackBar2.Value, trackBar1.Value, 0);
            label4.Text = trackBar2.Value.ToString();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[polyhedrons.Count - 1].vertices);
            Matrix m = Matrix.getRotationX(trackBar2.Value);
            float dx, dy, dz;
            SetZero(sceneVertices,out dx, out dy, out dz);
            Matrix.Transform(sceneVertices, m);
            ReSetZero(sceneVertices, dx,  dy,  dz);
            Draw(new Polyhedron(sceneVertices, polyhedrons[polyhedrons.Count - 1].edges));

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //AffineMatrix m = new AffineMatrix();
            // m.Rotate(sceneVertices, trackBar2.Value, trackBar1.Value, 0);
            label1.Text = trackBar1.Value.ToString();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[polyhedrons.Count - 1].vertices);
            Matrix m = Matrix.getRotationY(trackBar1.Value);
            float dx, dy, dz;
            SetZero(sceneVertices, out dx, out dy, out dz);
            Matrix.Transform(sceneVertices, m);
            ReSetZero(sceneVertices, dx, dy, dz);

            Draw(new Polyhedron(sceneVertices, polyhedrons[polyhedrons.Count - 1].edges));
        }
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            // AffineMatrix m = new AffineMatrix();
            // m.Rotate(polyhedrons[polyhedrons.Count - 1].vertices, trackBar2.Value, trackBar1.Value,  0);
            Matrix m = Matrix.getRotationY(trackBar1.Value);
            float dx, dy, dz;
            SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
            ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);

            Draw(polyhedrons[polyhedrons.Count - 1]);
            trackBar1.Value = 0;
            label1.Text = trackBar1.Value.ToString();
        }
        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            /*  AffineMatrix m = new AffineMatrix();
              m.Rotate(polyhedrons[polyhedrons.Count - 1].vertices, trackBar2.Value, trackBar1.Value,  0);*/
            Matrix m = Matrix.getRotationX(trackBar2.Value);
            float dx, dy, dz;
            SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
            ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);

            Draw(polyhedrons[polyhedrons.Count - 1]);
            trackBar2.Value = 0;
            label4.Text = trackBar2.Value.ToString();
        }
        //Color
        private void button5_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color =  colorDialog1.Color;
            button5.BackColor = color;
            pen = new Pen(color);
        }
        //Scale
        private void button1_Click(object sender, EventArgs e)
        {
            Matrix m = Matrix.getScale(2,2,2);
            float dx, dy, dz;
            SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
            ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);
            Draw(polyhedrons[polyhedrons.Count - 1]);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Matrix m = Matrix.getScale(0.5f, 0.5f, 0.5f);
            float dx, dy, dz;
            SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
            ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);
            Draw(polyhedrons[polyhedrons.Count - 1]);
        }

        
        //Смещение
        private void button4_Click(object sender, EventArgs e)
        {
            if (hx.Text!="" && hy.Text != "" && hz.Text != "" )
            {
                /* AffineMatrix m = new AffineMatrix();
                 m.Translation(polyhedrons[polyhedrons.Count - 1].vertices,int.Parse(hx.Text), int.Parse(hy.Text), int.Parse(hz.Text));
              */ //  Draw(polyhedrons[polyhedrons.Count - 1]);
                Matrix m = Matrix.getTranslation(int.Parse(hx.Text), int.Parse(hy.Text), int.Parse(hz.Text));
                Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
                Draw(polyhedrons[polyhedrons.Count - 1]);
            }
        }

        //Отражение
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem != null)
            {
                if (comboBox5.SelectedItem.ToString() == "Oxy")
                {
                    Matrix m = Matrix.getScale(1, 1, -1);
                    Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
                    Draw(polyhedrons[polyhedrons.Count - 1]);
                }
                else if (comboBox5.SelectedItem.ToString() == "Oyz")
                {
                    Matrix m = Matrix.getScale(-1, 1, 1);
                    Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
                    Draw(polyhedrons[polyhedrons.Count - 1]);
                }
                else if (comboBox5.SelectedItem.ToString() == "Oxz")
                {
                    Matrix m = Matrix.getScale(1, -1, 1) ;
                    Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, m);
                    Draw(polyhedrons[polyhedrons.Count - 1]);
                }
            }
        }
    }
}
