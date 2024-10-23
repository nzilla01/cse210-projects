
public class Square : Shape
{
    private double _side;

    // Constructor for Square class
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override the GetArea method to calculate area of a square
    public override double GetArea()
    {
        return _side * _side;
    }
}
