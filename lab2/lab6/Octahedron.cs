using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Octahedron : Polyhedron
    {

        public Octahedron() : base()
        {
           
            this.vertices = new List<Vector>(){
                  new Vector(0, 50, 0), // 0 вершина

                  new Vector(-50, 0, 50), // 1 вершина
                  new Vector(-50, 0, -50), // 2 вершина
                  new Vector(50, 0, -50), // 3 вершина
                  new Vector(50, 0, 50), // 4 вершина

                  new Vector(0, -50, 0), // 5 вершина
        };
            this.edges = new List<Edge>{
                    new Edge(0, 1),
                    new Edge(0, 2),
                    new Edge(0, 3),
                    new Edge(0, 4),

                    new Edge(1, 2),
                    new Edge(2, 3),
                    new Edge(3, 4),
                    new Edge(4, 1),

                    new Edge(5, 1),
                    new Edge(5, 2),
                    new Edge(5, 3),
                    new Edge(5, 4),
        };
        }
    }
}
