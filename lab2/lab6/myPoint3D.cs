using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class myPoint3D
    {

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public myPoint3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public myPoint3D(float x, float y, float z)
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
