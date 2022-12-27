using System;
using System.Collections.Generic; 
namespace lab6
{
    class Icosahedron : Polyhedron
    {
        public Icosahedron() : base()
        {
            float phi = (float)((1 + Math.Sqrt(5.0)) / 2);
            float hlife = (float)(Math.Sin(45) * 30);//30 - длина ребра
            float phiMhl = phi * hlife;
            this.vertices = new List<Vector>(){
             new Vector(0, phiMhl, hlife), // A 0
             new Vector(0, -phiMhl, hlife), // B 1
             new Vector(0, phiMhl, -hlife), // C 2
             new Vector(0, -phiMhl, -hlife), // D 3

             new Vector(phiMhl, hlife, 0), // E 4
             new Vector(-phiMhl, hlife, 0), // F 5
             new Vector(phiMhl, -hlife, 0), // G 6
             new Vector(-phiMhl, -hlife, 0), // H 7

             new Vector(hlife, 0, phiMhl), // I 8
             new Vector(-hlife, 0, phiMhl), // J 9
             new Vector(hlife, 0, -phiMhl), // K 10
             new Vector(-hlife, 0, -phiMhl) // L 11
        };
            vertices.Add(new Vector(0, 0, 0));
            this.faces = new List<Face>(){
                new Face(new List<int>() { 9, 8, 0 },this),
                new Face(new List<int>() { 5, 9, 0 },this),
                new Face(new List<int>() { 0, 8, 4 },this),
                new Face(new List<int>() { 4, 2, 0 },this),
                new Face(new List<int>() { 0, 2, 5 },this),
                new Face(new List<int>() { 1, 6, 8 },this),
                new Face(new List<int>() { 1, 8, 9 },this),
                new Face(new List<int>() { 1, 9, 7 },this),
                new Face(new List<int>() { 1, 7, 3 },this),
                new Face(new List<int>() { 1, 3, 6 },this),
                new Face(new List<int>() { 9, 5, 7 },this),
                new Face(new List<int>() { 8, 6, 4 },this),
                new Face(new List<int>() { 5, 2, 11 },this),
                new Face(new List<int>() { 5, 11, 7 },this),
                new Face(new List<int>() { 7, 11, 3 },this),
                new Face(new List<int>() { 6, 3, 10 },this),
                new Face(new List<int>() { 6, 10, 4 },this),
                new Face(new List<int>() { 4, 10, 2 },this),
                new Face(new List<int>() { 2, 10, 11 },this),
                new Face(new List<int>() { 11, 10, 3 },this)
        };

            foreach (var f in this.faces)
            {
                this.edges.AddRange(f.getEdges());
            }
        }
        public Icosahedron(float ed) : base()
        {
            float phi = (float)((1 + Math.Sqrt(5.0)) / 2);
            float hlife = (float)(Math.Sin(45) * ed);//30 - длина ребра
            float phiMhl = phi * hlife;
            this.vertices = new List<Vector>(){
             new Vector(0, phiMhl, hlife), // A 0
             new Vector(0, -phiMhl, hlife), // B 1
             new Vector(0, phiMhl, -hlife), // C 2
             new Vector(0, -phiMhl, -hlife), // D 3

             new Vector(phiMhl, hlife, 0), // E 4
             new Vector(-phiMhl, hlife, 0), // F 5
             new Vector(phiMhl, -hlife, 0), // G 6
             new Vector(-phiMhl, -hlife, 0), // H 7

             new Vector(hlife, 0, phiMhl), // I 8
             new Vector(-hlife, 0, phiMhl), // J 9
             new Vector(hlife, 0, -phiMhl), // K 10
             new Vector(-hlife, 0, -phiMhl) // L 11
            };
            vertices.Add(new Vector(0, 0, 0));
            this.faces = new List<Face>(){
                new Face(new List<int>() { 9, 8, 0 },this),
                new Face(new List<int>() { 5, 9, 0 },this),
                new Face(new List<int>() { 0, 8, 4 },this),
                new Face(new List<int>() { 4, 2, 0 },this),
                new Face(new List<int>() { 0, 2, 5 },this),
                new Face(new List<int>() { 1, 6, 8 },this),
                new Face(new List<int>() { 1, 8, 9 },this),
                new Face(new List<int>() { 1, 9, 7 },this),
                new Face(new List<int>() { 1, 7, 3 },this),
                new Face(new List<int>() { 1, 3, 6 },this),
                new Face(new List<int>() { 9, 5, 7 },this),
                new Face(new List<int>() { 8, 6, 4 },this),
                new Face(new List<int>() { 5, 2, 11 },this),
                new Face(new List<int>() { 5, 11, 7 },this),
                new Face(new List<int>() { 7, 11, 3 },this),
                new Face(new List<int>() { 6, 3, 10 },this),
                new Face(new List<int>() { 6, 10, 4 },this),
                new Face(new List<int>() { 4, 10, 2 },this),
                new Face(new List<int>() { 2, 10, 11 },this),
                new Face(new List<int>() { 11, 10, 3 },this)
            };

            foreach (var f in this.faces)
            {
                this.edges.AddRange(f.getEdges());
            }
        }
    }
}
