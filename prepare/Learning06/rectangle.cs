
public class Rectangle : Shape
{
    private double _width;
    private double _height;

    // Constructor for Rectangle class
    public Rectangle(string color, double width, double height) : base(color)
    {
        _width = width;
        _height = height;
    }

    // Override the GetArea method to calculate area of a rectangle
    public override double GetArea()
    {
        return _width * _height;
    }
}
