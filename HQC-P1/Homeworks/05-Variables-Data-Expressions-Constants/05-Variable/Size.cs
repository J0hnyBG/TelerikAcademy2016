public class Size
{
    public double Width;

    public double Height;

    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public static Size GetRotatedSize(Size size, double angleOfRotation)
    {
        return new Size(
                        Math.Abs(Math.Cos(angleOfRotation)) * size.Width + Math.Abs(Math.Sin(angleOfRotation)) * size.Height,
                        Math.Abs(Math.Sin(angleOfRotation)) * size.Width + Math.Abs(Math.Cos(angleOfRotation)) * size.Height
                        );
    }
}