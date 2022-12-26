using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;
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
        public Color color;
        public Polyhedron(  List<Vector> vertices,  List<Edge> edges ) {
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
        public virtual bool isIntersection(Ray r, out float intersectDist, out Vector normal)
        {
            intersectDist = 0;
            normal = null;
            Face faceRes = null;
            foreach (Face face in faces)
            {
                //треугольная грань
                if (face.points.Count == 3)
                {
                    if (RayIntersectsTriangle(r, face.getPoint(0), face.getPoint(1), face.getPoint(2), out float insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        faceRes = face;
                    }
                }

                //четырехугольная грань
                else if (face.points.Count == 4)
                {
                    if (RayIntersectsTriangle(r, face.getPoint(0), face.getPoint(1), face.getPoint(3), out float insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        faceRes = face;
                    }
                    else if (RayIntersectsTriangle(r, face.getPoint(1), face.getPoint(2), face.getPoint(3), out insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        faceRes = face;
                    }
                }
                //четырехугольная грань
                else if (face.points.Count == 5)
                {
                    if (RayIntersectsTriangle(r, face.getPoint(0), face.getPoint(1), face.getPoint(3), out float insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        faceRes = face;
                    }
                    else if (RayIntersectsTriangle(r, face.getPoint(1), face.getPoint(2), face.getPoint(3), out insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        faceRes = face;
                    }
                    else if (RayIntersectsTriangle(r, face.getPoint(0), face.getPoint(3), face.getPoint(4), out insect) && (intersectDist == 0 || insect < intersectDist))
                    {
                        intersectDist = insect;
                        faceRes = face;
                    }
                }
            }
            if (intersectDist != 0)
            {
                normal = Face.norm(faceRes);
                material.color = new Vector(faceRes.pen.Color.R / 255f, faceRes.pen.Color.G / 255f, faceRes.pen.Color.B / 255f);
                return true;
            }
            return false;
        }

        public float[,] GetMatrix()
        {
            var res = new float[vertices.Count, 4];
            Parallel.For(0, vertices.Count, (i) =>
            {
                res[i, 0] = vertices[i].x;
                res[i, 1] = vertices[i].y;
                res[i, 2] = vertices[i].z;
                res[i, 3] = 1;
            });
            return res;
        }

        public void ApplyMatrix(float[,] matrix)
        {
            Parallel.For(0, vertices.Count, (i) =>
            {
                vertices[i].x = matrix[i, 0] / matrix[i, 3];
                vertices[i].y = matrix[i, 1] / matrix[i, 3];
                vertices[i].z = matrix[i, 2] / matrix[i, 3];
            });
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
            res.x /= vertices.Count();
            res.y /= vertices.Count();
            res.z /= vertices.Count();
            return res;
        }

        public void RotateArondRad(float rangle, string type)
        {
            float[,] mt = GetMatrix();
            Vector center = GetCenter();
            switch (type)
            {
                case "CX":
                    mt = ApplyOffset(mt, -center.x, -center.y, -center.z);
                    mt = ApplyRotation_X(mt, rangle);
                    mt = ApplyOffset(mt, center.x, center.y, center.z);
                    break;
                case "CY":
                    mt = ApplyOffset(mt, -center.x, -center.y, -center.z);
                    mt = ApplyRotation_Y(mt, rangle);
                    mt = ApplyOffset(mt, center.x, center.y, center.z);
                    break;
                case "CZ":
                    mt = ApplyOffset(mt, -center.x, -center.y, -center.z);
                    mt = ApplyRotation_Z(mt, rangle);
                    mt = ApplyOffset(mt, center.x, center.y, center.z);
                    break;
                case "X":
                    mt = ApplyRotation_X(mt, rangle);
                    break;
                case "Y":
                    mt = ApplyRotation_Y(mt, rangle);
                    break;
                case "Z":
                    mt = ApplyRotation_Z(mt, rangle);
                    break;
                default:
                    break;
            }
            ApplyMatrix(mt);
        }

        public void RotateAround(float angle, string type)
        {
            RotateArondRad(angle * (float)Math.PI / 180, type);
        }



        public void Offset(float xs, float ys, float zs)
        {
            ApplyMatrix(ApplyOffset(GetMatrix(), xs, ys, zs));
        }

        public void SetPen(Pen p)
        {
            material.color = new Vector(p.Color.R / 255f, p.Color.G / 255f, p.Color.B / 255f);
            Parallel.ForEach(faces, (s) =>
            {
                s.pen = p;
            });
        }

        private static float[,] MultiplyMatrix(float[,] m1, float[,] m2)
        {
            float[,] res = new float[m1.GetLength(0), m2.GetLength(1)];
            Parallel.For(0, m1.GetLength(0), (i) =>
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        res[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            });
            return res;
        }

        private static float[,] ApplyOffset(float[,] transform_matrix, float offset_x, float offset_y, float offset_z)
        {
            float[,] translationMatrix = new float[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { offset_x, offset_y, offset_z, 1 } };
            return MultiplyMatrix(transform_matrix, translationMatrix);
        }

        private static float[,] ApplyRotation_X(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { 1, 0, 0, 0 }, { 0, (float)Math.Cos(angle), (float)Math.Sin(angle), 0 },
                { 0, -(float)Math.Sin(angle), (float)Math.Cos(angle), 0}, { 0, 0, 0, 1} };
            return MultiplyMatrix(transform_matrix, rotationMatrix);
        }

        private static float[,] ApplyRotation_Y(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { (float)Math.Cos(angle), 0, -(float)Math.Sin(angle), 0 }, { 0, 1, 0, 0 },
                { (float)Math.Sin(angle), 0, (float)Math.Cos(angle), 0}, { 0, 0, 0, 1} };
            return MultiplyMatrix(transform_matrix, rotationMatrix);
        }

        private static float[,] ApplyRotation_Z(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { (float)Math.Cos(angle), (float)Math.Sin(angle), 0, 0 }, { -(float)Math.Sin(angle), (float)Math.Cos(angle), 0, 0 },
                { 0, 0, 1, 0 }, { 0, 0, 0, 1} };
            return MultiplyMatrix(transform_matrix, rotationMatrix);
        }

    }
}
