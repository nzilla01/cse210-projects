using System;
using System.Collections.Generic;
using System.IO;

class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected bool _isCompleted;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _isCompleted = false;
    }

    // Method to record the event
    public virtual int RecordEvent()
    {
        _isCompleted = true;
        return _points;
    }

    // Method for status of goal
    public virtual string GetStatus()
    {
        return _isCompleted ? "[x]" : "[]";
    }

    public virtual void Display()
    {
        Console.WriteLine($"{GetStatus()} {_shortName} ({_points} points)");
    }

    // Save format for base Goal
    public virtual string SaveGoal()
    {
        return $"Goal|{_shortName}|{_description}|{_points}|{_isCompleted}";
    }

    // Load Goal from file
    public static Goal LoadGoal(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);
        return new Goal(name, description, points) { _isCompleted = isCompleted };
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

    public override string SaveGoal()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isCompleted}";
    }

    public static new SimpleGoal LoadGoal(string[] parts)
    {
        return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetStatus()
    {
        return "[]";
    }

    public override string SaveGoal()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }

    public static new EternalGoal LoadGoal(string[] parts)
    {
        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
    }
}

class CheckList : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public CheckList(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_isCompleted) return 0;

        _currentCount++;
        int pointsEarned = _points;

        if (_currentCount >= _targetCount)
        {
            pointsEarned += _bonus;
            _isCompleted = true;
        }
        return pointsEarned;
    }

    public override string GetStatus()
    {
        return _isCompleted ? "[x]" : $"[{_currentCount}/{_targetCount}]";
    }

    public override void Display()
    {
        Console.WriteLine($"{GetStatus()} {_shortName} ({_points} points each, bonus: {_bonus} points)");
    }

    public override string SaveGoal()
    {
        return $"CheckList|{_shortName}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonus}|{_isCompleted}";
    }

    public static new CheckList LoadGoal(string[] parts)
    {
        var goal = new CheckList(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[6]))
        {
            _currentCount = int.Parse(parts[5]),
            _isCompleted = bool.Parse(parts[7])
        };
        return goal;
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();

    public static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Simple Goal");
            Console.WriteLine("2. Add Eternal Goal");
            Console.WriteLine("3. Add Checklist Goal");
            Console.WriteLine("4. Display Goals");
            Console.WriteLine("5. Record Goal Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddSimpleGoal();
                    break;
                case 2:
                    AddEternalGoal();
                    break;
                case 3:
                    AddCheckListGoal();
                    break;
                case 4:
                    DisplayGoals();
                    break;
                case 5:
                    RecordGoalEvent();
                    break;
                case 6:
                    SaveAllGoals();
                    break;
                case 7:
                    LoadAllGoals();
                    break;
                case 8:
                    exit = true;
                    break;
            }
        }
    }

    static void AddSimpleGoal()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        goals.Add(new SimpleGoal(name, description, points));
    }

    static void AddEternalGoal()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        goals.Add(new EternalGoal(name, description, points));
    }

    static void AddCheckListGoal()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("Enter target count: ");
        int targetCount = int.Parse(Console.ReadLine());
        Console.Write("Enter bonus points: ");
        int bonus = int.Parse(Console.ReadLine());

        goals.Add(new CheckList(name, description, points, targetCount, bonus));
    }

    static void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            goal.Display();
        }
    }

    static void RecordGoalEvent()
    {
        Console.Write("Enter goal index: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < goals.Count)
        {
            int pointsEarned = goals[index].RecordEvent();
            Console.WriteLine($"You earned {pointsEarned} points!");
        }
    }

    static void SaveAllGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.SaveGoal());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadAllGoals()
    {
        goals.Clear();
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    switch (parts[0])
                    {
                        case "Goal":
                            goals.Add(Goal.LoadGoal(parts));
                            break;
                        case "SimpleGoal":
                            goals.Add(SimpleGoal.LoadGoal(parts));
                            break;
                        case "EternalGoal":
                            goals.Add(EternalGoal.LoadGoal(parts));
                            break;
                        case "CheckList":
                            goals.Add(CheckList.LoadGoal(parts));
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
    }
}
