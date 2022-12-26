using System;
using System.Collections.Generic;

namespace lab6
{
    public class Vector
    {

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }
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
                x * x + y * y + z * z
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
      
        //Векторное произведение 
        public static Vector cross(Vector v1, Vector v2)
        {
            return new Vector(
              v1.y * v2.z - v1.z * v2.y,
              v1.z * v2.x - v1.x * v2.z,
              v1.x * v2.y - v1.y * v2.x
            );
        }
        public static float scalar(Vector p1, Vector p2)
        {
            return p1.x * p2.x + p1.y * p2.y + p1.z * p2.z;
        }
        public static Vector operator -(Vector p1, Vector p2)
        {
            return new Vector(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);

        }

        public static Vector operator +(Vector p1, Vector p2)
        {
            return new Vector(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);

        }

        public static Vector operator *(Vector p1, Vector p2)
        {
            return new Vector(p1.y * p2.z - p1.z * p2.y, p1.z * p2.x - p1.x * p2.z, p1.x * p2.y - p1.y * p2.x);
        }
        public static Vector multVec(Vector t, Vector p1)
        {
            return new Vector(p1.x * t.x, p1.y * t.y, p1.z * t.z);
        }
        public static Vector operator *(float t, Vector p1)
        {
            return new Vector(p1.x * t, p1.y * t, p1.z * t);
        }

        public static Vector operator *(Vector p1, float t)
        {
            return new Vector(p1.x * t, p1.y * t, p1.z * t);
        }

        public static Vector operator /(Vector p1, float t)
        {
            return new Vector(p1.x / t, p1.y / t, p1.z / t);
        }


        public static Vector getVectorProjection(Vector origin, Vector direction, Vector projected)
        {
            float parameter = (float)((direction.x * (projected.x - origin.x) + direction.y * (projected.y - origin.y) + direction.z * (projected.z - origin.z)) / (Math.Pow(direction.x, 2) + Math.Pow(direction.y, 2) + Math.Pow(direction.z, 2)));
            return VectorOnLine(origin, direction, parameter);
        }

        public static float distance(Vector p1, Vector p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2) + Math.Pow(p2.z - p1.z, 2));
        }

        public static Vector VectorOnLine(Vector origin, Vector direction, float parameter)
        {
            return new Vector(origin.x + direction.x * parameter, origin.y + direction.y * parameter, origin.z + direction.z * parameter);
        }



    }
}
