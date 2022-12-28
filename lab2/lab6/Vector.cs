using System;
using System.Collections.Generic;
using System.Drawing;

namespace lab6
{
    public class Vector
    {

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }
        public Color color = Color.Gray;
        public Vector()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 1;
        }
        public Vector(Vector start, Vector end) : this(end.x - start.x, end.y - start.y, end.z - start.z) { }
        public Vector(float X, float Y, float Z, float w = 1)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
            this.w = w;
        }
        public Vector(Vector p)
        {
            if (p == null)
                return;
            x = p.x;
            y = p.y;
            z = p.z;
            w = p.w;
        }
        public float length()
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

       
        public Vector normalize()
        {
            float length = this.length();

            this.x /= length;
            this.y /= length;
            this.z /= length;
            return this;
        }
        public static Vector normalize(Vector p)
        {
            float z = (float)Math.Sqrt((float)(p.x * p.x + p.y * p.y + p.z * p.z));
            if (z == 0)
                return new Vector(p);
            return new Vector(p.x / z, p.y / z, p.z / z);
        }
        public static void normalize(List<Vector> v)
        {
            for (int i = 0; i < v.Count-1; i++)
            {
                    v[i] = v[i].normalize();
            };
        }
        Vector multiplyByScalar(int s)
        {
            this.x *= s;
            this.y *= s;
            this.z *= s;

            return this;
        }
        //Векторное произведение 
        public static Vector cross(Vector v1, Vector v2)
        {
            return new Vector(
              v1.y * v2.z - v1.z * v2.y,
              v1.z * v2.x - v1.x * v2.z,
              v1.x * v2.y - v1.y * v2.x
            );
        }
        // Скалярное произведение векторов
        public static float scalar(Vector p1, Vector p2)
        {
            return p1.x * p2.x + p1.y * p2.y + p1.z * p2.z;
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(
                        v1.x + v2.x,
                        v1.y + v2.y,
                        v1.z + v2.z
                        );
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector( v1.x - v2.x, v1.y - v2.y, v1.z - v2.z );
        }
        /*  public static Vector operator *(Vector v1, Vector v2)
          {
              return new Vector(
                          v1.x * v2.x,
                          v1.y * v2.y,
                          v1.z * v2.z
                          );
          }*/
        public static Vector operator *(Vector v1, Vector v2)
        {
            return cross(v1, v2);
        }
        public static Vector operator *(Vector v1, float i)
        {
            return new Vector( v1.x * i, v1.y * i,  v1.z * i );
        }
        public static Vector operator /(Vector v1, float i)
        {
            return new Vector(   v1.x / i, v1.y / i, v1.z / i );
        }
       
        public static Vector operator *( float i,Vector v1) 
        {
            return new Vector( v1.x * i,  v1.y * i,   v1.z * i  );
        }

        public static float distance(Vector p1, Vector p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2) + Math.Pow(p2.z - p1.z, 2));
        }
        public static Vector VectorOnLine(Vector origin, Vector direction, float distance)
        {
            return new Vector(origin.x + direction.x * distance, origin.y + direction.y * distance, origin.z + direction.z * distance);
        }
        public static Vector getVectorProjection(Vector origin, Vector direction, Vector projected)
        {
            float parameter = (float)((direction.x * (projected.x - origin.x) + direction.y * (projected.y - origin.y) + direction.z * (projected.z - origin.z)) / (Math.Pow(direction.x, 2) + Math.Pow(direction.y, 2) + Math.Pow(direction.z, 2)));
            return VectorOnLine(origin, direction, parameter);
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
