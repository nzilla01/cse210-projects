using System;


abstract class MindfulnessActivity


{
    protected string Name;
    protected string Description;
    protected int Duration;

    public void StartActivity()
    {
        Console.WriteLine($"Starting {Name}");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3); // Prepares for the activity
    }
    

    public void EndActivity()
    {
        Console.WriteLine("Good job! You've completed the activity.");
        Console.WriteLine($"Activity: {Name}, Duration: {Duration} seconds");
        ShowSpinner(3); // Pause before finishing
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); // Simulates delay
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity helps you relax through deep breathing.";
    }

    public void DoBreathing()
    {
        StartActivity();
        for (int i = 0; i < Duration; i += 6) // Alternating breathing every 6 seconds
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3); // Pause for breathing in
            Console.WriteLine("Breathe out...");
            ShowSpinner(3); // Pause for breathing out
        }
        EndActivity();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = { "Think of a time when you stood up for someone...", "Think of a time when you did something difficult..." };
    private string[] questions = { "Why was it meaningful?", "What did you learn?" };

    public ReflectionActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity helps you reflect on positive moments in your life.";
    }

    public void DoReflection()
    {
        StartActivity();
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Length)]); // Random prompt
        for (int i = 0; i < Duration; i += 10)
        {
            Console.WriteLine(questions[rnd.Next(questions.Length)]); // Random question
            ShowSpinner(5); // Pause for reflection
        }
        EndActivity();
    }
}

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = { "List people you appreciate...", "List your personal strengths..." };
    
    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity helps you list the positive aspects of your life.";
    }

    public void DoListing()
    {
        StartActivity();
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Length)]); // Random listing prompt
        Console.WriteLine("Start listing items:");
        int count = 0;
        while (count < Duration)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item)) count++;
        }
        Console.WriteLine($"You listed {count} items.");
        EndActivity();
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:\n1. Breathing\n2. Reflection\n3. Listing\n4. Exit");
            string choice = Console.ReadLine();
            if (choice == "1") new BreathingActivity().DoBreathing();
            else if (choice == "2") new ReflectionActivity().DoReflection();
            else if (choice == "3") new ListingActivity().DoListing();
            else if (choice == "4") break;
        }
    }
}
