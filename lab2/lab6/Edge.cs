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
        public int p1;
        public int p2;

        public Edge(int p1, int p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

       /* public float MidX()
        {
            return (p1.x + p2.x) /2;
        }

        public float MidY()
        {
            return ((p1.y + p2.y) /2);
        }
        public float MidZ()
        {
            return ((p1.z + p2.z) / 2);
        }
        public Vector Mid()
        {
            return new Vector(this.MidX(), this.MidY(), this.MidZ());
        }
        
        public double Lenght() => Math.Sqrt((
                      (p2.x - p1.x) * (p2.x - p1.x)
                    + (p2.y - p1.y) * (p2.y - p1.y)
                    + (p2.z - p1.z) * (p2.z - p1.z)));*/
    }
}
