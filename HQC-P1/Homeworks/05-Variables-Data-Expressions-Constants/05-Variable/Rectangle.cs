public class Rectangle
{
    private double width;

    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public static Rectangle GetRotatedRectangle(Rectangle rectangle, double angleOfRotation)
    {
        var angleOfRotationCosinus = Math.Abs(Math.Cos(angleOfRotation));
        var angleOfRotationSinus = Math.Abs(Math.Sin(angleOfRotation));

        var rotatedWidth = ( angleOfRotationSinus * rectangle.width ) + ( angleOfRotationCosinus * rectangle.height );
        var rotatedHeight = ( angleOfRotationCosinus * rectangle.width ) + ( angleOfRotationSinus * rectangle.height );

        var rotatedRectangle = new Rectangle(rotatedWidth, rotatedHeight);

        return rotatedRectangle;
    }
}