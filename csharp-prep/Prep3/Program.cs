using System;

class Program
{
    static void Main(string[] args)
    {
      // Console.Write("What is your guess? ");
      //   string yourGuess = Console.ReadLine();
      //   int guess = int.Parse(yourGuess);

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        int guess = 0;
        int counter = 0;

        while (number  != guess ){
         Console.Write("What is your guess? ");
         string yourGuess = Console.ReadLine();
         guess = int.Parse(yourGuess);

          counter++;

         if ( number > guess){
            Console.WriteLine("Higher");
         }
         else if (number < guess){
            Console.WriteLine("Lower");
         }
        }
            Console.WriteLine($"you guessed it right ! you made {counter} attempts.");
         
        
    }
}