
using System.Collections.Generic;

namespace lab6
{
    public class Edge
    {
        public int p1;
        public int p2;

        public Edge(int p1, int p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public static Edge Contains(List<Edge> ed, int v1, int v2)
        {
            foreach (var e in ed)
            {
                if ((v1 == e.p1 && v2 == e.p2) || (v2 == e.p1 && v1 == e.p2))
                {
                    return e;
                }
            }
            return null;
        }

        public Edge()
        {
        }
    }
}
