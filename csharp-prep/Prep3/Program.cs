using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        string magicNumber = Console.ReadLine();
        int number = int.Parse(magicNumber);

        int guess = 0;

        while (number  != guess ){
         Console.Write("What is your guess? ");
        string yourGuess = Console.ReadLine();
         guess = int.Parse(yourGuess);

         if ( number > guess){
            Console.WriteLine("Higher");
         }
         else if (number < guess){
            Console.WriteLine("Lower");
         }
        }
            Console.WriteLine("you guesses it !");
         
        
    }
}