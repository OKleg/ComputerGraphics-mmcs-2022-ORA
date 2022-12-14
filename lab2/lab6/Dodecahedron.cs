using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Dodecahedron : Polyhedron
    {

        public Dodecahedron() : base()
        {
            this.center = new Vector(0, 0, 0);
            this.vertices = new List<Vector>(){
                new Vector(-50,  50,  50), // 0 вершина
                new Vector(-50,  50, -50), // 1 вершина
                new Vector( 50,  50, -50), // 2 вершина
                new Vector(50, 50, 50), // 3 вершина
                new Vector(-50, -50, 50), // 4 вершина
                new Vector(-50, -50, -50), // 5 вершина
                new Vector(50, -50, -50), // 6 вершина
                new Vector(50, -50, 50)  // 7 вершина
        };
            vertices.Add(center);
            this.edges = new List<Edge>{
                    new Edge(0, 1), //  0 - 1,3,4
                    new Edge(1, 2), //  1 - 0,2,5
                    new Edge(2, 3), //  2 - 1,3,6
                    new Edge(3, 0), //  3 - 0,2,7

                    new Edge(0, 4), // 4 - 0,5,7
                    new Edge(1, 5), // 5 - 1,4,6
                    new Edge(2, 6), // 6 - 2,5,7
                    new Edge(3, 7), // 7 - 3,4,6

                    new Edge(4, 5),
                    new Edge(5, 6),
                    new Edge(6, 7),
                    new Edge(7, 4),
        };
        }

    }
}
