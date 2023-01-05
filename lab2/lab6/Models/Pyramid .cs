using System;
using System.Collections.Generic; 

namespace lab6
{
    public class Pyramid : Polyhedron
    { 
        public Pyramid() : base()
        {

            this.vertices = new List<Vector>(){
                  new Vector(0, (float)Math.Sqrt(50), 0), // 0 вершина

                  new Vector(-50, -50, 50), // 1 вершина
                  new Vector(-50, -50, -50), // 2 вершина
                  new Vector(50, -50, -50), // 3 вершина
                  new Vector(50, -50, 50), // 4 вершина
                  new Vector(0, 0, 0) // center
        };
           
            this.faces = new List<Face>(){
                new Face(new List<int>() { 0, 1, 2, 3 },this),
                new Face(new List<int>() { 0, 1, 5, 4 },this),
                new Face(new List<int>() { 0, 3, 7, 4 },this),
                new Face(new List<int>() { 3, 2, 6, 7 },this),
                new Face(new List<int>() { 1, 5, 6, 2 },this),
                new Face(new List<int>() { 4, 7, 6, 5 },this)
            };
            foreach (var f in this.faces)
            {
                this.edges.AddRange(f.getEdges());
                foreach (int v in f.points)
                {
                    this.vertices[v].hosts.Add(f);
                }
            }
        }
    }
}
