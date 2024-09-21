using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        string letter = "";
        string sign = "";
        // determine the letter grade

        if (percentage >= 90){
             letter = "A" ;
        }
        else if ( percentage >= 80){
            letter = "B";
        }
        else if ( percentage >= 70 ){
            letter ="C";
        }
        else if ( percentage >=60) {
            letter = "D";
        }
        else{
            letter ="F";
        }

           if (letter != "A" && letter != "F")
        {
            int lastDigit = percentage % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($" Your grade is : {letter}{sign}");

        if (percentage >= 70 ){
            Console.WriteLine("Congrats! youv'e pased thee course.");
        }
        else {
            Console.WriteLine(" Oh! Not too bad, but keep pushing—you didn’t pass the course this time.");
        }


    }
}