using System;

using Minesweeper.Constants;

namespace Minesweeper.Models
{
    public class Score
    {
        private string name;
        private int pointCount;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.Name));
                }

                this.name = value;
            }
        }

        public int PointCount
        {
            get { return this.pointCount; }
            set
            {
                if (value < 0)
                {
                    var errorMessage = string.Format(
                                                    StringConstants.ValueCannotBeLessThanErrorMessage, 
                                                    "Point count",
                                                     "0");
                    throw new ArgumentOutOfRangeException(errorMessage);
                }

                this.pointCount = value;
            }
        }

        public Score()
        {
        }

        public Score(string name, int pointCount)
        {
            this.Name = name;
            this.PointCount = pointCount;
        }
    }
}
