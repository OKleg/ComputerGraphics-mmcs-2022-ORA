using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Polyhedron
    {
        public List<Face> faces = new List<Face>();
        public List <Vector> vertices = new List<Vector>() ;
        public Vector center;
        public List<Edge> edges = new List<Edge>();
        public List<AffineMatrix> matrices = new List<AffineMatrix>() ;
        public Polyhedron(){ }
        public Polyhedron(List<Vector> vertices, List<Edge> edges)
        {
            this.vertices = vertices;
            this.edges = edges;

        }
        public Polyhedron(List<Face> polyhedron)
        {
            this.faces = polyhedron;
            foreach (var polig in polyhedron)
            {
                foreach (var point in polig.points)
                {
                    if (!vertices.Contains(point))
                    {
                        this.vertices.Add(point);
                    }
                }
            }
        }
      
    }
}
