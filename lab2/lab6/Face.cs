using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Face
    {
        public List<Edge> edges;
        public List<int> points;
        public Face(List<int> points)
        {
            this.points = points;
            edges = new List<Edge>();
            edges.Add(new Edge(points[0], points[points.Count-1]));
            for (int i = 0; i < points.Count-1; i++)
            {
                edges.Add(new Edge(points[i], points[i + 1]));
            }
        }

        public Face()
        {
        }

        public List<Edge> GetEdges()
        {
            return edges;
        }
        public Face(List<int> points, List<Edge> edges)
        {
            this.points = points;
            this.edges = edges;
        }
       static public Vector FindCentroid(List<Vector>  points)
        {
            if (points.Count > 1)
            {
                Vector res = new Vector((float)Math.Round(points.Average(p => p.x)), (float)Math.Round(points.Average(p => p.y)), (float)Math.Round(points.Average(p => p.z)));
                return res;
            }
            else return new Vector(0,0,0);
        }
    }
}
