using System;
using System.Collections.Generic;

namespace lab6
{
    public class Cube:Polyhedron
    {

        public Cube(float edgSiz = 50) : base()
        {
            this.vertices = new List<Vector>(){
                new Vector(-edgSiz/2,  edgSiz/2,  edgSiz/2), // 0 вершина
                new Vector(-edgSiz/2,  edgSiz/2, -edgSiz/2), // 1 вершина
                new Vector( edgSiz/2,  edgSiz/2, -edgSiz/2), // 2 вершина
                new Vector(edgSiz/2, edgSiz/2, edgSiz/2), // 3 вершина
                new Vector(-edgSiz/2, -edgSiz/2, edgSiz/2), // 4 вершина
                new Vector(-edgSiz/2, -edgSiz/2, -edgSiz/2), // 5 вершина
                new Vector(edgSiz/2, -edgSiz/2, -edgSiz/2), // 6 вершина
                new Vector(edgSiz/2, -edgSiz/2, edgSiz/2)  // 7 вершина
            };
            vertices.Add(new Vector(0, 0, 0));

            this.faces = new List<Face>(){
                new Face(new List<int>() { 3, 2, 1, 0 },this),
                new Face(new List<int>() { 4, 5, 6, 7 },this),
                new Face(new List<int>() { 2, 6, 5, 1 },this),
                new Face(new List<int>() { 0, 4, 7, 3 },this),
                new Face(new List<int>() { 1, 5, 4, 0 },this),
                new Face(new List<int>() { 2, 3, 7, 6 },this)
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
        public Cube(float W, float H) : base()
        {
            this.vertices = new List<Vector>(){
                new Vector(-H/2,  W/2,  W/2), // 0 вершина
                new Vector(-H/2,  W/2, -W/2), // 1 вершина
                new Vector( H/2,  W/2, -W/2), // 2 вершина
                new Vector(H/2, W/2, W/2), // 3 вершина
                new Vector(-H/2, -W/2, W/2), // 4 вершина
                new Vector(-H/2, -W/2, -W/2), // 5 вершина
                new Vector(H/2, -W/2, -W/2), // 6 вершина
                new Vector(H/2, -W/2, W/2)  // 7 вершина
        };
            vertices.Add(new Vector(0, 0, 0));

            this.faces = new List<Face>(){
                new Face(new List<int>() { 3, 2, 1, 0 },this),
                new Face(new List<int>() { 4, 5, 6, 7 },this),
                new Face(new List<int>() { 2, 6, 5, 1 },this),
                new Face(new List<int>() { 0, 4, 7, 3 },this),
                new Face(new List<int>() { 1, 5, 4, 0 },this),
                new Face(new List<int>() { 2, 3, 7, 6 },this)
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
