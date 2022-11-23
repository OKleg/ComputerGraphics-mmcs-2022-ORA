using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Polyhedron
    {
        public List<Face> faces;
        public HashSet <Point3D> points;
        public Polyhedron(List<Face> polyhedron)
        {
            this.faces = polyhedron;
            foreach (var polig in polyhedron)
            {
                foreach (var point in polig.points)
                {
                    this.points.Add(point);
                }
            }
        }
    }
}
