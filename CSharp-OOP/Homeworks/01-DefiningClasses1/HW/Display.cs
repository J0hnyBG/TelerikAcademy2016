namespace HW
{
    using System;
    using System.Text;

    internal class Display
    {
        private double? size;
        private int? numberOfColors;

        public Display(double? size = null, int? numberOfColors = null)
        {
            NumberOfColors = numberOfColors;
            Size = size;
        }

        public double? Size
        {
            get { return size; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Screen size must be a positive number!");
                }
                size = value;
            }
        }

        public int? NumberOfColors
        {
            get { return numberOfColors; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of display colors must be a positive number!");
                }
                numberOfColors = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            if (Size != null)
            {
                output.AppendFormat("Screen Size: {0:F2}\"\n", Size);
            }
            if (NumberOfColors != null)
            {
                output.AppendFormat("Screen Colors: {0}\n", NumberOfColors);
            }

            return output.ToString();
        }
    }
}