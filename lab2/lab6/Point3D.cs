using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Point3D
    {

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public string ToString()
        {
            return  " [x=" + X + ",y=" + Y + "z=" + Z + "] "; 
        }
    }
}
