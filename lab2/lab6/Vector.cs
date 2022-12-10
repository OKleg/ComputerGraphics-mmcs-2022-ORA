using System;

namespace lab6
{
    public class Vector
    {

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }

        public Vector(float X, float Y, float Z, float w = 1)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
            this.w = w;
        }
        float getLength()
        {
            return (float)Math.Sqrt(
                this.x * this.x + this.y * this.y + this.z * this.z
            );
        }
        public override string ToString()
        {
            return " [x=" + x + ",y=" + y + "z=" + z + "] ";
        }
        public override int GetHashCode()// ?
        {
            int hash = 5381;
            hash = ((hash << 5) + (int)x);
            hash = ((hash << 5) + (int)y);
            hash = ((hash << 5) + (int)z);

            return hash;
        }

        /* public Vector multiply(AffineMatrix m, Vector v)
         {
             return new Vector(
               m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w,
               m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w,
               m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w,
               m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w

             );
         }*/
        /* public static Vector operator *(AffineMatrix m, Vector v)
         {
             return new Vector(
               m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w,
               m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w,
               m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w,
               m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w

             );
         }*/
        public Vector normalize()
        {
            float length = this.getLength();

            this.x /= length;
            this.y /= length;
            this.z /= length;

            return this;
        }
        Vector multiplyByScalar(int s)
        {
            this.x *= s;
            this.y *= s;
            this.z *= s;

            return this;
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(
                        v1.x + v2.x,
                        v1.y + v2.y,
                        v1.z + v2.z
                        );
        }
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(
                        v1.x * v2.x,
                        v1.y * v2.y,
                        v1.z * v2.z
                        );
        }
        public static Vector operator *(Vector v1, int i)
        {
            return new Vector(
                        v1.x * i,
                        v1.y * i,
                        v1.z * i
                        );
        }
        public static Vector operator *( int i,Vector v1)
        {
            return new Vector(
                        v1.x * i,
                        v1.y * i,
                        v1.z * i
                        );
        }


         public static float MidX(Vector v1, Vector v2)
         {
             return (v1.x + v2.x) /2;
         }

        public static float MidY(Vector v1, Vector v2)
         {
             return ((v1.y + v2.y) /2);
         }
         public static float MidZ(Vector v1, Vector v2)
         {
             return ((v1.z + v2.z) / 2);
         }
         public static Vector Mid(Vector v1, Vector v2)
         {
             return new Vector(MidX(v1,v2), MidY(v1, v2), MidZ(v1, v2));
         }
    }
}
