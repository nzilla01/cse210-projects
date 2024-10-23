
public class Circle : Shape
{
    private double _radius;

    // Constructor for Circle class
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the GetArea method to calculate area of a circle
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
