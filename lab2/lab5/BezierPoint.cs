using System;

using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class BezierPoint
    {
        public Point p1;
        public Point r;
        public Point p2;
        public BezierPoint(Point R)
        {
            this.p1 = new Point(R.X - 20, R.Y);
            this.p2 = new Point(R.X + 20, R.Y);
            this.r = R;
        }
        public void SetP1(Point P1)
        {
            this.p1 = P1;
            this.p2 = new Point(r.X+ (r.X-p1.X), r.Y + (r.Y - p1.Y));
        }
        public void SetP2(Point P2)
        {
            this.p2 = P2;
            this.p1 = new Point(r.X + (r.X - p2.X), r.Y + (r.Y - p2.Y));
        }
        public void SetR(Point R)
        {
            Point t1 =  new Point(R.X + (r.X - p2.X), R.Y + (r.Y - p2.Y));
            Point t2 =new Point(R.X + (r.X - p1.X), R.Y + (r.Y - p1.Y));
            this.p1 = t1;
            this.p2 = t2;
            this.r = R;
        }
    }
}

