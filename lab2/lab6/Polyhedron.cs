using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace lab6
{
    public class Polyhedron
    {
        public static float eps = 0.0001f;
        public List<Vector> vertices = new List<Vector>();
        public List<Face> faces = new List<Face>();
        public List<Edge> edges = new List<Edge>();
        public Material material = new Material();
        public Vector center;
        public Color color = Color.Gray;
        public Polyhedron(List<Vector> vertices, List<Edge> edges)
        {
            this.edges = edges;
            this.vertices = vertices;
        }
        public Polyhedron() { }

        public bool RayIntersectsTriangle(Ray r, Vector p0, Vector p1, Vector p2, out float intersect)
        {
            intersect = -1;
            Vector edge1 = p1 - p0;
            Vector edge2 = p2 - p0;
            Vector n1 = r.direction * edge2;//векторное произведение
            float a = Vector.scalar(edge1, n1);
            if (a > -eps && a < eps)//scalar == 0
                return false;       //  луч параллелен треугольнику.

            float f = 1.0f / a;
            Vector v1 = r.start - p0;
            float u = f * Vector.scalar(v1, n1);
            if (u < 0 || u > 1)
                return false;

            Vector n2 = v1 * edge1;
            float v = f * Vector.scalar(r.direction, n2);
            if (v < 0 || u + v > 1)
                return false;//не совпадают

            // где находится точка пересечения на линии.
            float t = f * Vector.scalar(edge2, n2);
            if (t > eps)
            {
                intersect = t;
                return true;
            }
            else return false;//есть пересечение линий, но не пересечение лучей.
        }

        // пересечение луча с фигурой
        public virtual bool isIntersection(Ray r, out float intersectDist, out Vector normal, out Face outFace)
        {
            intersectDist = 0;
            normal = null;
            outFace = null;
            foreach (Face face in faces)
            {
                //треугольная грань
                if (face.points.Count == 3)
                {
                    if (RayIntersectsTriangle(r, face.getPoint(0), face.getPoint(1), face.getPoint(2), out float insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        outFace = face;
                    }
                }

                //четырехугольная грань
                else if (face.points.Count == 4)
                {
                    if (RayIntersectsTriangle(r, face.getPoint(0), face.getPoint(1), face.getPoint(3), out float insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        outFace = face;
                    }
                    else if (RayIntersectsTriangle(r, face.getPoint(1), face.getPoint(2), face.getPoint(3), out insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        outFace = face;
                    }
                }
                //четырехугольная грань
                else if (face.points.Count == 5)
                {
                    if (RayIntersectsTriangle(r, face.getPoint(0), face.getPoint(1), face.getPoint(3), out float insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        outFace = face;
                    }
                    else if (RayIntersectsTriangle(r, face.getPoint(1), face.getPoint(2), face.getPoint(3), out insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        outFace = face;
                    }
                    else if (RayIntersectsTriangle(r, face.getPoint(0), face.getPoint(3), face.getPoint(4), out insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        outFace = face;
                    }
                }
            }
            if (intersectDist != 0)
            {
                normal = Face.norm(outFace);
                material.color = new Vector(outFace.pen.Color.R / 255f, outFace.pen.Color.G / 255f, outFace.pen.Color.B / 255f);
                return true;
            }
            return false;
        }
        private Vector GetCenter()
        {
            Vector res = new Vector(0, 0, 0);
            Parallel.ForEach(vertices, (p) =>
            {
                res.x += p.x;
                res.y += p.y;
                res.z += p.z;

            });
            res.x /= vertices.Count;
            res.y /= vertices.Count;
            res.z /= vertices.Count;
            return res;
        }

        public void SetPen(Pen p)
        {
            material.color = new Vector(p.Color.R / 255f, p.Color.G / 255f, p.Color.B / 255f);
            Parallel.ForEach(faces, (s) =>
            {
                s.pen = p;
            });

        }
    }
}
