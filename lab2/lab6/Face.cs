using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Face
    {
        List<Edge> edges;
        List<Point3D> points;

        public Face(List<Point3D> polygon)
        {
            this.points = polygon;
            edges = new List<Edge>();
            for (int i = 0; i < polygon.Count-1; i++)
            {
                edges.Add(new Edge(polygon[i], polygon[i+1]));
            }
        }
        public Face(List<Edge> polygon)
        {
            this.edges = polygon;
            points = new List<Point3D>();
            for (int i = 0; i < polygon.Count - 1; i++)
            {
                points.Add(polygon[i].left);
            }
            points.Add(polygon[polygon.Count-1].right);
        }
        private Point3D FindCentroid()
        {
            if (points.Count > 1)
            {
                Point3D res = new Point3D((float)Math.Round(points.Average(p => p.X)), (float)Math.Round(points.Average(p => p.Y)), (float)Math.Round(points.Average(p => p.Z)));
                return res;
            }
            else return new Point3D(0,0,0);
        }
    }
}
