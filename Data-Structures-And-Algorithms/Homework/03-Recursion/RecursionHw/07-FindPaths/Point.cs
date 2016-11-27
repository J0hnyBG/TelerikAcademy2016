namespace _07_FindPaths
{
    public class Point
    {
        private int row;
        private int col;

        public Point(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row
        {
            get { return this.row; }
        }

        public int Col
        {
            get { return this.col; }
        }

        public override string ToString()
        {
            return $"({this.row}, {this.col})";
        }

        public static Point operator +(Point first, Point second)
        {
            return new Point(first.Row + second.Row, first.Col + second.Col);
        }
    }
}
