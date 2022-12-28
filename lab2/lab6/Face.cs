using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace lab6
{
    public class Face
    {
        public Polyhedron host = null;
        public List<Edge> edges = new List<Edge>();
        public List<int> points = new List<int>();
        public Pen pen = new Pen(Color.SlateGray);
        public Material fMaterial = null;
        public Vector Normal;
        Color color = Color.Gray;

        public Face(List<int> points, Polyhedron h = null)
        {
            host = h;
            this.points = points;
            if (this.points.Count() < 3)
                Normal = new Vector(0, 0, 0);
            else
            {
                Vector U = this.getPoint(1) - this.getPoint(0);
                Vector V = this.getPoint(this.points.Count - 1) - this.getPoint(0);
                Vector normal = U * V;
                Normal = Vector.normalize(normal);
            }
            edges = new List<Edge>();
            edges.Add(new Edge(points[0], points[points.Count - 1],this));
            for (int i = 0; i < points.Count - 1; i++)
            {
                edges.Add(new Edge(points[i], points[i + 1],this));
            }
        }
        public Face(Face s)
        {
            points = new List<int>(s.points);
            host = s.host;
            pen = s.pen.Clone() as Pen;
            Normal = new Vector(s.Normal);
            this.edges = s.edges;
        }
        public List<Edge> getEdges()
        {
            return edges;
        }

        public Vector getPoint(int index)
        {
            if (host != null)
                return host.vertices[points[index]];
            return null;
        }

        public static Vector norm(Face S)
        {
            if (S.points.Count() < 3)
                return new Vector(0, 0, 0);
            Vector U = S.getPoint(1) - S.getPoint(0);
            Vector V = S.getPoint(S.points.Count - 1) - S.getPoint(0);
            Vector normal = U * V;
            return Vector.normalize(normal);
        }

        public void CalculateFaceNormal()
        {
            Normal = norm(this);
        }
        static public Vector FindCentroid(Face face)
        {
            List<Vector> points = new List<Vector>();
            for (int i = 0; i < face.points.Count-1; i++)
            {
                points.Add(face.getPoint(i)); 
            }
            if (points.Count > 1)
            {
                Vector res = new Vector((points.Average(p => p.x)), (points.Average(p => p.y)), (points.Average(p => p.z)));
                return res;
            }
            else return new Vector(0, 0, 0);
        }
    }
}
