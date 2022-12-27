using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form2 : Form
    {
        public List<Polyhedron> box = new List<Polyhedron>();// список моделей
       
        public Vector[,] coordsPictBox;
        public Vector camera, leftUpCorn, rightUpCorn, leftDownCorn, rightDownCorn;
        public int h, w;

        public Form f1;
        public Form2()
        {
            InitializeComponent();
            h = pictureBox1.Height;
            w = pictureBox1.Width;
            pictureBox1.Image = new Bitmap(w, h);
            colorDialog1.Color = Color.Yellow;
            colorDialog2.Color = Color.Peru;
            buttonColorCube.BackColor = colorDialog1.Color;
            butColorSphere.BackColor = colorDialog2.Color;
            colorDialog3.Color = Color.White;
            camera = new Vector();
            leftUpCorn = new Vector();
            rightUpCorn = new Vector();
            leftDownCorn = new Vector();
            rightDownCorn = new Vector();
        }
        public List<Light> lights = new List<Light>();   // список источников света
        public Color[,] pixelsColor;                    // цвета пикселей для отображения на pictureBox
        private void button1_Click(object sender, EventArgs e)
        {
            //отчищаем
            camera = new Vector();
            leftUpCorn = new Vector();
            rightUpCorn = new Vector();
            leftDownCorn = new Vector();
            rightDownCorn = new Vector();
            h = pictureBox1.Height;
            w = pictureBox1.Width;
            box = new List<Polyhedron>();
            lights = new List<Light>();
            pictureBox1.Image = new Bitmap(w, h);

            // создаём крмнату
            CreateRoom();
            // Применяем обратный рейтрейинг
            BackwardRayTracing();//<--
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    (pictureBox1.Image as Bitmap).SetPixel(i, j, pixelsColor[i, j]);
                }
                pictureBox1.Invalidate();
            }
            //button1.Enabled = false;
            //button3.Enabled = true;
        }

        public void CreateRoom()
        {
            Polyhedron room = new Cube(10);
            // координаты вершин задней? стены
            leftUpCorn = room.faces[0].getPoint(0);
            rightUpCorn = room.faces[0].getPoint(1);
            rightDownCorn = room.faces[0].getPoint(2);
            leftDownCorn = room.faces[0].getPoint(3);

            room.SetPen(new Pen(Color.Gray));
            room.faces[0].pen = new Pen(Color.Magenta);//Color.Green);
            room.faces[1].pen = new Pen(Color.LightGray);
            room.faces[2].pen = new Pen(Color.Green);//Color.CadetBlue);
            room.faces[3].pen = new Pen(Color.OrangeRed);//Color.Red);
            room.faces[4].pen = new Pen(Color.LightGray);
            room.faces[5].pen = new Pen(Color.LightGray);

            room.material = new Material(0.0f, 0, 0.15f, 0.75f);
            
            //камера
            Vector normal = Face.norm(room.faces[0]);                            // нормаль стороны комнаты
            Vector center = (leftUpCorn + rightUpCorn + leftDownCorn + rightDownCorn) / 4;   // центр стороны комнаты
            camera = center + normal * 11;
            box.Add(room);
            Vector colorLight = new Vector(colorDialog3.Color.R, colorDialog3.Color.G, colorDialog3.Color.B);
            //добавляем источники света
            if (checkLight1.Checked)
            { 
                Light l1 = new Light(new Vector(-4.75f, 0f, 0f), new Vector(1, 1, 1));
                lights.Add(l1);
            }
            if (checkLight2.Checked)
            {
                Light l2 = new Light(new Vector(0f, 0f, 4.85f), new Vector(1, 1, 1));
                lights.Add(l2);
            }
            if (checkLight3.Checked)
            {
                Light l3 = new Light(new Vector(0f, 0f, -4.85f), new Vector(1, 1, 1));
                lights.Add(l3);
            }
            if (checkLight4.Checked)
            {
                Light l4 = new Light(new Vector(0f, 4.85f, 0f), new Vector(1, 1, 1));
                lights.Add(l4);
            }
            if (checkShere.Checked)
            {
                Sphere Shpere1 = new Sphere(new Vector(3f, 3f, -3f), 1f);
                Shpere1.SetPen(new Pen(Color.Red));
                Shpere1.color = Color.Red;
                if (radioButton1.Checked)
                {
                    Shpere1.material = new Material(0f, 0f, 0.2f, 0.3f, 1f);
                }
                if (radioSphere1.Checked)
                {
                    Shpere1.material = new Material(0.9f, 0f, 0f, 0.7f, 1f);
                }
                if (radioSphere2.Checked)
                {
                    Shpere1.material = new Material(0.05f, 0.85f, 0f, 0f, 1.05f);
                }
                Shpere1.SetPen(new Pen(colorDialog2.Color));
                // Shpere1.material.color =new Vector(colorDialog2.Color.R, colorDialog2.Color.G, colorDialog2.Color.B);

                box.Add(Shpere1);
            }
           
            if (checkCube.Checked)
            {
                Polyhedron Cube1 = new Cube(3f);
                //Rotate(Cube1.vertices, 20, "X");
                Matrix m = Matrix.getTranslation(3.49f, 0.0f, 2.0f);
                Matrix.Transform(Cube1.vertices, m);
                Cube1.SetPen(new Pen(colorDialog1.Color));
                if (radioButton1.Checked)
                {
                // обычный
                Cube1.material = new Material(0f, 0f, 0.2f, 0.7f, 1.5f);
                }
                if (radioCube1.Checked)
                {
                    //Зеркальное
                    Cube1.material = new Material(0.9f, 0f, 0.05f, 0.3f, 1f);
                }
                if (radioCube2.Checked)
                {
                    //прозрачное
                    Cube1.material = new Material(0.04f, 0.85f, 0.1f, 0.1f, 0.5f); ;
                }
                
                box.Add(Cube1);
            }
            if (checkCube.Checked)
            {
                Polyhedron Cube1 = new Icosahedron(0.7f);
               // Rotate(Cube1.vertices, 20, "X");
                Matrix m = Matrix.getTranslation(0.5f, 0.0f, 2.0f);
                Matrix.Transform(Cube1.vertices, m);
                Cube1.SetPen(new Pen(Color.Red));
                if (radioButton1.Checked)
                {
                    // обычный
                    Cube1.material = new Material(0f, 0f, 0.1f, 0.7f, 1.5f);
                }
                if (radioCube1.Checked)
                {
                    //Зеркальное
                    Cube1.material = new Material(0.9f, 0f, 0.05f, 0.3f, 1.2f);
                }
                if (radioCube2.Checked)
                {
                    //прозрачное
                    Cube1.material = new Material(0.04f, 0.85f, 0.05f, 0.1f, 1.5f); ;
                }

                box.Add(Cube1);
            }
            if (checkOct.Checked)
            {
                Polyhedron Cube1 = new Octahedron(0.7f);
                 Rotate(Cube1.vertices, 90, "Z");
                Rotate(Cube1.vertices, 45, "X");

                Matrix m = Matrix.getTranslation(-4f, 0.0f, 0.0f);
                Matrix.Transform(Cube1.vertices, m);
                Cube1.SetPen(new Pen(Color.Red));
                if (radioButton1.Checked)
                {
                    // обычный
                    Cube1.material = new Material(0f, 0f, 0.1f, 0.7f, 1.5f);
                }
                if (radioOct2.Checked)
                {
                    //Зеркальное
                    Cube1.material = new Material(0.9f, 0f, 0.05f, 0.3f, 1f);
                }
                if (radioOct3.Checked)
                {
                    //прозрачно
                    Cube1.material = new Material(0.04f, 1f, 0.05f, 0.1f, 1.4f); ;
                }

                box.Add(Cube1);
            }
            if (checkRect.Checked)
            {
                Polyhedron Rect = new Cube(3f,6f);
                Rotate(Rect.vertices, 40, "X");
                Matrix m = Matrix.getTranslation(2f, 1f, -2f);

                Matrix.Transform(Rect.vertices, m);
                Rect.SetPen(new Pen(Color.White));
                if (radioRect1.Checked)
                {
                    Rect.material = new Material(0f, 0f, 0.2f, 0.7f, 1.5f);
                }
                if (radioRect2.Checked)
                {
                    Rect.material = new Material(0.95f, 0f, 0.1f, 0.4f, 1.5f);
                }
                if (radioRect3.Checked)
                {
                    Rect.material  = new Material(0.04f, 0.85f, 0.1f, 0.3f, 1.5f);
                }
                box.Add(Rect);
            }
            if (checkRect.Checked)
            {
                Polyhedron Rect = new Dodecahedron(0.8f);
                Rotate(Rect.vertices, 40, "X");
                Matrix m = Matrix.getTranslation(-2.4f, 1f, -2f);

                Matrix.Transform(Rect.vertices, m);
                Rect.SetPen(new Pen(Color.Plum));
                if (radioRect1.Checked)
                {
                    Rect.material = new Material(0f, 0f, 0.1f, 0.7f, 1.5f);
                }
                if (radioRect2.Checked)
                {
                    Rect.material = new Material(0.95f, 0f, 0.05f, 0.4f, 1.5f);
                }
                if (radioRect3.Checked)
                {
                    Rect.material = new Material(0.04f, 0.85f, 0.05f, 0.3f, 1.5f);
                }
                box.Add(Rect);
            }
            if (checkFrontWall.Checked)
            {
                /* Polyhedron wall = new Cube(10f);
                 Matrix m = Matrix.getTranslation(0f, -9.9f, 0.0f);
                 Matrix.Transform(wall.vertices, m);
                 wall.SetPen(new Pen(Color.White));
                 wall.material = new Material(0.95f, 0f, 0.0f, 0.1f);
                 box.Add(wall);*/
                room.faces[1].fMaterial = new Material(0.95f, 0f, 0.0f, 0.1f);
            }
           
            if (checkLeftWall.Checked)
            {
                /*  Polyhedron wall = new Cube(10f);
                  Matrix m = Matrix.getTranslation(0f, 0f, 9.9f);
                  Matrix.Transform(wall.vertices, m);
                  wall.SetPen(new Pen(Color.White));
                  wall.material = new Material(0.95f, 0f, 0.0f, 0.1f);
                  box.Add(wall);*/
                room.faces[2].fMaterial = new Material(0.95f, 0f, 0.0f, 0.1f);
            }
            if (checkRightWall.Checked)
            {
                /*  Polyhedron wall = new Cube(10f);
                  Matrix m = Matrix.getTranslation(0f, 0f, -9.9f);
                  Matrix.Transform(wall.vertices, m);
                  wall.SetPen(new Pen(Color.White));
                  wall.material = new Material(0.95f, 0f, 0.0f, 0.1f);
                  box.Add(wall);*/
                room.faces[2].fMaterial = new Material(0.95f, 0f, 0.0f, 0.1f);
            }

            if (checkBackWall.Checked)
            {
                /* Polyhedron wall1 = new Cube(10f);
                 Polyhedron wall2 = new Cube(10f);
                 Polyhedron wall3 = new Cube(10f);
                 Polyhedron wall4 = new Cube(10f);
                 Polyhedron wall5 = new Cube(10f);
                 Matrix m1 = Matrix.getTranslation(0f, 0f, -9.9f);
                 Matrix m2 = Matrix.getTranslation(0f, 0f, 9.9f);
                 Matrix m3 = Matrix.getTranslation(-9.9f, 0f, 0f);
                 Matrix m4 = Matrix.getTranslation(9.9f, 0f, 0f);
                 Matrix m5 = Matrix.getTranslation(0f, -9.9f, 0f);
                 Matrix.Transform(wall1.vertices, m1);
                 Matrix.Transform(wall2.vertices, m2);
                 Matrix.Transform(wall3.vertices, m3);
                 Matrix.Transform(wall4.vertices, m4);
                 Matrix.Transform(wall5.vertices, m5);

                 wall1.SetPen(new Pen(Color.Green));
                 wall2.SetPen(new Pen(Color.OrangeRed));
                 wall3.SetPen(new Pen(Color.LightGray));
                 wall4.SetPen(new Pen(Color.LightGray));
                 wall5.SetPen(new Pen(Color.LightGray));
                 wall1.material = new Material(0.0f, 0, 0.2f, 0.8f);
                 wall2.material = new Material(0.0f, 0, 0.2f, 0.8f);
                 wall3.material = new Material(0.0f, 0, 0.2f, 0.8f);
                 wall4.material = new Material(0.0f, 0, 0.2f, 0.8f);
                 wall5.material = new Material(0.0f, 0, 0.2f, 0.8f);

                 room.material = new Material(0.95f, 0f, 0.0f, 0.1f);*/
                /*   box.Add(wall1);
                   box.Add(wall2);
                   box.Add(wall3);
                   box.Add(wall4);
                   box.Add(wall5);*/
                room.faces[0].fMaterial = new Material(0.95f, 0f, 0.0f, 0.1f);
            }



        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            camera = new Vector();
            leftUpCorn = new Vector();
            rightUpCorn = new Vector();
            leftDownCorn = new Vector();
            rightDownCorn = new Vector();
            h = pictureBox1.Height;
            w = pictureBox1.Width;
            pictureBox1.Image = new Bitmap(w, h);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            camera = new Vector();
            leftUpCorn = new Vector();
            rightUpCorn = new Vector();
            leftDownCorn = new Vector();
            rightDownCorn = new Vector();
            h = pictureBox1.Height;
            w = pictureBox1.Width;
            pictureBox1.Image = new Bitmap(w, h);
        }

        public void BackwardRayTracing()
        {
            /// Получение координат всех пикселей сцены
            BoxCoords();
            
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    Ray r = new Ray(camera, coordsPictBox[i, j]);
                    r.start = new Vector(coordsPictBox[i, j]);
                    Vector color = RayTrace(r, 20, 1);//луч,кол-во итераций,коэфф
                    if (color.x > 1.0f || color.y > 1.0f || color.z > 1.0f)
                        color = Vector.normalize(color);
                    pixelsColor[i, j] = Color.FromArgb((int)(255 * color.x), (int)(255 * color.y), (int)(255 * color.z));
                }
            }
        }

        /// Получение координат всех пикселей сцены
        public void BoxCoords()
        {
            coordsPictBox = new Vector[w, h];
            pixelsColor = new Color[w, h];
            Vector width = (rightUpCorn - leftUpCorn) / (w - 1);//отношение ширины комнаты к ширине экрана
            Vector heigth = (rightDownCorn - leftDownCorn) / (h - 1);//отношение высоты комнаты к высоте экрана
            (Vector startUp, Vector startDown) = (new Vector(leftUpCorn),new Vector(leftDownCorn));

            for (int i = 0; i < w; i++)
            {
                Vector d = new Vector(startDown);
                for (int j = 0; j < h; ++j)
                {
                    coordsPictBox[i, j] = d;
                    d += (startUp - startDown) / (h - 1);
                }
                startUp += width;//++
                startDown += heigth;//++
            }
        }

        //Видимость пересечения луча с объектом из источника света
        public bool IsVisible(Vector light, Vector point)
        {
            Ray r = new Ray(point, light);
            foreach (Polyhedron poly in box)
                if (poly.isIntersection(r, out float insect, out Vector n, out Face outFace))
                    //
                    if (insect < (light - point).length() && insect > Polyhedron.eps)
                        return false;
            return true;
        }

        private void buttonColorCube_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColorCube.BackColor = colorDialog1.Color;
        }

        private void butColorSphere_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
           // butColorSphere.BackColor = colorDialog2.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            camera = new Vector();
            leftUpCorn = new Vector();
            rightUpCorn = new Vector();
            leftDownCorn = new Vector();
            rightDownCorn = new Vector();
            h = pictureBox1.Height;
            w = pictureBox1.Width;
            box = new List<Polyhedron>();
            lights = new List<Light>();
            pictureBox1.Image = new Bitmap(w, h);
            button1_Click(sender, e);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            buttonLightColor.BackColor = colorDialog3.Color;
        }

        private void butColorSphere_Click_1(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            butColorSphere.BackColor = colorDialog2.Color;
        }

        private void radioSphere2_CheckedChanged(object sender, EventArgs e)
        {

        }

        public Vector RayTrace(Ray r, int iters, float env)
        {
            if (iters <= 0)  return new Vector(0, 0, 0);
            float intersectRayDist = 0;// дистанция до точки пересечения луча с объектом
            Vector normal = null; //нормаль грани объекта
            Material material = new Material();
            Vector ColorPoint = new Vector(0, 0, 0);
            
            bool refractPoly = false;
            foreach(Polyhedron poly in box) 
            {
                if (poly.isIntersection(r, out float distance, out Vector norm, out Face outFace))
                {     
                    // Выбираем ближайшую модель к началу луча
                    if (distance < intersectRayDist || intersectRayDist == 0)
                    {
                        intersectRayDist = distance;
                        normal = norm;
                        material = ((outFace == null) || (outFace.fMaterial == null)) ? new Material(poly.material) : outFace.fMaterial;
                    }
                }
            }

            if (intersectRayDist == 0)//если не пересекается с фигурой
                return new Vector();//Луч уходит в свободное пространство .Возвращаем значение по умолчанию

            //Если угол между направление луча и нормалью стороны острый
            
            if (Vector.scalar(r.direction, normal) > 0)
            {
                //переход в другую среды
                normal *= -1;
                refractPoly = true;
            }
            //Точка пересечения луча с фигурой
            Vector insectPoint = r.start + r.direction * intersectRayDist;
             
            //1)луч в направлении источника света,
            foreach (Light light in lights)
            {
                //коэффициент принятия фонового освещения - ambient
                Vector kamb = light.ColorL * material.ambient;
                kamb = Vector.multVec(kamb, material.color);
                ColorPoint += kamb;
                // диффузное освещение
                if (IsVisible(light.center, insectPoint))//если точка пересечения луча с объектом видна из источника света
                    ColorPoint += light.Shade(insectPoint, normal, material.color, material.diffuse);
            }
            //2)луч в направлении отражения
            if (material.reflection > 0)
            {
                Ray reflRay = r.Reflect(insectPoint, normal);//луч отражения
                ColorPoint += material.reflection * RayTrace(reflRay, iters - 1, env);
            }

            //3)луч в направлении преломления прозрачной поверхности.
            if (material.refraction > 0)
            {
                //взависимости от того,из какой среды в какую,будет меняться коэффициент приломления
                float refract_coef;
                if (refractPoly)
                    refract_coef = material.environment;
                else
                    refract_coef = 1 / material.environment;

                Ray refractRay = r.Refract(insectPoint, normal, material.refraction, refract_coef);//создаем приломленный луч

                if (refractRay != null)
                    ColorPoint += material.refraction * RayTrace(refractRay, iters - 1, material.environment);
            }
            return ColorPoint;
        }
        private void SetZero(List<Vector> v, out float dx, out float dy, out float dz)
        {
            dx = v.Last().x;
            dy = v.Last().y;
            dz = v.Last().z;

            Matrix.Transform(v, Matrix.getTranslation(-dx, -dy, -dz));
        }
        private void ReSetZero(List<Vector> v, float dx, float dy, float dz)
        {
            Matrix.Transform(v, Matrix.getTranslation(dx, dy, dz));

        }
        public void Rotate(List<Vector> v, int rangle, string axis)
        {
            float dx, dy, dz;
            switch (axis)
            {
                case "X":
                    Matrix mX = Matrix.getRotationX(rangle);
                    SetZero(v, out dx, out dy, out dz);
                    Matrix.Transform(v, mX);
                    ReSetZero(v, dx, dy, dz);
                    break;
                case "Y":
                    Matrix mY = Matrix.getRotationY(rangle);
                    SetZero(v, out dx, out dy, out dz);
                    Matrix.Transform(v, mY);
                    ReSetZero(v, dx, dy, dz);
                    break;
                case "Z":
                    Matrix mZ = Matrix.getRotationZ(rangle);
                    SetZero(v, out dx, out dy, out dz);
                    Matrix.Transform(v, mZ);
                    ReSetZero(v, dx, dy, dz);
                    break;
                default:
                    break;
            }
        }
    }
}

