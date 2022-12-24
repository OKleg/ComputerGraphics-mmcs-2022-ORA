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

        Dictionary<String,Polyhedron> polyhedrons;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
            polyhedrons = new Dictionary<String,Polyhedron>();
            SelectedItemBox = comboBox1.SelectedItem.ToString();
            Generatrix = new List<Vector>(); // образующая
            presCount = 0;
        }
        private void Draw(Polyhedron polyhedron)
        {
            g.Clear(Color.White);
            List<Edge> edges = polyhedron.edges;
            //AffineMatrix m = new AffineMatrix();
            List<Vector> sceneVertices = new List<Vector>(polyhedron.vertices);

            if (comboBox4.SelectedIndex == 0)
            {
                Matrix.Transform(sceneVertices,
                    Matrix.getPerspectiveProjection(
                        90, pictureBox1.Width / pictureBox1.Height,
                        -1, -1000) * Matrix.getView(new Vector(0, 0, 100), new Vector(0, 0, -1), new Vector(0, -1, 0)));
            }
            else Matrix.Transform(sceneVertices, Matrix.getIsometricProjection());

            //  Matrix matr = Matrix.getTranslation(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
            //  Matrix.Transform(sceneVertices, matr);
            /*  g.DrawLine(penX,
                      *
            sceneVertices[sceneVertices.Count - 1].x,
                      sceneVertices[sceneVertices.Count - 1].y,
                      sceneVertices[sceneVertices.Count - 1].x + 150,
                      sceneVertices[sceneVertices.Count - 1].y);
              g.DrawLine(penY,
                      sceneVertices[sceneVertices.Count - 1].x,
                      sceneVertices[sceneVertices.Count - 1].y,
                      sceneVertices[sceneVertices.Count - 1].x,
                      sceneVertices[sceneVertices.Count - 1].y - 150);
              Vector zVector = new Vector(-1, 1, 0);
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
                     sceneVertices[e.p1].x + pictureBox1.Width / 2,
                     sceneVertices[e.p1].y + pictureBox1.Height / 2,
                     sceneVertices[e.p2].x + pictureBox1.Width / 2,
                     sceneVertices[e.p2].y + pictureBox1.Height / 2);
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

                Draw(polyhedrons[polyhedrons.Count - 1]);*//*
                if (!polyhedrons.ContainsKey(comboBox1.SelectedItem.ToString()))
                {
                    polyhedrons.Add(new Cube());
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Тетраэдр")
            {
                polyhedrons.Add(new Tetrahedron());
                Draw(polyhedrons[polyhedrons.Count - 1]);
            }
            else if (comboBox1.SelectedItem.ToString() == "Пирамида")
            {
                polyhedrons.Add(new Pyramid());
                Draw(polyhedrons[polyhedrons.Count - 1]);
            }
            else if (comboBox1.SelectedItem.ToString() == "Октаэдр")
            {
                polyhedrons.Add(new Octahedron());
                Draw(polyhedrons[polyhedrons.Count - 1]);
            }
            
            else if (comboBox1.SelectedItem.ToString() == "Додекаэдр*")
            {
                polyhedrons.Add(new Dodecahedron());
                Draw(polyhedrons[polyhedrons.Count - 1]);
            }
            else if (comboBox1.SelectedItem.ToString() == "Икосаэдр*")
            {
                polyhedrons.Add(new Icosahedron());
                Draw(polyhedrons[polyhedrons.Count - 1]);
            }*/
           /* else
            {
                polyhedrons.Add(new Polyhedron());
                Draw(polyhedrons[polyhedrons.Count - 1]);
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
           // SetZero(sceneVertices,out dx, out dy, out dz);
            Matrix.Transform(sceneVertices, m);
           // ReSetZero(sceneVertices, dx,  dy,  dz);
            Draw(new Polyhedron(sceneVertices, polyhedrons[SelectedItemBox].edges));

        }
         private void trackBarOY_Scroll(object sender, EventArgs e)
        {
            labelOY.Text = trackBarOX.Value.ToString();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[SelectedItemBox].vertices);
            Matrix m = Matrix.getRotationY(trackBarOX.Value);
            float dx, dy, dz;
          //  SetZero(sceneVertices, out dx, out dy, out dz);
            Matrix.Transform(sceneVertices, m);
           // ReSetZero(sceneVertices, dx, dy, dz);
            Draw(new Polyhedron(sceneVertices, polyhedrons[SelectedItemBox].edges));
        }
       
        private void trackBarOZ_Scroll(object sender, EventArgs e)
        {
            labelOZ.Text = trackBarOZ.Value.ToString();
            List<Vector> sceneVertices = new List<Vector>(polyhedrons[SelectedItemBox].vertices);
            Matrix m = Matrix.getRotationZ(trackBarOZ.Value);
            float dx, dy, dz;
         //SetZero(sceneVertices, out dx, out dy, out dz);
            Matrix.Transform(sceneVertices, m);
         // ReSetZero(sceneVertices, dx, dy, dz);
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

        private void trackBarOX_MouseUp(object sender, MouseEventArgs e)
        {
            /*  AffineMatrix m = new AffineMatrix();
              m.Rotate(polyhedrons[SelectedItemBox].vertices, trackBar2.Value, trackBar1.Value,  0);*/
            Matrix m = Matrix.getRotationX(trackBarOY.Value);
            float dx, dy, dz;
         //SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
         // ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);

            Draw(polyhedrons[SelectedItemBox]);
            trackBarOY.Value = 0;
            labelOX.Text = trackBarOY.Value.ToString();
        }
        private void trackBarOY_MouseUp(object sender, MouseEventArgs e)
        {
            // AffineMatrix m = new AffineMatrix();
            // m.Rotate(polyhedrons[polyhedrons.Count - 1].vertices, trackBar2.Value, trackBar1.Value,  0);
            Matrix m = Matrix.getRotationY(trackBarOX.Value);
            float dx, dy, dz;
         //SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
         // ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);

            Draw(polyhedrons[SelectedItemBox]);
            trackBarOX.Value = 0;
            labelOY.Text = trackBarOX.Value.ToString();
        }
        private void trackBarOZ_MouseUp(object sender, MouseEventArgs e)
        {
            Matrix m = Matrix.getRotationZ(trackBarOZ.Value);
            float dx, dy, dz;
         //SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
            // ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);

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

                // Matrix.Transform(polyhedrons[polyhedrons.Count - 1].vertices, mat1 * mat2 * mat3 * mat4 * mat5);
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
         //SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
         // ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);
            Draw(polyhedrons[SelectedItemBox]);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Matrix m = Matrix.getScale(0.5f, 0.5f, 0.5f);
            float dx, dy, dz;
         //SetZero(polyhedrons[polyhedrons.Count - 1].vertices, out dx, out dy, out dz);
            Matrix.Transform(polyhedrons[SelectedItemBox].vertices, m);
         // ReSetZero(polyhedrons[polyhedrons.Count - 1].vertices, dx, dy, dz);
            Draw(polyhedrons[SelectedItemBox]);
        }

        
        //Смещение
        private void button4_Click(object sender, EventArgs e)
        {
            if (hx.Text!="" && hy.Text != "" && hz.Text != "" )
            {
                /* AffineMatrix m = new AffineMatrix();
                 m.Translation(polyhedrons[polyhedrons.Count - 1].vertices,int.Parse(hx.Text), int.Parse(hy.Text), int.Parse(hz.Text));
              */ //  Draw(polyhedrons[polyhedrons.Count - 1]);
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
    }
}
