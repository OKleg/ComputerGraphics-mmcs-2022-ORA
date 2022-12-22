using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace lab6
{
    internal class RotateFigure : Polyhedron
    {
        /*public Polyhedron RotateFigureCreate(List<Vector> generatrix, int splits, string axis)
        {
            List<Vector> res = new List<Vector>();
            var ObrCount = generatrix.Count;
            float RotateAngle = (float)360.0 / splits; 
            res.AddRange(generatrix); // записываем точки образующей по сути это первое состояние, нулевой поворот 

            Polyhedron RotateFigure = new Polyhedron();
            List<Edge> Edges = new List<Edge>();
            List<Face> Faces = new List<Face>();

            //теперь по идее нужно как то поворачивать точки в образующей относительно выбранной оси
            //делаем цикл по колву разбиений 
            for (int i = 1; i < splits; i++)
            {
                //получаем матрицу поворота для текущего угла, в зависимости от выбраной оси вращения
                //Matrix m = Matrix.getRotation(RotateAngle * i, axis);
                var RotateGeneratrix = Matrix.RotatePoints(generatrix, RotateAngle * i, axis);
                res.AddRange(RotateGeneratrix);
                for (int j = 0; j < generatrix.Count-1; j++) // соединяем точки прошлого вращения и текущего
                {
                    //Faces.Add(new Face(new List<int> { (i - 1) + j, (i - 1) + j + 1, j + i* ObrCount, j + i * ObrCount + 1 }));
                    Faces.Add(new Face(new List<int> {j + ObrCount* (i-1), j + ObrCount * i, j + ObrCount * i +1, j + ObrCount * (i - 1) +1 }));
                }              

            }
            //осталось соеденить 0ое разбиение с последним и сделать низ с верхом
            for (int j = 0; j < generatrix.Count - 1; j++) 
            {
                Faces.Add(new Face(new List<int> { j,j + (splits-1) * ObrCount, j + (splits - 1) * ObrCount +1, j+1 }));
            }
            //верх
            Faces.Add(new Face(Enumerable.Range(0, res.Count).Where(i => i % ObrCount == 0).ToList()));
            //низ
            Faces.Add(new Face(Enumerable.Range(ObrCount - 1, res.Count).Where(i => (i-2) % ObrCount == 0).ToList()));

            foreach (var f in Faces) //добавляем ребра
            {
                Edges.AddRange(f.GetEdges());
            }

        }*/
        public RotateFigure(List<Vector> generatrix, int splits, string axis) : base()
        {
            var ObrCount = generatrix.Count;
            float RotateAngle = (float)360.0 / splits;

            this.vertices.AddRange(generatrix); // записываем точки образующей по сути это первое состояние, нулевой поворот 

            //теперь по идее нужно как то поворачивать точки в образующей относительно выбранной оси
            //делаем цикл по колву разбиений 
            for (int i = 1; i < splits; i++)
            {
                //получаем матрицу поворота для текущего угла, в зависимости от выбраной оси вращения
                //Matrix m = Matrix.getRotation(RotateAngle * i, axis);
                var RotateGeneratrix = Matrix.RotatePoints(generatrix, RotateAngle * i, axis);
                this.vertices.AddRange(RotateGeneratrix);
                for (int j = 0; j < generatrix.Count - 1; j++) // соединяем точки прошлого вращения и текущего
                {
                    //Faces.Add(new Face(new List<int> { (i - 1) + j, (i - 1) + j + 1, j + i* ObrCount, j + i * ObrCount + 1 }));
                    this.faces.Add(new Face(new List<int> { j + ObrCount * (i - 1), j + ObrCount * i, j + ObrCount * i + 1, j + ObrCount * (i - 1) + 1 }));
                }
            }

            //осталось соеденить 0ое разбиение с последним и сделать низ с верхом
            for (int j = 0; j < generatrix.Count - 1; j++)
            {
                this.faces.Add(new Face(new List<int> { j, j + (splits - 1) * ObrCount, j + (splits - 1) * ObrCount + 1, j + 1 }));
            }
            //верх
            this.faces.Add(new Face(Enumerable.Range(0, this.vertices.Count).Where(i => i % ObrCount == 0).ToList()));
            //низ
            this.faces.Add(new Face(Enumerable.Range(ObrCount - 1, this.vertices.Count).Where(i => (i - 2) % ObrCount == 0).ToList()));

            foreach (var f in this.faces) //добавляем ребра
            {
                this.edges.AddRange(f.GetEdges());
            }
        }
    }

    
}
