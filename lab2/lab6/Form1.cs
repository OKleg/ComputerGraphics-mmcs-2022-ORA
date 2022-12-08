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
        private void Draw()
        {
            List<Vector> sceneVertices = new List<Vector>();
            sceneVertices = polyhedrons[0].vertices;
            var edges = polyhedrons[0].edges;
            AffineMatrix m = new AffineMatrix();
            
            sceneVertices = m.Scale(sceneVertices, 200, 200, 200);
           // sceneVertices =  m.Translation(sceneVertices, pictureBox1.Width/2, pictureBox1.Height/2, 0);
            foreach (var e in edges)
            {
                g.DrawLine(pen,
                    sceneVertices[e.p1].x,
                    sceneVertices[e.p1].y,
                    sceneVertices[e.p2].x,
                    sceneVertices[e.p2].y);
            }
           pictureBox1.Invalidate();
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Куб")
            {
                List<Vector> vertices = new List<Vector>();
                vertices.Add(new Vector(-100,  100,  100)); // 0 вершина
                vertices.Add(new Vector(-100,  100, -100)); // 1 вершина
                vertices.Add(new Vector( 100,  100, -100)); // 2 вершина
                vertices.Add(new Vector(100, 100, 100)); // 3 вершина
                vertices.Add(new Vector(-100, -100, 100)); // 4 вершина
                vertices.Add(new Vector(-100, -100, -100)); // 5 вершина
                vertices.Add(new Vector(100, -100, -100)); // 6 вершина
                vertices.Add(new Vector(100, -100, 100)); // 7 вершина
                List<Edge> edges = new List<Edge>{
                    new Edge(0, 1),
                    new Edge(1, 2),
                    new Edge(2, 3),
                    new Edge(3, 0),

                    new Edge(0, 4),
                    new Edge(1, 5),
                    new Edge(2, 6),
                    new Edge(3, 7),

                    new Edge(4, 4),
                    new Edge(5, 5),
                    new Edge(6, 6),
                    new Edge(7, 7),
                };
                polyhedrons.Add(new Polyhedron(vertices, edges));
                Draw();

            }
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar2.Value.ToString();
        }
    }
}
