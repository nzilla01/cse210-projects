using System;

public class Assignment
{
    protected string _studentName;
    protected string _topic;

// constructor in the assignment class
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

//method to return 
    public string GetSummary()
    {
        return $"Studnet: {_studentName}, Topic: {_topic}";
    }
}