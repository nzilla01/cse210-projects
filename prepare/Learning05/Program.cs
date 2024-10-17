using System;

class Program
{
    static void Main(string[] args)
    {
         // Create a Math Assignment
        MathAssignment math = new MathAssignment("Samuel Bennett", "multiplication", "7.3", "3-10, 20-21");
        Console.WriteLine(math.GetSummary());  // Outputs: Student: John Doe, Topic: Fractions
        Console.WriteLine(math.GetHomeworkList());  // Outputs: Section 7.3 Problems 3-10, 20-21

        // Create a Writing Assignment
        WritingAssignment writing = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writing.GetSummary());  // Outputs: Student: Mary Waters, Topic: European History
        Console.WriteLine(writing.GetWritingInformation());  // Outputs: The Causes of World War II by Mary Waters
    }
}