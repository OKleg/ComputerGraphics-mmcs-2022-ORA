using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab6
{
    class Matrix
    {

        private float[,] mass;
        public Matrix(float[,] m)
        { 
            mass = m;
        }

    
        public float this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }
        public static Matrix multiply(Matrix a, Matrix b)
        {

            Matrix m =new  Matrix(new float[4,4] {
        
              {1, 0, 0, 0},
        
              {0, 1, 0, 0},
        
              {0, 0, 1, 0},
        
              {0, 0, 0, 1},
            });

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    m[i,j] = a[i,0] * b[0,j] +
                      a[i,1] * b[1,j] +
                      a[i,2] * b[2,j] +
                      a[i,3] * b[3,j];
                }
            }

            return m;
        }
        public static Matrix getView(Vector eye, Vector target, Vector up)
        {
            Vector vz = (eye - target).normalize();
            Vector vx = Vector.cross(up, vz).normalize();
            Vector vy = Vector.cross(vz, vx).normalize();

            return Matrix.multiply(
              Matrix.getTranslation(-eye.x, -eye.y, -eye.z), new Matrix(
                new float[4,4]
              {
                {vx.x, vx.y, vx.z, 0},
          
                {vy.x, vy.y, vy.z, 0},
          
                {vz.x, vz.y, vz.z, 0},
          
                {   0,    0,    0, 1}
              }));
        }
        public static Matrix getPerspectiveProjection(double fovy, double aspect, float n, float f)
        {
            float radians = (float)(Math.PI / 180 * fovy);
            float sx = (float)((1 / Math.Tan(radians / 2)) / aspect);
            float sy = (float)(1 / Math.Tan(radians / 2));
            float sz = (f + n) / (f - n);
            float dz = (-2 * f * n) / (f - n);
            return new Matrix(  new float[4,4]{ 
                {sx, 0, 0, 0},
                {0, sy, 0, 0},
                {0, 0, sz, dz},
                {0, 0, -1, 0},
  });
}
        public static Matrix getRotationX(int angle)
        {
            double rad = (Math.PI / 180 * angle);
            float sin = (float)Math.Sin(rad);
            float cos = (float)Math.Cos(rad);
            return new Matrix(new float[4,4]{
              {1, 0, 0, 0},
              {0, cos, -sin, 0},
              {0, sin, cos, 0},
              {0, 0, 0, 1},
            });
        }
        public static Matrix getСonvergingLtoZ(float l, float m, float n)
        {
            double d = Math.Sqrt(Math.Pow(m, 2) + Math.Pow(n, 2));

            float sin = (float)(m / d);
            float cos = (float)(n / d);
            Matrix matr1 = new  Matrix(new float[4, 4]{
              {1, 0, 0, 0},
              {0, cos, -sin, 0},
              {0, sin, cos, 0},
              {0, 0, 0, 1},
            });
            cos = l;
            sin = (float)- d;
            Matrix matr2 = new Matrix(new float[4, 4]{
                  { cos, 0  , sin, 0  },
                  {  0 , 1  , 0  , 0  },
                  {-sin, 0  , cos, 0  },
                  {  0 , 0  , 0  , 1  },
             });
            return matr2 * matr1 ;
        }
        public static Matrix getRotateL(Vector p1, Vector p2, float angle)
        {
            //double d = Math.Sqrt(Math.Pow(m, 2) + Math.Pow(n, 2));

            //float sin = (float)(m / d);
            //float cos = (float)(n / d);
            /*            Matrix matr1 = new Matrix(new float[4, 4]{
                          {1, 0, 0, 0},
                          {0, cos, -sin, 0},
                          {0, sin, cos, 0},
                          {0, 0, 0, 1},
                        });*/
            //cos = l;
            //sin = (float)-d;

            /* Matrix matr2 = new Matrix(new float[4, 4]{
                   { cos, 0  , sin, 0  },
                   {  0 , 1  , 0  , 0  },
                   {-sin, 0  , cos, 0  },
                   {  0 , 0  , 0  , 1  },
              });*/
            Vector vec = p2 - p1;
            vec = vec.normalize();
            (float l, float m, float n) = (vec.x, vec.y, vec.z);

            float l2 = (float)Math.Pow(l,2);
            float m2 = (float)Math.Pow(m, 2);
            float n2 = (float)Math.Pow(n, 2);
            double rad = (Math.PI / 180 * angle);
            float sin = (float)Math.Sin(rad);
            float cos = (float)Math.Cos(rad);
            Matrix matr = new Matrix(new float[4, 4]{
                  { l*l*(1-cos) + cos  , l*(1-cos)*m - n*sin, l*(1-cos)*n + m*sin, 0  },
                  { m*(1-cos)*l + n*sin, m*m*(1-cos) + cos  , m*(1-cos)*n - l*sin, 0  },
                  { l*(1-cos)*n - m*sin, m*(1-cos)*n + l*sin, n*n*(1-cos) + cos  , 0  },
                  { 0                  , 0                  , 0                  , 1  },
             });
            return matr;// matr1 * matr2;
        }
        public static Matrix  getRotationY(int angle)
        {
            double rad = (Math.PI / 180 * angle);
            float sin = (float)Math.Sin(rad);
            float cos = (float)Math.Cos(rad);
            return new Matrix(new float[4, 4]{
                  { cos, 0  , -sin, 0  },
                  {  0 , 1  , 0  , 0  },
                  {sin, 0  , cos, 0  },
                  {  0 , 0  , 0  , 1  },
             });
        }

        public static Matrix getRotationZ(int angle)
        {
            double rad = Math.PI / 180 * angle;
            float sin = (float)Math.Sin(rad);
            float cos = (float)Math.Cos(rad);
            return new Matrix(new float[4, 4]{
                  {cos, -sin, 0, 0},
                  {sin, cos, 0, 0},
                  {0, 0, 1, 0},
                  {0, 0, 0, 1},
            });
        }

        public static Matrix getTranslation(float dx, float dy, float dz)
        {
            return new Matrix(new float[4, 4]{

              {1, 0, 0, dx},
              {0, 1, 0, dy},
              {0, 0, 1, dz},
              {0, 0, 0, 1},
            });
        }

        public static Matrix getScale(float sx, float sy, float sz)
        {
            return new Matrix(new float[4, 4]{
              {sx, 0, 0, 0},
              {0, sy, 0, 0},
              {0, 0, sz, 0},
              {0, 0, 0, 1},
            });
        }
        public static void Transform(List<Vector> vertices, Matrix matrix)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] = Matrix.multiplyVector(
                  matrix,
                  vertices[i]
                );
                if (vertices[i].w != 1)
                {
                    vertices[i].x = vertices[i].x / vertices[i].w *250 ;
                    vertices[i].y = vertices[i].y / vertices[i].w *250 ;
                }
                

            }
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return multiply(a, b);
        }
        public static Vector multiplyVector(Matrix m,Vector v)
        {
            return new Vector(
              m[0,0] * v.x + m[0,1] * v.y + m[0,2] * v.z + m[0,3] * v.w,
              m[1,0] * v.x + m[1,1] * v.y + m[1,2] * v.z + m[1,3] * v.w,
              m[2,0] * v.x + m[2,1] * v.y + m[2,2] * v.z + m[2,3] * v.w,
              m[3,0] * v.x + m[3,1] * v.y + m[3,2] * v.z + m[3,3] * v.w
            );
        }
    }
}
