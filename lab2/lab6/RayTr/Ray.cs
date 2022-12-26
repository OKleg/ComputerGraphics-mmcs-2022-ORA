using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab6
{
    public class Ray
    {
        public Vector start;
        public Vector direction;

        public Ray(Vector st, Vector end)
        {
            start = new Vector(st);
            direction = Vector.normalize(end - st);
        }

        public Ray() { }

        public Ray(Ray r)
        {
            start = r.start;
            direction = r.direction;
        }

        ///отражение из презентации
        public Ray Reflect(Vector inPoint, Vector normal)
        {
            //высчитываем направление отраженного луча
            Vector reflect_dir =
                direction - 2// падающий луч -  2 
                * normal//* нормаль к точке попадания луча на сторону
                * Vector.scalar(direction, normal);//  * на скалярное произведение падающего луча и нормали
            return new Ray(inPoint, inPoint + reflect_dir);
        }

        //преломление из презентации
        public Ray Refract(Vector inPoint, Vector normal,float refract ,float krefr)
        {
            Ray res = new Ray();
            float sclr = Vector.scalar(normal, direction);
            
            float n = refract / krefr;
            float theta = 1 - n*n * (1 - sclr * sclr);
            if (theta >= 0)
            {
                float cos = (float)Math.Sqrt(theta);
                res.start = new Vector(inPoint);
                res.direction = Vector.normalize(direction * n - (cos + n * sclr) * normal);
                return res;
            }
            else
                return null;
        }
    }

}
