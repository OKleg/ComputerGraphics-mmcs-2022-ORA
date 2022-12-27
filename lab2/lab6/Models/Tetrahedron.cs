
using System;
using System.Collections.Generic; 

namespace lab6
{
    public class Tetrahedron : Polyhedron
    {
        public Tetrahedron(float a = 25) : base()
        {
            float pt = (float)Math.Sqrt(3);
            float cs = (float)Math.Sqrt(6) / 4;

            this.vertices = new List<Vector>(){
                    new Vector(0,a * cs, 0 ),
                    new Vector(a / pt,-a * cs/3, 0 ),
                    new Vector(-a / cs/3,-a * cs/3, a / 2),
                    new Vector(-a / cs/3,-a * cs/3, -a / 2 )

        };
            vertices.Add(new Vector(0, 0, 0));
            this.faces = new List<Face>(){
                new Face(new List<int>() { 0, 1, 2 },this),
                new Face(new List<int>() { 0, 3, 1 },this),
                new Face(new List<int>() { 0, 2, 3 },this),
                new Face(new List<int>() { 1, 3, 2 },this)
            };
            foreach (var f in this.faces)
            {
                this.edges.AddRange(f.getEdges());
            }
        }
    }
}
