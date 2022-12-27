using System;
using System.Collections.Generic; 

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
            vertices.Add(new Vector(0, 0, 0));

            this.faces = new List<Face>(){
                new Face(new List<int>() { 0, 1, 2 },this),
                new Face(new List<int>() { 0, 2, 3 },this),
                new Face(new List<int>() { 0, 3, 4 },this),
                new Face(new List<int>() { 0, 4, 1 },this),
                new Face(new List<int>() { 5, 1, 2 },this),
                new Face(new List<int>() { 5, 2, 3 },this),
                new Face(new List<int>() { 5, 3, 4 },this),
                new Face(new List<int>() { 5, 4, 1 },this)
            };

            foreach (var f in this.faces)
            {
                this.edges.AddRange(f.getEdges());
            }
        }

        public Octahedron(float edjSiz) : base()
        {

            this.vertices = new List<Vector>(){
                  new Vector(0, edjSiz/2, 0), // 0 вершина

                  new Vector(-edjSiz/2, 0, edjSiz/2), // 1 вершина
                  new Vector(-edjSiz/2, 0, -edjSiz/2), // 2 вершина
                  new Vector(edjSiz/2, 0, -edjSiz/2), // 3 вершина
                  new Vector(edjSiz/2, 0, edjSiz/2), // 4 вершина

                  new Vector(0, -edjSiz/2, 0), // 5 вершина
        };
            vertices.Add(new Vector(0, 0, 0));

            this.faces = new List<Face>(){
                new Face(new List<int>() { 0, 1, 2 },this),
                new Face(new List<int>() { 0, 2, 3 },this),
                new Face(new List<int>() { 0, 3, 4 },this),
                new Face(new List<int>() { 0, 4, 1 },this),
                new Face(new List<int>() { 5, 1, 2 },this),
                new Face(new List<int>() { 5, 2, 3 },this),
                new Face(new List<int>() { 5, 3, 4 },this),
                new Face(new List<int>() { 5, 4, 1 },this)
            };

            foreach (var f in this.faces)
            {
                this.edges.AddRange(f.getEdges());
            }
        }
    }
}
