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

            float phi = (float)((1 + Math.Sqrt(5.0)) / 2);
            //float phi =  (float)(Math.Sin(45) * 5);
            //float line = 30;
            //float hlife = (float)(1 / Math.Sqrt(2) * 30);
            float hlife = (float)(Math.Sin(45) * 30);
            float phiMhl = (float)(phi * hlife);
            float hlDphi = (float)(hlife / phi);
            this.vertices = new List<Vector>(){

                new Vector(0, hlDphi, phiMhl),// A 0
                new Vector(0, -hlDphi, phiMhl),// B 1
                new Vector(0, hlDphi, -phiMhl),// C 2
                new Vector(0, -hlDphi, -phiMhl),// D 3

                new Vector(hlDphi, phiMhl, 0),// E 4
                new Vector(-hlDphi, phiMhl, 0),// F 5
                new Vector(hlDphi, -phiMhl, 0),// G 6
                new Vector(-hlDphi, -phiMhl, 0),// H 7

                new Vector(phiMhl, 0, hlDphi),// I 8
                new Vector(-phiMhl, 0, hlDphi),// J 9
                new Vector(phiMhl, 0, -hlDphi),// K 10
                new Vector(-phiMhl, 0, -hlDphi),// L 11

                new Vector(hlife, hlife, hlife),// M 12
                new Vector(hlife, hlife, -hlife),// N 13
                new Vector(hlife, -hlife, hlife),// O 14
                new Vector(hlife, -hlife, -hlife),// P 15
                new Vector(-hlife, hlife, hlife),// Q 16
                new Vector(-hlife, hlife, -hlife),// R 17
                new Vector(-hlife, -hlife, hlife),// S 18
                new Vector(-hlife, -hlife, -hlife)// T 19
            };
          // 0 - 14,8,12,16,9,18,4,5,1
          // 1 - 0,14,18,12,9,16,8,7,6
          // 6 - 15,10,8,14,7,1,3,19,18
            vertices.Add(center);
            this.faces = new List<Face>(){
                new Face(new List<int>() { 0, 1, 14, 8, 12 }),// 0 - 1,12,16
                new Face(new List<int>(){ 16, 9, 18, 1, 0 }),// 1 - 0,14,18
                new Face(new List<int>(){ 0, 12, 4, 5, 16 }),
                new Face(new List<int>(){ 12, 8, 10, 13, 4 }),
                new Face(new List<int>(){ 6, 15, 10, 8, 14 }),// 4 - 5,12,13
                new Face(new List<int>(){ 7, 6, 14, 1, 18 }),// 6 - 7,14,15
                new Face(new List<int>(){ 9, 11, 19, 7, 18 }),
                new Face(new List<int>(){ 9, 16, 5, 17, 11 }),
                new Face(new List<int>(){ 19, 3, 15, 6, 7 }),
                new Face(new List<int>(){ 13, 2, 17, 5, 4 }),//12 - 0,4,8
                new Face(new List<int>(){ 15, 3, 2, 13, 10 }),
                new Face(new List<int>() { 2, 3, 19, 11, 17 })//18 - 1,7,9
       
        };
         foreach (var f in this.faces)
            {
                this.edges.AddRange(f.GetEdges());
            }
}

    }
}
