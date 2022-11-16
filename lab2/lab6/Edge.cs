using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace lab6
{
    internal class Edge
    {
        public myPoint3D left;
        public myPoint3D right;

        public Edge(myPoint3D p1, myPoint3D p2)
        {
            this.left = p1;
            this.right = p2;
        }

        public float MidX()
        {
            return (left.X + right.X) /2;
        }

        public float MidY()
        {
            return ((left.Y + right.Y) /2);
        }
        public float MidZ()
        {
            return ((left.Z + right.Z) / 2);
        }
        public myPoint3D Mid()
        {
            return new myPoint3D(this.MidX(), this.MidY(), this.MidZ());
        }
        
        public double Lenght() => Math.Sqrt((
                      (right.X - left.X) * (right.X - left.X)
                    + (right.Y - left.Y) * (right.Y - left.Y)
                    + (right.Z - left.Z) * (right.Z - left.Z)));
    }
}
