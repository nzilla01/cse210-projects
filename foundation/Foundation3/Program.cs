using System;

// Base Class
public class Activity
{
    protected DateTime date;
    protected int duration;

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Activity ({duration} min): Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}

// Derived Classes
public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
    public override double GetSpeed() => (distance / duration) * 60;
    public override double GetPace() => duration / distance;
}

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => speed * (duration / 60.0);
    public override double GetSpeed() => speed;
    public override double GetPace() => 60 / speed;
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * 50 / 1000.0;
    public override double GetSpeed() => GetDistance() / duration * 60;
    public override double GetPace() => duration / GetDistance();
}

// Main Program
public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 3), 45, 15),
            new Swimming(new DateTime(2022, 11, 3), 25, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
