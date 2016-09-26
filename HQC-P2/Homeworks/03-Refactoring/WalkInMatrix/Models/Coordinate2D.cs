namespace WalkInMatrix.Models
{
    /// <summary>
    /// Provides a model for a 2D coordinate.
    /// </summary>
    public class Coordinate2D
    {
        /// <summary>
        ///     Instantiates a new Coordinate2D with default values.
        /// </summary>
        public Coordinate2D()
        {
            this.Row = 0;
            this.Col = 0;
        }

        /// <summary>
        ///     Instantiates a new Coordinate2D with specified row and column values.
        /// </summary>
        public Coordinate2D(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        /// <summary>
        ///     Gets a new Coordinate2D with default values.
        /// </summary>
        public static Coordinate2D Zero => new Coordinate2D();

        /// <summary>
        ///     Gets or sets the row value of the Coordinate2D instance.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        ///     Gets or sets the column value of the Coordinate2D instance.
        /// </summary>
        public int Col { get; set; }

        public static Coordinate2D operator +(Coordinate2D c1, Coordinate2D c2)
        {
            return new Coordinate2D(c1.Row + c2.Row, c1.Col + c2.Col);
        }

        public static Coordinate2D operator -(Coordinate2D c1, Coordinate2D c2)
        {
            return new Coordinate2D(c1.Row - c2.Row, c1.Col - c2.Col);
        }

        public override string ToString()
        {
            return $"{this.Row} : {this.Col}";
        }
    }
}
