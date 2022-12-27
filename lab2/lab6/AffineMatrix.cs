using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace lab6
{
    public class AffineMatrix
    {

        private int rows;
        private int cols;
        private float[,] mass;
        public AffineMatrix()
        {
            (rows, cols) = (4, 4);
            mass = new float[4, 4]
                {
                    {1,0,0,0},
                    {0,1,0,0},
                    {0,0,1,0},
                    {0,0,0,1}
                };
        }
        public AffineMatrix(float[,] m)
        {
            (rows, cols) = (4, 4);
            mass = m;
        }
        public AffineMatrix(int n,int m)
        {
            this.Rows = n;
            this.Cols = m;
            mass = new float[this.Rows, this.Cols];
        }
        public AffineMatrix(Vector p)
        {
            (rows, cols) = (4, 1);//(1, 4);?
            mass = new float[4, 1] { { p.x }, { p.y }, { p.z }, { p.w } };
        }
        public int Rows
        {
            get { return rows; }
            set { if (value > 0) rows = value; }
        }
        public int Cols
        {
            get { return cols; }
            set { if (value > 0) cols = value; }
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

        // Умножение матрицы А на матрицу Б
        public static AffineMatrix mult(AffineMatrix a, AffineMatrix b)
        {
            AffineMatrix resMass = new AffineMatrix(a.Rows, b.Cols);
            if (a.Cols == b.Rows)
            {
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < b.Cols; j++)
                        for (int k = 0; k < b.Rows; k++)
                            resMass[i, j] += a[i, k] * b[k, j];
            }
            return resMass;
        }
        private static AffineMatrix multiplyMat(AffineMatrix a, AffineMatrix b)
        {
            AffineMatrix m = new AffineMatrix();
            Parallel.For(0, 4, (i) =>
            {
                Parallel.For(0, 4, (j) =>
                {
                    m[i, j] = a[i, 0] * b[0, j] +
                      a[i, 1] * b[1, j] +
                      a[i, 2] * b[2, j] +
                      a[i, 3] * b[3, j];
                });
            });
            return m;
        }
        private static Vector multiplyVector(AffineMatrix m, Vector v)
        {
            return new Vector(
              m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w,
              m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w,
              m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w,
              m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w
            );
}
        // ----------- Translation ----------- 
        /*множив матрицу перемещения на вектор (местоположение)
         * он сместится на указанное число единиц в пространстве.*/
        public AffineMatrix getTranslation(float dx, float dy, float dz)
        {
            this[0, 3] = dx;
            this[1, 3] = dy;
            this[2, 3] = dz;
            AffineMatrix m = this;
            setTranslation(0,0,0);
            return m;
        }
        public void setTranslation(float dx, float dy, float dz)
        {
            this[0, 3] = dx;
            this[1, 3] = dy;
            this[2, 3] = dz;
        }
        public void Translation(List<Vector> p,float dx,float dy, float dz )
        { 
            this.setTranslation(dx, dy, dz);
            Transform(p,this);
            this.setTranslation(0, 0,0); 
        }
        // =========== Translation =========== 

        static private void Transform(List<Vector> p, AffineMatrix matrix)
        {
            Parallel.For(0, p.Count, (i) =>
            {
                p[i] = matrix * p[i];
            });
        }

        // ----------- Rotate -----------
        public AffineMatrix getRotateAngleX(int angle, Vector c = null)
        {
            if (angle != 0)
            {
                var angleRad = Math.PI / 180 * angle;
                float sin = (float)Math.Sin(angleRad);
                float cos = (float)Math.Cos(angleRad);
                (this[1, 1], this[1, 2]) = (cos, -sin);
                (this[2, 1], this[2, 2]) = (sin, cos);
            }
                AffineMatrix m = this;
                ResetRotateAngle();
                return m;
          
        }
      /*  static public AffineMatrix getRotateAngleX(int angle, Vector c = null)
        {
            var angleRad = Math.PI / 180 * angle;
            float sin = (float)Math.Sin(angleRad);
            float cos = (float)Math.Cos(angleRad);
             AffineMatrix m = new AffineMatrix(
               new float[4, 4]
               {
                    {1, 0, 0, 0},
                    {0,cos, -sin, 0},
                    {0, cos, cos, 0},
                    {0, 0, 0, 1},
                });
            return m;
        }*/
        public AffineMatrix getRotateAngleY(int angle, Vector c = null)
        {
            if (angle != 0)
            {
                var angleRad = Math.PI / 180 * angle;
                float sin = (float)Math.Sin(angleRad);
                float cos = (float)Math.Cos(angleRad);
                (this[0, 0], this[0, 2]) = (cos, sin);
                (this[2, 0], this[2, 2]) = (-sin, cos);
            }
            AffineMatrix m = this;
            ResetRotateAngle();
            return m;
        }
        public AffineMatrix getRotateAngleZ(int angle, Vector c = null)
        {
            if (angle != 0)
            {
                var angleRad = Math.PI / 180 * angle;
                float sin = (float)Math.Sin(angleRad);
                float cos = (float)Math.Cos(angleRad);
                (this[0, 0], this[0, 1]) = (cos, -sin);
                (this[1, 0], this[1, 1]) = (sin, cos);
            }
            AffineMatrix m = this;
            ResetRotateAngle();
            return m;
        }
        public  void ResetRotateAngle()
        {
            (this[0, 0], this[1, 1],this[2,2]) = (1, 1,1);
            (this[0, 1], this[1, 0]) = (0, 0);
            (this[2, 0], this[2, 0]) = (0, 0);
            (this[2, 1], this[2, 1]) = (0, 0);
        }

         public void Rotate(List<Vector> p, int angleX, int angleY, int angleZ)
        {
            AffineMatrix matrix =  getRotateAngleX(angleX) * getRotateAngleY(angleY) * getRotateAngleZ(angleZ);
            Transform(p, matrix);
            ResetRotateAngle();
        }
        // =========== Rotate =========== 

        // ----------- Scale ----------- 
        public void SetScale(float kx, float ky, float kz, Vector c = null)
        {
            
            (this[0, 0], this[1, 1],this[2,2]) = (kx, ky,kz);
            if (c != null) (this[3, 0], this[3, 1], this[3, 2]) = ((1-kx) * c.x, (1 - ky) * c.y, (1 - kz) * c.z);
        }
        public void ReSetScaleCoef()
        {
            (this[0, 0], this[1, 1], this[2, 2], this[3, 3]) = (1, 1, 1,1);
            (this[3, 0], this[3, 1], this[3, 2]) = (0,0,0);
            (this[0, 3], this[1, 3], this[2, 3]) = (0,0,0);
        }
        public List<Vector> Scale(List<Vector> p, float kx, float ky, float kz = 1, Vector c = null)
        {
            List<Vector> resVectors = new List<Vector>(p);
            ReSetScaleCoef();
            SetScale(kx, ky, kz,c);
            Transform(resVectors,this);
            ReSetScaleCoef();
            return resVectors;
        }
        // =========== Scale =========== 
        public AffineMatrix getСonvergingLtoZ(Vector v1,Vector v2)
        {
            
                float l = v2.x;
                float m = v2.y;
                float n = v2.z;
                double d = Math.Sqrt(Math.Pow(m, 2) + Math.Pow(n, 2));

                float sin = (float)(m /d);
                float cos = (float)(n /d);
            (this[1, 1], this[1, 2]) = (cos, -sin);
            (this[2, 1], this[2, 2]) = (sin, cos);

            AffineMatrix matr = this;
            ResetRotateAngle();
            return matr;
        }

        // перегрузка оператора умножения
        public static AffineMatrix operator *(AffineMatrix a, AffineMatrix b)
        {
            return multiplyMat(a, b);
            //return AffineMatrix.mult(a, b);
        }

        public static Vector operator *(AffineMatrix m, Vector v)
        {
            return multiplyVector(m, v);
        }
        public static Vector operator *( Vector v,AffineMatrix m)
        {
            return multiplyVector(m, v);
        }
    }
}
