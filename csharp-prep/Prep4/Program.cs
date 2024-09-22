using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>(); 
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        }
        while (input != 0);

        if (numbers.Count > 0)
        {
            // Core Requirements
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            
            double average = (double)sum / numbers.Count;
            int max = int.MinValue;

            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            // Stretch Challenge - Find the smallest positive number
            int smallestPositive = int.MaxValue;
            foreach (int number in numbers)
            {
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Check if there was a positive number in the list
            if (smallestPositive != int.MaxValue)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("There are no positive numbers.");
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
