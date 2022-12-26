using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace lab6
{
    public class Light : Polyhedron      //  точечный источник света
    {
        public Vector ColorL;       // цвет источника света в виде Вектора

        public Light(Vector p, Vector c)
        {
            center = new Vector(p);
            vertices.Add(center);
            ColorL = new Vector(c);
            var col = ColorL.normalize();
            color = Color.FromArgb((int)(255 * col.x), (int)(255 * col.y), (int)(255 * col.z));
        }
        
        // Считаем цвет в одной точке (по факту это дифузное освещение)
        public Vector Shade(Vector inPoint, Vector normal, Vector material_color, float diffuse_coef)
        {
            Vector dir = Vector.normalize(center - inPoint);// направление луча 
           //если угол между нормалью и направлением луча больше 90 градусов,то диффузное  освещение равно 0
            Vector diff = diffuse_coef * ColorL * Math.Max(Vector.scalar(normal, dir), 0);
            return new Vector(diff.x * material_color.x, diff.y * material_color.y, diff.z * material_color.z);
        }
    }
}
