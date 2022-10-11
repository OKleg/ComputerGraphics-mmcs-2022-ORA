using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab3Affinis
{
    internal class AffineMatrix
    {
        /*public double M00, M01, M02;
        public double M10, M11, M12;
        public double M20, M21, M22;

        public AffineMatrix(
            double m00,
            double m01,
            double m02,
            double m10,
            double m11,
            double m12,
            double m20,
            double m21,
            double m22)
        {
            M00 = m00;
            M01 = m01;
            M02 = m02;
            M10 = m10;
            M11 = m11;
            M12 = m12;
            M20 = m20;
            M21 = m21;
            M22 = m22;
        }

        public AffineMatrix()
        {
            (this.M00,this.M11,this.M22) = (1,1,1);
            (this.M01, this.M02, this.M10, this.M12, this.M20, this.M21) = (0, 0, 0, 0, 0, 0);
        }


        public AffineMatrix Multiply(AffineMatrix m)
        {
            double[] pp = new double[3] { p.X, p.Y, 1 };
            double[] result = new double[3] { 0, 0, 0 };
            for (int i = 0; i < 3; i++)//i < 2
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i] += pp[j] * m[i, j];
                }
            }
            return new Point((int)Math.Round(result[0]), (int)Math.Round(result[1]));
        }
        public double this[int i, int j]
        {
            get
            {
                switch (i*10 + j) // (:
                {
                    case 0:
                        return this.M00;
                    case 1:
                        return this.M01;
                    case 2:
                        return this.M02;
                    case 10:
                        return this.M10;
                    case 11:
                        return this.M11;
                    case 12:
                        return this.M12;
                    case 20:
                        return this.M20;
                    case 21:
                        return this.M21;
                    case 22:
                        return this.M22;
                    default:
                        return this.M00;
                }
            }
            set
            {
                switch (i * 10 + j) // (:
                {
                    case 0:
                        this.M00 = value;
                        break;
                    case 1:
                        this.M01 = value;
                        break;
                    case 2:
                        this.M02 = value;
                        break;
                    case 10:
                        this.M10 = value;
                        break;
                    case 11:
                        this.M11 = value;
                        break;
                    case 12:
                        this.M12 = value;
                        break;
                    case 20:
                        this.M20 = value;
                        break;
                    case 21:
                        this.M21 = value;
                        break;
                    case 22:
                        this.M22 = value;
                        break;
                    default:
                        break;
                }
            }
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            return a.Multiply(b);
        }*/

        private int rows;
        private int cols;
        private double[,] mass;
        
        public AffineMatrix()
        {
            (rows, cols) = (3, 3);
            mass = new double[3, 3]
                {
                    {1,0,0 },
                    {0,1,0 },
                    {0,0,1 }
                };
        }
        public AffineMatrix(int n,int m)
        {
            this.Rows = n;
            this.Cols = m;
            mass = new double[this.Rows, this.Cols];
        }
        public AffineMatrix(Point p)
        {
            (rows, cols) = (1, 3);
            mass = new double[1, 3] { { p.X, p.Y, 1 } };
        }

        public void SetShift(int dx,int dy)
        {
            this.mass[2, 0] = dx;
            this.mass[2, 1] = dy;
        }
        public void SetRotateAngle(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            (this.mass[0, 0], this.mass[1, 1]) = (cos, cos);
            (this.mass[0, 1], this.mass[1, 0]) = (-sin, sin);
        }
        public void Shift(Point[] p,int dx,int dy)
        {
            this.SetShift(dx, dy);
            Transform(p);
            this.SetShift(0, 0);
        }

        private void Transform(Point[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                //p[i] = MultMatrix(p[i], mat);// перемножаем матрицу на точку и получаем новое положение точки
                AffineMatrix res = new AffineMatrix(p[i]) * this;
                p[i] = new Point((int)Math.Round(res[0, 0]), (int)Math.Round(res[0, 1]));
            }
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
        public  void ResetRotateAngle()
        {
            (this.mass[0, 0], this.mass[1, 1]) = (1, 1);
            (this.mass[0, 1], this.mass[1, 0]) = (0, 0);
        }

        internal void Rotate(Point[] p, Point c, double angle)
        {
            //this.SetRotateAngle(angle);
            this.Shift(p, -c.X, -c.Y);
            this.SetRotateAngle(angle);
            Transform(p);
            this.ResetRotateAngle();
            this.Shift(p, c.X, c.Y);
        }

        // перегрузка оператора умножения
        public static AffineMatrix operator *(AffineMatrix a, AffineMatrix b)
        {
            return AffineMatrix.umn(a, b);
        }  

        
    }
}
