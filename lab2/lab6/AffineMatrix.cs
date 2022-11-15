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
        private double[,] mass;
        
        public AffineMatrix()
        {
            (rows, cols) = (3, 3);
            mass = new double[4, 4]
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
            mass = new double[this.Rows, this.Cols];
        }
        public AffineMatrix(myPoint3D p)
        {
            (rows, cols) = (1, 3);
            mass = new double[1, 3] { { p.X, p.Y, p.Z } };
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

        
        public double this[int i, int j]
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
        public static AffineMatrix umn(AffineMatrix a, AffineMatrix b)
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

        // ----------- Shift ----------- 
        public void SetShift(int dx,int dy, int dz )
        {
            this[3, 0] = dx;
            this[3, 1] = dy;
            this[3, 2] = dz;

        }

        public void Shift(myPoint3D[] p,int dx,int dy, int dz )
        {
            this.SetShift(dx, dy, dz);
            Transform(p);
            this.SetShift(0, 0,0);
        }
        // =========== Shift =========== 

        private void Transform(myPoint3D[] p )
        {
            for (int i = 0; i < p.Length; i++)
            {
                //p[i] = MultMatrix(p[i], mat);// перемножаем матрицу на точку и получаем новое положение точки
                AffineMatrix res = new AffineMatrix(p[i]) * this;
                p[i] = new myPoint3D((int)Math.Round(res[0, 0]), (int)Math.Round(res[0, 1]), (int)Math.Round(res[0, 2]));//......
            }
        }

        // ----------- Rotate ----------- 
        public void SetRotateAngleX(double angle, myPoint3D c)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            (this[1, 1], this[1, 2]) = (cos, sin);
            (this[2, 1], this[2, 3]) = (-sin, cos);
           // (this[2, 0], this[2, 1]) = (-c.X*cos + c.Y*sin + c.X, -c.X * sin - c.Y * cos + c.Y);
        }
        public void SetRotateAngleY(double angle, myPoint3D c)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            (this[0, 0], this[0, 2]) = (cos, -sin);
            (this[0, 2], this[2, 2]) = (sin, cos);
            // (this[2, 0], this[2, 1]) = (-c.X*cos + c.Y*sin + c.X, -c.X * sin - c.Y * cos + c.Y);
        }
        public void SetRotateAngleZ(double angle, myPoint3D c)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            (this[0, 0], this[0, 1]) = (cos, sin);
            (this[1, 0], this[1, 2]) = (-sin, cos);
            //(this[3, 0], this[3, 1]) = (-c.X*cos + c.Y*sin + c.X, -c.X * sin - c.Y * cos + c.Y);
        }
        public  void ResetRotateAngle()
        {
            (this[0, 0], this[1, 1],this[2,2]) = (1, 1,1);
            (this[0, 1], this[1, 0]) = (0, 0);
            (this[2, 0], this[2, 0]) = (0, 0);
            (this[2, 1], this[2, 1]) = (0, 0);
        }

        internal void Rotate(myPoint3D[] p, myPoint3D c, double angle)
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
        public void SetScaleCoef(double kx, double ky, double kz, myPoint3D c)
        {
            (this[0, 0], this[1, 1],this[2,2]) = (kx, ky,kz);
            (this[3, 0], this[3, 1], this[3, 2]) = ((1-kx) * c.X, (1 - ky) * c.Y, (1 - kz) * c.Z);
        }
        public void ReSetScaleCoef()
        {
            (this[0, 0], this[1, 1], this[2, 2]) = (1, 1, 1);
            (this[3, 0], this[3, 1], this[3, 2]) = (0,0,0);
        }
        internal void Scale(myPoint3D[] p, myPoint3D c, double kx, double ky, double kz = 1)
        {
            this.SetScaleCoef(kx, ky, kz, c);
            Transform(p);
            ReSetScaleCoef();
        }
        // =========== Scale =========== 

        // перегрузка оператора умножения
        public static AffineMatrix operator *(AffineMatrix a, AffineMatrix b)
        {
            return AffineMatrix.umn(a, b);
        }  

        
    }
}
