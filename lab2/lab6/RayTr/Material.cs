using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace lab6
{
    public class Material
    {
        public float reflection;    // коэффициент отражения
        public float refraction;    // коэффициент преломления
        public float ambient;       // коэффициент фонового освещения
        public float diffuse;       // коэффициент диффузного освещения
        public float environment;   // коэффициент преломления среды
        public Vector color= new Vector(0,0,0);       

        public Material(float refl, float refr, float amb, float dif, float env = 1)
        {
            reflection = refl;
            refraction = refr;
            ambient = amb;
            diffuse = dif;
            environment = env;
        }

        public Material(Material m)
        {
            reflection = m.reflection;
            refraction = m.refraction;
            environment = m.environment;
            ambient = m.ambient;
            diffuse = m.diffuse;
            color = new Vector(m.color);
        }

        public Material() {
            reflection = 0;
            refraction = 0;
            ambient = 0;
            diffuse = 0;
            environment = 0;
        }
    }
}
