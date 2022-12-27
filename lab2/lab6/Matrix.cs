using System;
using System.Collections.Generic;

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

        public static Matrix getDefaultMatrix()
        {
            return new Matrix(new float[4, 4] {

              {1, 0, 0, 0},

              {0, 1, 0, 0},

              {0, 0, 1, 0},

              {0, 0, 0, 1},
            });
        }

        public static Matrix multiply(Matrix a, Matrix b)
        {

            Matrix m = getDefaultMatrix();/*new  Matrix(new float[4,4] {
        
              {1, 0, 0, 0},
        
              {0, 1, 0, 0},
        
              {0, 0, 1, 0},
        
              {0, 0, 0, 1},
            });*/

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
        public Matrix multiplyV2(Matrix a, Matrix b)
        {
            float[,] res = new float[a.mass.GetLength(0), b.mass.GetLength(1)];
            for (int i = 0; i < a.mass.GetLength(0); i++)
            {
                for (int j = 0; j < b.mass.GetLength(1); j++)
                {
                    for (int k = 0; k < b.mass.GetLength(0); k++)
                    {
                        res[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return new Matrix(res);
        }

        public static float[,] PointToColumn(Vector pnt)
        {
            return new float[,]{ { pnt.x}, 
                                 { pnt.y},
                                 { pnt.z},
                                 { 1} 
            };
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
        public static Matrix getIsometricProjection()
        {
            float sqrt6 = (float)Math.Sqrt(6);
            float sqrt3 = (float)Math.Sqrt(3);
            float sqrt2 = (float)Math.Sqrt(2);

            /*return new Matrix(new float[4, 4]
            {
                { (float)Math.Sqrt(0.5), 0, (float)-Math.Sqrt(0.5), 0 },
                { 1 / (float)Math.Sqrt(6), 2 /(float) Math.Sqrt(6), 1 / (float)Math.Sqrt(6), 0 },
                { 1 / (float)Math.Sqrt(3), -1 / (float)Math.Sqrt(3), 1 / (float)Math.Sqrt(3), 0 },
                { 0, 0, 0, 1 }
            });*/
            return new Matrix(new float[4, 4]
            {
                { sqrt3/sqrt6, 0, -sqrt3/sqrt6,0},
                {1/sqrt6, 2/ sqrt6, 1/sqrt6,0},
                {sqrt2/sqrt6, - sqrt2/sqrt6, sqrt2/sqrt6, 0},
                {0,0,0,1 }
            });
        }
        public static Matrix getRotationX(float angle)
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
        public static Matrix  getRotationY(float angle)
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

        public static Matrix getRotationZ(float angle)
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
        public static List<Vector> getTransform(List<Vector> vertices, Matrix matrix)
        {
            List<Vector> result = new List<Vector>();
            for (int i = 0; i < vertices.Count; i++)
            {
                result[i] = Matrix.multiplyVector(
                  matrix,
                  vertices[i]
                );
                if (vertices[i].w != 1)
                {
                    result[i].x = vertices[i].x / vertices[i].w * 250;
                    result[i].y = vertices[i].y / vertices[i].w * 250;
                }
            }
            return result;
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

        internal static Matrix getRotation(float angle, string axis)
        {
            //throw new NotImplementedException();
            switch (axis)
            {
                case "Ox":
                    return getRotationX(angle);
                case "Oy":
                    return getRotationY(angle);
                case "Oz":
                    return getRotationZ(angle);
                default: return getDefaultMatrix();
            }

        }

        internal static List<Vector> RotatePoints(List<Vector> generatrix, float angle, string axis)
        {
            Matrix m = getRotation(angle, axis);
            //return getTransform(generatrix, m);
            List<Vector> res = new List<Vector>();

            foreach (Vector v in generatrix)
            {
                res.Add(multiplyVector(m, v));
            }
            return res;
        }
    }
}
