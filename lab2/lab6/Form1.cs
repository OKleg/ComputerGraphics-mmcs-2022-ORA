using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;

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
        String SelectedItemBox;
        List<Vector> Generatrix;
        int presCount;

        Vector cameraPos = new Vector(0, 0, 100);
        Vector cameraDirection = new Vector(0, 0, -1);

        Dictionary<String, Polyhedron> polyhedrons;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            polyhedrons = new Dictionary<String, Polyhedron>();
            SelectedItemBox = comboBox1.SelectedItem.ToString();
            Generatrix = new List<Vector>(); // образующая
            presCount = 0;
        }
        private bool isVisible(Vector v1, Vector v2, Vector v3)
        {
            var eye = v1 - cameraPos;
            Vector t1 = v1 - v2;
            Vector t2 = v3 - v2;
            Vector normal = Vector.cross(t1, t2).normalize();
            float res = Vector.scalar(eye, normal);
            return res > 0; 
        }
        //----------/ BresenhamLineGradientForEdge ==== GradientLeftRight \---------------
        private class GradientLeftRight
        {
            public int left_x;
            public int right_x;
            public Color left_Color;
            public Color right_Color;

            public GradientLeftRight(int left_x, int right_x, Color left_Color, Color right_Color)
            {
                this.left_x = left_x;
                this.right_x = right_x;
                this.left_Color = left_Color;
                this.right_Color = right_Color;
            }
        }

        private void BresenhamLineGradientForEdge(Point p1, Point p2, Color clr1, Color clr2, Dictionary<int, GradientLeftRight> dict)
        {
            if (p1 == p2) return;
            var bmp = (pictureBox1.Image as Bitmap);
            //Color color = Color.Black;          
            //delta
            int dx = Math.Abs(p2.X - p1.X);
            int dy = Math.Abs(p2.Y - p1.Y);

            //signs, to where go
            int sx = p1.X < p2.X ? 1 : -1;
            int sy = p1.Y < p2.Y ? 1 : -1;

            int err = (dx > dy ? dx : -dy) / 2;
            int e2;

            Point pt = p1;

            //Count steps
            int steps = 0;
            while (pt.X != p2.X || pt.Y != p2.Y)
            {
                steps++;
                e2 = err;
                if (e2 > -dx)
                {
                    err -= dy;
                    pt.X += sx;
                }
                if (e2 < dy)
                {
                    err += dx;
                    pt.Y += sy;
                }
            }

            int step = 0;
            while (p1.X != p2.X || p1.Y != p2.Y)
            {
                Color clr;
                clr = Color.FromArgb(clr1.R + (clr2.R - clr1.R) * step / steps, clr1.G + (clr2.G - clr1.G) * step / steps, clr1.B + (clr2.B - clr1.B) * step / steps);
                if (dict.ContainsKey(p1.Y))
                {
                    if (dict[p1.Y].left_x > p1.X)
                    {
                        dict[p1.Y].left_x = p1.X;
                        dict[p1.Y].left_Color = clr;
                    }
                    if (dict[p1.Y].right_x < p1.X)
                    {
                        dict[p1.Y].right_x = p1.X;
                        dict[p1.Y].right_Color = clr;
                    }

                }
                else
                    dict.Add(p1.Y, new GradientLeftRight(p1.X, p1.X, clr, clr));
                step++;

                bmp.SetPixel(p1.X, p1.Y, clr);
                pictureBox1.Invalidate();
                e2 = err;
                if (e2 > -dx)
                {
                    err -= dy;
                    p1.X += sx;
                }
                if (e2 < dy)
                {
                    err += dx;
                    p1.Y += sy;
                }
            }
        }
        //-------------\=====================================================/-----------------
        private void BresenhamLineGradient(Point p1, Point p2, Color clr1, Color clr2)
        {
            if (p1 == p2)
                return;
            var bmp = (pictureBox1.Image as Bitmap);
            //Color color = Color.Black;          
            //delta
            int dx = Math.Abs(p2.X - p1.X);
            int dy = Math.Abs(p2.Y - p1.Y);

            //signs, to where go
            int sx = p1.X < p2.X ? 1 : -1;
            int sy = p1.Y < p2.Y ? 1 : -1;

            int err = (dx > dy ? dx : -dy) / 2;
            int e2;

            Point pt = p1;

            //Count steps
            int steps = 0;
            while (pt.X != p2.X || pt.Y != p2.Y)
            {
                steps++;
                e2 = err;
                if (e2 > -dx)
                {
                    err -= dy;
                    pt.X += sx;
                }
                if (e2 < dy)
                {
                    err += dx;
                    pt.Y += sy;
                }
            }

            int step = 0;
            while (p1.X != p2.X || p1.Y != p2.Y)
            {
                Color clr;
                clr = Color.FromArgb(clr1.R + (clr2.R - clr1.R) * step / steps, clr1.G + (clr2.G - clr1.G) * step / steps, clr1.B + (clr2.B - clr1.B) * step / steps);
                bmp.SetPixel(p1.X, p1.Y, clr);
                pictureBox1.Invalidate();
                e2 = err;
                if (e2 > -dx)
                {
                    err -= dy;
                    p1.X += sx;
                }
                if (e2 < dy)
                {
                    err += dx;
                    p1.Y += sy;
                }

                step++;
            }
        }
        private void RastrTriangle(Point p1, Point p2, Point p3, Color c1, Color c2, Color c3)
        {
            Dictionary<int, GradientLeftRight> dict = new Dictionary<int, GradientLeftRight>();
            BresenhamLineGradientForEdge(p1, p2, c1, c2, dict);
            BresenhamLineGradientForEdge(p1, p3, c1, c3, dict);
            BresenhamLineGradientForEdge(p2, p3, c2, c3, dict);

            foreach (var t in dict)
            {
                int y = t.Key;
                Point pt1 = new Point(t.Value.left_x, y);
                Point pt2 = new Point(t.Value.right_x, y);
                BresenhamLineGradient(pt1, pt2, t.Value.left_Color, t.Value.right_Color);
            }
        }

        private void MyDrawLine(Pen pen, Vector P0, Vector P1)
        {
            color = pen.Color;
            var bmp = (pictureBox1.Image as Bitmap);
            var a = (P1.y - P0.y) / (P1.x - P0.x);
            var b = P0.y - a * P0.x;
            for (var x = P0.x; x < P1.x; x += Polyhedron.eps)
            {
                var y = a * x + b;
                bmp.SetPixel((int)x, (int)y, color);
            }
        }
        private void MyDrawLine(Pen pen,float x0, float x1, float y0, float y1, Bitmap bmp)
        {
            color = pen.Color;
            
            float a = (y1 - y0) / (x1 - x0);
            float b = y0 - a * x0;
            for (var x = x0; x < x1; x += Polyhedron.eps)
            {
                float y = a * x + b;
                bmp.SetPixel((int)x, (int)y, color);

            };
        }
        public virtual void DrawTriangles(Face face)
        {
               Point p0 = new Point((int)face.getPoint(0).x, (int)face.getPoint(0).y);
                Point p1 = new Point((int)face.getPoint(1).x, (int)face.getPoint(1).y);
                Point p2 = new Point((int)face.getPoint(2).x, (int)face.getPoint(2).y);
               
               
                Color c0 = face.getPoint(0).color;
                Color c1 = face.getPoint(1).color;
                Color c2 = face.getPoint(2).color;
               
                //треугольная грань
                if (face.points.Count == 3)
                {
             

                RastrTriangle( p0, p1, p2,c0,c1,c2);
                }

                //четырехугольная грань
                else if (face.points.Count == 4)
                {
                Point p3 = new Point((int)face.getPoint(3).x, (int)face.getPoint(3).y);
                Color c3 = face.getPoint(3).color;
                RastrTriangle(p0, p1, p3,c0,c1,c3);
                RastrTriangle(p1, p2, p3, c1, c2, c3);
                }
                //четырехугольная грань
                else if (face.points.Count == 5)
                { 
                Point p4 = new Point((int)face.getPoint(4).x, (int)face.getPoint(4).y);
                Color c4 = face.getPoint(4).color;
                Point p3 = new Point((int)face.getPoint(3).x, (int)face.getPoint(3).y);
                Color c3 = face.getPoint(3).color;
                RastrTriangle(  p0, p1, p3, c0,   c1,   c3);
                RastrTriangle(  p1, p2, p3, c1,   c2,   c3);
                RastrTriangle(  p0, p3, p4, c0,   c3,   c4);
                } 
        }
        private void Draw(Polyhedron polyhedron)
        {
            g.Clear(Color.White);
            var bmp = (pictureBox1.Image as Bitmap);
            List<Face> faces = polyhedron.faces;
            List<Vector> sceneVertices = new List<Vector>(polyhedron.vertices);
          
            if (comboBox4.SelectedIndex == 0)
            {
                Matrix.Transform(sceneVertices,
                    Matrix.getPerspectiveProjection(
                        90, pictureBox1.Width / pictureBox1.Height,
                        -1, -1000) * Matrix.getView(cameraPos, cameraDirection, new Vector(0, -1, 0)));
            }
            else Matrix.Transform(sceneVertices, Matrix.getIsometricProjection());
            foreach (var face in faces)
            {
                if (isVisible(face.getPoint(0), face.getPoint(1), face.getPoint(face.points.Count-1)))
                {
                    foreach (var e in face.edges)
                    {
                        if (e.p1 == 0 || e.p2 == 0)
                        {
                            pen = new Pen(Color.Red);
                        }
                        else if (e.p1 == 6 || e.p2 == 6)
                        {
                            pen = new Pen(Color.Blue);
                        }
                        else pen = new Pen(color);
                        g.DrawLine(
                             //// MyDrawLine(
                              pen,
                             sceneVertices[e.p1].x + pictureBox1.Width / 2,
                             sceneVertices[e.p1].y + pictureBox1.Height / 2,
                             sceneVertices[e.p2].x + pictureBox1.Width / 2,
                             sceneVertices[e.p2].y + pictureBox1.Height / 2
                             //// , bmp
                             );

                        // DrawTriangles(face);
                    }
                }
            }
            pictureBox1.Invalidate();
        }
       private void SetZero(List<Vector> v, out float dx,out float  dy,out float dz)
        {
            dx = polyhedrons[SelectedItemBox].vertices.Last().x;
            dy = polyhedrons[SelectedItemBox].vertices.Last().y;
            dz = polyhedrons[SelectedItemBox].vertices.Last().z;

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
            (A.Enabled, B.Enabled, C.Enabled, tBoxl.Enabled, tBoxm.Enabled, tBoxn.Enabled)
               = (true, true, true, true, true, true);
            String ModelName = comboBox1.SelectedItem.ToString();

            TryAddNewModel(ModelName);

            /*if (comboBox1.SelectedItem.ToString() == "Гексаэдр")
            {
                *//*polyhedrons.Add(new Cube());

                Draw(polyhedrons[SelectedItemBox]);*//*
                if (!polyhedrons.ContainsKey(comboBox1.SelectedItem.ToString()))
                {
                    polyhedrons.Add(new Cube());
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Тетраэдр")
            {
                polyhedrons.Add(new Tetrahedron());
                Draw(polyhedrons[SelectedItemBox]);
            }
            else if (comboBox1.SelectedItem.ToString() == "Пирамида")
            {
                polyhedrons.Add(new Pyramid());
                Draw(polyhedrons[SelectedItemBox]);
            }
            else if (comboBox1.SelectedItem.ToString() == "Октаэдр")
            {
                polyhedrons.Add(new Octahedron());
                Draw(polyhedrons[SelectedItemBox]);
            }
            
            else if (comboBox1.SelectedItem.ToString() == "Додекаэдр*")
            {
                polyhedrons.Add(new Dodecahedron());
                Draw(polyhedrons[SelectedItemBox]);
            }
            else if (comboBox1.SelectedItem.ToString() == "Икосаэдр*")
            {
                polyhedrons.Add(new Icosahedron());
                Draw(polyhedrons[SelectedItemBox]);
            }*/
           /* else
            {
                polyhedrons.Add(new Polyhedron());
                Draw(polyhedrons[SelectedItemBox]);
            }*/

        }

        private void TryAddNewModel(string modelName)
        {
            switch (modelName)
            {
                case "Гексаэдр":
                    if (!polyhedrons.ContainsKey(modelName))
                        polyhedrons.Add(modelName, new Cube());
                    Draw(polyhedrons[modelName]); 
                    break;
                case "Тетраэдр":
                    if (!polyhedrons.ContainsKey(modelName))
                        polyhedrons.Add(modelName, new Tetrahedron());
                    Draw(polyhedrons[modelName]);
                    break;
                case "Пирамида":
                    if (!polyhedrons.ContainsKey(modelName))
                        polyhedrons.Add(modelName, new Pyramid());
                    Draw(polyhedrons[modelName]);
                    break;
                case "Октаэдр":
                    if (!polyhedrons.ContainsKey(modelName))
                        polyhedrons.Add(modelName, new Octahedron());
                    Draw(polyhedrons[modelName]);
                    break;
                case "Додекаэдр*":
                    if (!polyhedrons.ContainsKey(modelName))
                        polyhedrons.Add(modelName, new Dodecahedron());
                    Draw(polyhedrons[modelName]);
                    break;
                case "Икосаэдр*":
                    if (!polyhedrons.ContainsKey(modelName))
                        polyhedrons.Add(modelName, new Icosahedron());
                    Draw(polyhedrons[modelName]);
                    break;
                default:
                    if (!polyhedrons.ContainsKey(modelName))
                        polyhedrons.Add(modelName, new Polyhedron());
                    Draw(polyhedrons[modelName]);
                    break;
            }
            SelectedItemBox = modelName;
        }

        private void trackBarOX_Scroll(object sender, EventArgs e)
        {
            labelOX.Text = trackBarOY.Value.ToString();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[SelectedItemBox].vertices);
            Matrix m = Matrix.getRotationX(trackBarOY.Value);
            float dx, dy, dz;
            SetZero(sceneVertices,out dx, out dy, out dz);
            Matrix.Transform(sceneVertices, m);
            ReSetZero(sceneVertices, dx,  dy,  dz);
            Draw(new Polyhedron(sceneVertices, polyhedrons[SelectedItemBox].edges));

        }
        private void trackBarOX_MouseUp(object sender, MouseEventArgs e)
        {
            Matrix m = Matrix.getRotationX(trackBarOY.Value);
            float dx, dy, dz;
            SetZero(polyhedrons[SelectedItemBox].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
            ReSetZero(polyhedrons[SelectedItemBox].vertices, dx, dy, dz);

            Draw(polyhedrons[SelectedItemBox]);
            trackBarOY.Value = 0;
            labelOX.Text = trackBarOY.Value.ToString();
        }
         private void trackBarOY_Scroll(object sender, EventArgs e)
        {
            labelOY.Text = trackBarOX.Value.ToString();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[SelectedItemBox].vertices);
            Matrix m = Matrix.getRotationY(trackBarOX.Value);
            float dx, dy, dz;
            SetZero(sceneVertices, out dx, out dy, out dz);
            Matrix.Transform(sceneVertices, m);
            ReSetZero(sceneVertices, dx, dy, dz);
            Draw(new Polyhedron(sceneVertices, polyhedrons[SelectedItemBox].edges));
        }
       
        private void trackBarOZ_Scroll(object sender, EventArgs e)
        {
            labelOZ.Text = trackBarOZ.Value.ToString();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[SelectedItemBox].vertices);
            Matrix m = Matrix.getRotationZ(trackBarOZ.Value);
            float dx, dy, dz;
            SetZero(sceneVertices, out dx, out dy, out dz);
            Matrix.Transform(sceneVertices, m);
            ReSetZero(sceneVertices, dx, dy, dz);
            Draw(new Polyhedron(sceneVertices, polyhedrons[SelectedItemBox].edges));
        }  
        private void trackBarL_Scroll(object sender, EventArgs e)
        {
            if (A.Text != "" && B.Text != "" && C.Text != "" &&
                tBoxl.Text != "" && tBoxm.Text != "" && tBoxn.Text != ""    )
            {

                labelL.Text = trackBarL.Value.ToString();
                List<Vector> sceneVertices = new List<Vector>(polyhedrons[SelectedItemBox].vertices);
                float a = float.Parse(A.Text);
                float b = float.Parse(B.Text);
                float c = float.Parse(C.Text);
                float l = float.Parse(tBoxl.Text);
                float m = float.Parse(tBoxm.Text);
                float n = float.Parse(tBoxn.Text);

                /*Matrix mat1 = Matrix.getTranslation(-a, -b, -c);
                Matrix mat2 = Matrix.getСonvergingLtoZ(l, m, n);
                Matrix mat3 = Matrix.getRotationZ(trackBarL.Value);
                Matrix mat4 = Matrix.getСonvergingLtoZ(-l, -m, -n);
                Matrix mat5 = Matrix.getTranslation(a, b, c);*/

                //Matrix.Transform(sceneVertices, mat1*mat2*mat3*mat4*mat5);
                Vector v1 = new Vector(a, b, c);
                Vector v2 = new Vector(l, m, n);

                Matrix.Transform(sceneVertices,Matrix.getRotateL(v1,v2, trackBarL.Value));
                Draw(new Polyhedron(sceneVertices, polyhedrons[SelectedItemBox].edges));
            }
        }

       
        private void trackBarOY_MouseUp(object sender, MouseEventArgs e)
        {
            // AffineMatrix m = new AffineMatrix();
            // m.Rotate(polyhedrons[SelectedItemBox].vertices, trackBar2.Value, trackBar1.Value,  0);
            Matrix m = Matrix.getRotationY(trackBarOX.Value);
            float dx, dy, dz;
            SetZero(polyhedrons[SelectedItemBox].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
            ReSetZero(polyhedrons[SelectedItemBox].vertices, dx, dy, dz);

            Draw(polyhedrons[SelectedItemBox]);
            trackBarOX.Value = 0;
            labelOY.Text = trackBarOX.Value.ToString();
        }
        private void trackBarOZ_MouseUp(object sender, MouseEventArgs e)
        {
            Matrix m = Matrix.getRotationZ(trackBarOZ.Value);
            float dx, dy, dz;
            SetZero(polyhedrons[SelectedItemBox].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
            ReSetZero(polyhedrons[SelectedItemBox].vertices, dx, dy, dz);

            Draw(polyhedrons[SelectedItemBox]);
            trackBarOZ.Value = 0;
            labelOZ.Text = trackBarOZ.Value.ToString();
        }
      
        private void trackBarL_MouseUp(object sender, MouseEventArgs e)
        {
            if (A.Text != "" && B.Text != "" && C.Text != "" &&
               tBoxl.Text != "" && tBoxm.Text != "" && tBoxn.Text != "")
            {
                float a = float.Parse(A.Text);
                float b = float.Parse(B.Text);
                float c = float.Parse(C.Text);
                float l = float.Parse(tBoxl.Text);
                float m = float.Parse(tBoxm.Text);
                float n = float.Parse(tBoxn.Text);
                g.DrawLine(Pens.Beige, a-1000, b-1000, l+1000, m+1000);
                Matrix mat1 = Matrix.getTranslation(-a, -b, -c);
                Matrix mat2 = Matrix.getСonvergingLtoZ(l, m, n);
                Matrix mat3 = Matrix.getRotationZ(trackBarL.Value);
                Matrix mat4 = Matrix.getСonvergingLtoZ(-l, -m, -n);
                Matrix mat5 = Matrix.getTranslation(a, b, c);

                // Matrix.Transform(polyhedrons[SelectedItemBox].vertices, mat1 * mat2 * mat3 * mat4 * mat5);
                Vector v1 = new Vector(a, b, c);
                Vector v2 = new Vector(l, m, n);
                Matrix.Transform(polyhedrons[SelectedItemBox].vertices, Matrix.getRotateL(v1,v2, trackBarL.Value));
                Draw(polyhedrons[SelectedItemBox]);
                trackBarL.Value = 0;
                labelL.Text = trackBarL.Value.ToString();
            }
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
         //SetZero(polyhedrons[SelectedItemBox].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
         // ReSetZero(polyhedrons[SelectedItemBox].vertices, dx, dy, dz);
            Draw(polyhedrons[SelectedItemBox]);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Matrix m = Matrix.getScale(0.5f, 0.5f, 0.5f);
            float dx, dy, dz;
         //SetZero(polyhedrons[SelectedItemBox].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
         // ReSetZero(polyhedrons[SelectedItemBox].vertices, dx, dy, dz);
            Draw(polyhedrons[SelectedItemBox]);
        }

        
        //Смещение
        private void button4_Click(object sender, EventArgs e)
        {
            if (hx.Text!="" && hy.Text != "" && hz.Text != "" )
            {
                /* AffineMatrix m = new AffineMatrix();
                 m.Translation(polyhedrons[SelectedItemBox].vertices,int.Parse(hx.Text), int.Parse(hy.Text), int.Parse(hz.Text));
              */ //  Draw(polyhedrons[SelectedItemBox]);
                Matrix m = Matrix.getTranslation(-int.Parse(hx.Text), int.Parse(hy.Text), int.Parse(hz.Text));
                Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
                Draw(polyhedrons[SelectedItemBox]);
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
                    Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
                    Draw(polyhedrons[SelectedItemBox]);
                }
                else if (comboBox5.SelectedItem.ToString() == "Oyz")
                {
                    Matrix m = Matrix.getScale(-1, 1, 1);
                    Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
                    Draw(polyhedrons[SelectedItemBox]);
                }
                else if (comboBox5.SelectedItem.ToString() == "Oxz")
                {
                    Matrix m = Matrix.getScale(1, -1, 1) ;
                    Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
                    Draw(polyhedrons[SelectedItemBox]);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (polyhedrons.Count >0) 
                Draw(polyhedrons[SelectedItemBox]);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SvFileDialog = new SaveFileDialog())
            {
                if (SvFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fname = SvFileDialog.FileName;
                    //var options = new JsonSerializerOptions { WriteIndented = true };
                    //string jsonString = JsonSerializer.Serialize<Polyhedron>(polyhedrons[SelectedItemBox], Formatting.Indented);
                    //File.WriteAllText(fname, JsonSerializer.Serialize(polyhedrons[SelectedItemBox]));
                    File.WriteAllText(fname, JsonConvert.SerializeObject(polyhedrons[SelectedItemBox]));
                }
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpFileDialog = new OpenFileDialog() )
            {
                if (OpFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                string fname = OpFileDialog.FileName;
                string fn = Path.GetFileName(fname);
                Polyhedron tmp = JsonConvert.DeserializeObject<Polyhedron>(File.ReadAllText(fname));
                polyhedrons.Add(fn, tmp);
                SelectedItemBox = fn;
                comboBox1.Items.Add(fn);
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                (hx.Enabled, hy.Enabled, hz.Enabled, button4.Enabled)
                = (true, true, true, true);
                (A.Enabled, B.Enabled, C.Enabled, tBoxl.Enabled, tBoxm.Enabled, tBoxn.Enabled)
                   = (true, true, true, true, true, true);
                Draw(polyhedrons[SelectedItemBox]);
            }
        }

        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            float x = float.Parse(InputPointX.Text);
            float y = float.Parse(InputPointY.Text);
            float z = float.Parse(InputPointZ.Text);

            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;

            Generatrix.Add(new Vector(x, y, z));

            for (int i = 1; i < Generatrix.Count; i++)
            {
                g.DrawLine(pen, 
                     CenterX + Generatrix[i - 1].x, CenterY + Generatrix[i - 1].y,
                     CenterX + Generatrix[i].x, CenterY + Generatrix[i].y);
            }
            pictureBox1.Invalidate();
        }

        private void DrawRotateModelBtn_Click(object sender, EventArgs e)
        {
            presCount += 1;
            int SplitRotateCount = int.Parse(SplitCountBox.Text);
            string RotateAxis = RotateAxisSelector.Text;
            if (Generatrix.Count > 1)
            {
                RotateFigure RF = new RotateFigure(Generatrix, SplitRotateCount, RotateAxis);
                polyhedrons.Add("rotateF" + presCount.ToString(), RF);
                comboBox1.Items.Add("rotateF" + presCount.ToString());
                SelectedItemBox = "rotateF" + presCount.ToString();
                (hx.Enabled, hy.Enabled, hz.Enabled, button4.Enabled)
                    = (true, true, true, true);
                (A.Enabled, B.Enabled, C.Enabled, tBoxl.Enabled, tBoxm.Enabled, tBoxn.Enabled)
                   = (true, true, true, true, true, true);
                Draw(polyhedrons[SelectedItemBox]);
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                /*using (SaveFileDialog SvFileDialog = new SaveFileDialog())
                {
                    if (SvFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fname = SvFileDialog.FileName;
                        File.WriteAllText(fname, JsonConvert.SerializeObject(RF, Formatting.Indented), Encoding.UTF8);
                    }
                }*/
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            pictureBox1.Invalidate();
            Generatrix.Clear();
        }

        private void LeftGo_Click(object sender, EventArgs e)
        {
            cameraPos = cameraPos +  new Vector(0,0, 0);
            Draw(polyhedrons[SelectedItemBox]);
        }

        private void RightGo_Click(object sender, EventArgs e)
        {
            cameraPos = cameraPos + new Vector(0, 0 , 0);
            Draw(polyhedrons[SelectedItemBox]);
        }
    }
}
