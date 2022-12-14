using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Icosahedron : Polyhedron
    {

        public Icosahedron() : base()
        {
            this.center = new Vector(0, 0, 0);
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
            vertices.Add(center);
            this.faces = new List<Face>(){
                new Face(new List<int>() { 9, 8, 0 }),
                new Face(new List<int>() { 5, 9, 0 }),
                new Face(new List<int>() { 0, 8, 4 }),
                new Face(new List<int>() { 4, 2, 0 }),
                new Face(new List<int>() { 0, 2, 5 }),
                new Face(new List<int>() { 1, 6, 8 }),
                new Face(new List<int>() { 1, 8, 9 }),
                new Face(new List<int>() { 1, 9, 7 }),
                new Face(new List<int>() { 1, 7, 3 }),
                new Face(new List<int>() { 1, 3, 6 }),
                new Face(new List<int>() { 9, 5, 7 }),
                new Face(new List<int>() { 8, 6, 4 }),
                new Face(new List<int>() { 5, 2, 11 }),
                new Face(new List<int>() { 5, 11, 7 }),
                new Face(new List<int>() { 7, 11, 3 }),
                new Face(new List<int>() { 6, 3, 10 }),
                new Face(new List<int>() { 6, 10, 4 }),
                new Face(new List<int>() { 4, 10, 2 }),
                new Face(new List<int>() { 2, 10, 11 }),
                new Face(new List<int>() { 11, 10, 3 })
        };
            foreach (var f in this.faces)
            {
                this.edges.AddRange(f.GetEdges());
            }
        }
        
    }
}
