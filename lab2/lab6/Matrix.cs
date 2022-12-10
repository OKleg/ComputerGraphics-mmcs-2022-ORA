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

        public static Matrix  getRotationY(int angle)
        {
            double rad = (Math.PI / 180 * angle);
            float sin = (float)Math.Sin(rad);
            float cos = (float)Math.Cos(rad);
            return new Matrix(new float[4, 4]{
                  { cos, 0  , sin, 0  },
                  {  0 , 1  , 0  , 0  },
                  {-sin, 0  , cos, 0  },
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
