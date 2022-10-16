using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace lab5
{
    internal class Edge
    {
        public Point left;
        public Point right;

        public Edge(Point left, Point right)
        {
            this.left = left;
            this.right = right;
        }

        public int MidX()
        {
            return (left.X + right.X)/2;
        }

        public int MidY()
        {
            return ((left.Y + right.Y)/2);
        }
 
       /* public int Shift(double R)
        {
            Random rnd = new Random();
            return rnd.Next((int)Math.Round(-R * Lenght()), (int)Math.Round(R * Lenght()));
        }*/
        public Point Mid()
        {
            return new Point(this.MidX(), this.MidY());
        }

        public Point Mid(double R)
        {
            return new Point(this.MidX(), this.MidY()); //+ Shift(R));
        }


        public double Lenght() => Math.Sqrt((right.X - left.X) * (right.X - left.X) + (right.Y - left.Y) * (right.Y - left.Y));
    }
}
