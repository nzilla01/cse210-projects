// Shape.cs
public abstract class Shape
{
    private string _color;

    // Constructor for Shape class
    public Shape(string color)
    {
        _color = color;
    }

    // Getter and Setter for color
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method to calculate area (to be overridden in derived classes)
    public abstract double GetArea();
}
