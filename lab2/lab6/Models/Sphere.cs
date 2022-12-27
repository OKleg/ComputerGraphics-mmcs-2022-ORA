using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab6
{
    public class Sphere : Polyhedron
    {
        float radius;

        public Sphere(Vector p, float r)
        {
            vertices.Add(p);
            radius = r;
            
        }
        public Sphere(Vector center, float radius, Color color, Material material)
        {
            vertices.Add(center);
            this.center = center;
            this.radius = radius;
            this.color = color;
            this.material = material;
        }

        public static bool RaySphereIntersection(Ray r, Vector sphCenter, float SphRadius, out float insect)
        {
            Vector centerRay = r.start - sphCenter;
            float b = Vector.scalar(centerRay, r.direction);
            float c = Vector.scalar(centerRay, centerRay) - SphRadius * SphRadius;
            float d = b * b - c;
            insect = 0;
            if (d >= 0)
            {
                float sqrtd = (float)Math.Sqrt(d);
                float t1 = -b + sqrtd;
                float t2 = -b - sqrtd;

                float min = Math.Min(t1, t2);
                float max = Math.Max(t1, t2);

                insect = (min > eps) ? min : max;
                return insect > eps;
            }
            return false;
        }

        public override bool isIntersection(Ray r, out float insect, out Vector normal, out Face outFace)
        {
            outFace = null;
            if (RaySphereIntersection(r, vertices[0], radius, out insect) && (insect > eps))
            {
                normal = (r.start + r.direction * insect) - vertices[0];
                normal = Vector.normalize(normal);
                return true;
            } 
            normal = null;
            insect = 0;
            return false;
        }
        /*
        public static  bool RaySphereIntersection2(Ray r, Vector sphCenter, float SphRadius, out float distance, out Vector normal)
        {
            distance = 0;
            normal = new Vector(0,0,0);
            r.direction = r.direction.normalize();
            Vector sourceTosphCenter = new Vector(r.start, sphCenter);
            if (Vector.scalar(sourceTosphCenter, r.direction) < 0)  // Центр сферы за точкой выпуска луча
            {
                if (Vector.distance(r.start, sphCenter) > SphRadius)// Пересечений нет
                {
                    return false;
                }
                else if (Vector.distance(r.start, sphCenter) - SphRadius < eps) //  на сфере
                {
                    return false;
                }
                else  //  внутри сферы
                {
                    Vector projection = Vector.getVectorProjection(r.start, r.direction, sphCenter);
                    distance = (float)(Math.Sqrt(Math.Pow(SphRadius, 2) - Math.Pow(Vector.distance(sphCenter, projection), 2)) - Vector.distance(r.start, projection));
                    normal = new Vector(sphCenter, (r.start + r.direction * distance)).normalize();
                    return  true;
                }
            }
            else        // Центр сферы можно спроецировать на луч
            {
                Vector projection = Vector.getVectorProjection(r.start, r.direction, sphCenter);
                if (Vector.distance(sphCenter, projection) > SphRadius)
                {
                    return false;
                }
                else
                {
                    distance = (float)Math.Sqrt(Math.Pow(SphRadius, 2) - Math.Pow(Vector.distance(sphCenter, projection), 2));
                    if (Vector.distance(r.start, sphCenter) > SphRadius)
                    {
                        distance = Vector.distance(r.start, projection) - distance;
                    }
                    else
                    {
                        distance = Vector.distance(r.start, projection) + distance;
                    }
                    normal = new Vector(sphCenter, (r.start + r.direction * distance)).normalize();
                    return true;
                }
            } 
       
        }*/

    }
}
