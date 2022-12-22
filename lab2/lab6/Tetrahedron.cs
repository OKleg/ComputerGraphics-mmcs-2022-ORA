
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Tetrahedron : Polyhedron
    {

        public Tetrahedron() : base()
        {
            float a = 50;
            float pt = (float)Math.Sqrt(3);
            float cs = (float)Math.Sqrt(6)/4;

            this.vertices = new List<Vector>(){
                    new Vector(0,a * cs, 0 ),
                    new Vector(a / pt,-a * cs/3, 0 ),
                    new Vector(-a / cs/3,-a * cs/3, a / 2),
                    new Vector(-a / cs/3,-a * cs/3, -a / 2 )
                  
            };
            
            this.faces = new List<Face>(){
                new Face(new List<int>() { 0, 1, 2 }),
                new Face(new List<int>() { 0, 3, 1 }),
                new Face(new List<int>() { 0, 2, 3 }),
                new Face(new List<int>() { 1, 3, 2 })
            };
            foreach (var f in this.faces)
            {
                this.edges.AddRange(f.GetEdges());
            }
        }
    }
}
