using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Polyhedron
    {
        List<Face> faces;

        public Polyhedron(List<Face> polyhedron)
        {
            this.faces = polyhedron;
           
        }
    }
}
