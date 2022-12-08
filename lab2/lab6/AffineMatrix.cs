    using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace lab6
{
    internal class AffineMatrix
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
        public AffineMatrix(int n,int m)
        {
            this.Rows = n;
            this.Cols = m;
            mass = new float[this.Rows, this.Cols];
        }
        public AffineMatrix(Vector p)
        {
            (rows, cols) = (4, 1);//(1, 4);?
            mass = new float[1, 4] { { p.x, p.y, p.z, p.w } };
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

        // ----------- Translation ----------- 
        /*множив матрицу перемещения на вектор (местоположение)
         * он сместится на указанное число единиц в пространстве.*/
        public AffineMatrix getTranslation(float dx,float dy, float dz )
        {
            this[3, 0] = dx;
            this[3, 1] = dy;
            this[3, 2] = dz;
            return this;
        }
        public void setTranslation(float dx, float dy, float dz)
        {
            this[3, 0] = dx;
            this[3, 1] = dy;
            this[3, 2] = dz;
        }
        public List<Vector> Translation(List<Vector> p,float dx,float dy, float dz )
        {
            this.setTranslation(dx, dy, dz);
            Transform(p);
            this.setTranslation(0, 0,0);
            return p;
        }
        // =========== Translation =========== 

        private void Transform(List<Vector> p )
        {
            List<Vector> resVectors = new List<Vector>();
            for (int i = 0; i < p.Count; i++)
            {
                //p[i] = MultMatrix(p[i], mat);// перемножаем матрицу на точку и получаем новое положение точки
                AffineMatrix res = new AffineMatrix(p[i]) * this;
                p[i] = new Vector((float)Math.Round(res[0, 0]), (float)Math.Round(res[0, 1]), (float)Math.Round(res[0, 2]));//......
            }
        }

        // ----------- Rotate ----------- 
        public void SetRotateAngleX(double angle, Vector c)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            (this[1, 1], this[1, 2]) = ((float)cos, (float)sin);
            (this[2, 1], this[2, 3]) = ((float)-sin, (float)cos);
           // (this[2, 0], this[2, 1]) = (-c.X*cos + c.Y*sin + c.X, -c.X * sin - c.Y * cos + c.Y);
        }
        public void SetRotateAngleY(double angle, Vector c)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            (this[0, 0], this[0, 2]) = ((float)cos, (float)-sin);
            (this[0, 2], this[2, 2]) = ((float)sin, (float)cos);
            // (this[2, 0], this[2, 1]) = (-c.X*cos + c.Y*sin + c.X, -c.X * sin - c.Y * cos + c.Y);
        }
        public void SetRotateAngleZ(double angle, Vector c)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            (this[0, 0], this[0, 1]) = ((float)cos, (float)sin);
            (this[1, 0], this[1, 2]) = ((float)-sin, (float)cos);
            //(this[3, 0], this[3, 1]) = (-c.X*cos + c.Y*sin + c.X, -c.X * sin - c.Y * cos + c.Y);
        }
        public  void ResetRotateAngle()
        {
            (this[0, 0], this[1, 1],this[2,2]) = (1, 1,1);
            (this[0, 1], this[1, 0]) = (0, 0);
            (this[2, 0], this[2, 0]) = (0, 0);
            (this[2, 1], this[2, 1]) = (0, 0);
        }

        internal void Rotate(List<Vector> p, Vector c, double angle)
        {
            //this.SetRotateAngle(angle);
           // this.Shift(p, -c.X, -c.Y);
        /*    this.SetRotateAngle(angle,c);
            Transform(p);
            this.ResetRotateAngle();*/
           // this.Shift(p, c.X, c.Y);
        }
        // =========== Rotate =========== 

        // ----------- Scale ----------- 
        public void GetScale(float kx, float ky, float kz, Vector c = null)
        {
            if (c == null) c = new Vector(0, 0, 0);
            (this[0, 0], this[1, 1],this[2,2]) = (kx, ky,kz);
            (this[3, 0], this[3, 1], this[3, 2]) = ((1-kx) * c.x, (1 - ky) * c.y, (1 - kz) * c.z);
        }
        public void ReSetScaleCoef()
        {
            (this[0, 0], this[1, 1], this[2, 2]) = (1, 1, 1);
            (this[3, 0], this[3, 1], this[3, 2]) = (0,0,0);
        }
        internal List<Vector> Scale(List<Vector> p, float kx, float ky, float kz = 1, Vector c = null)
        {
            if (c == null) c = new Vector(0, 0, 0);
            this.GetScale(kx, ky, kz, c);
            Transform(p);
            ReSetScaleCoef();
            return p;
        }
        // =========== Scale =========== 

        // перегрузка оператора умножения
        public static AffineMatrix operator *(AffineMatrix am1, AffineMatrix am2)
        {
            return AffineMatrix.mult(am1, am2);
        }
       

    }
}
