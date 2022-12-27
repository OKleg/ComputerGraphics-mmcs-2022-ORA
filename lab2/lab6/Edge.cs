


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
        public bool Contains(int p)
        {
            return (p == p1 || p == p2);
        }
    }
}
