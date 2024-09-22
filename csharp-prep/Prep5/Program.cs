using System;

class Program
{
    static void Main(string[] args)
    {
      DisplayWelcome();
      string userName = PromptUserName();
      int userNumber = PromptUserNumber();
      int squaredNumber = SquareNumber(userNumber);
      DisplayResult(userName, squaredNumber);
    }
    static void DisplayWelcome(){
        Console.WriteLine("Wellcome to the program!");
    }

    static string PromptUserName(){
        Console.Write(" Please enter your name: ");
        return Console.ReadLine();
    }

     static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square the user's number
    static int SquareNumber(int number){
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string name, int squaredNumber){
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}