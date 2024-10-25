using System;

public class Fraction
{
    // Private attributes
    private int _numerator;
    private int _denominator;

    // Constructors
    public Fraction() 
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator) 
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator) // Initializes as numerator/denominator
    {
        _numerator = numerator;
        _denominator = denominator == 0 ? 1 : denominator; // Prevent division by zero
    }

    // Getters and Setters
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }

    public int Denominator
    {
        get { return _denominator; }
        set { _denominator = value == 0 ? 1 : value; } // Ensure denominator is not zero
    }

    // Method to get the fraction as a string
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to get the fraction as a decimal
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
