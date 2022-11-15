using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Polygon
    {
        LinkedList<myPoint3D> points;
        LinkedList<Edge> edges;

        myPoint3D center;

        public Polygon(LinkedList<myPoint3D> polygon)
        {
            this.points = polygon;
            var node0 = polygon.Last;
            var node = polygon.First;
            for (int i = 0; i < polygon.Count; i++)
            {
                edges.AddLast(new Edge(node0.Value, node.Value));
                node0 = node;
                node = node0.Next;
            }
            }
        public Polygon(LinkedList<Edge> polygon)
        {
            this.edges = polygon;
        }
        private myPoint3D FindCentroid()
        {
            if (points.Count > 1)
            {
                myPoint3D res = new myPoint3D((int)Math.Round(points.Average(p => p.X)), (int)Math.Round(points.Average(p => p.Y)), (int)Math.Round(points.Average(p => p.Z)));
                return res;
            }
            else return new myPoint3D(0,0,0);
        }
    }
}
