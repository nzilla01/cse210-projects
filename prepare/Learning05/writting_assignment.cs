public class WritingAssignment : Assignment
{
    public string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to return the writing information
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }
}
