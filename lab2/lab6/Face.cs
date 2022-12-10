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
        public List<Vector> points;

        public Face(List<Vector> points, List<Edge> edges)
        {
            this.points = points;
            this.edges = edges;
        }
        private Vector FindCentroid()
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
