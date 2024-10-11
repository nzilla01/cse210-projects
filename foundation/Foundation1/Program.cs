using System;
using System.Collections.Generic;

// the first class which is the video class
public class Video
{
    public string _title;
    public string _author;
    public int _length; 
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        comments = new List<Comment>();
    
    }

    public void AddComment(string commenter, string commentText)
    {
        comments.Add(new Comment(commenter, commentText));
    }
    public int GetCommentCount()
    {
        return comments.Count;
    }
    public List<Comment> GetComments()
    {
        return comments;
    }
}

// the second class comment.
public class Comment
{
    public string _commenter;
    public string _text;

    public Comment(string commenter, string text)
    {
        _commenter = commenter;
        _text = text;
    }

    public string Commenter { get { return _commenter; } } 
    public string Text { get { return _text; } } 
}

// the class program which is use for runing the program
class Program
{
    static void Main(string[] args)
    {
    // the video's name, user and length of the video with 3 comment each.
        List<Video> videos = new List<Video>();

         Video video1 = new Video("C# Programming Basics", "John Doe", 600);
        video1.AddComment("Alice", "Great video! Thanks for sharing.");
        video1.AddComment("Bob", "This helped me a lot.");
        video1.AddComment("Charlie", "Can you explain more about classes?");

        Video video2 = new Video("Advanced C# Techniques", "Jane Smith", 900);
        video2.AddComment("Alice", "Very informative!");
        video2.AddComment("David", "I loved the explanation on delegates.");
        video2.AddComment("Eva", "A bit too fast-paced for me.");

        Video video3 = new Video("What is oops programming", "Nzilla", 700);
        video3.AddComment("Victor", "thanks for the explanation.");
        video3.AddComment("James", "Have always heard of oops but never took time to understand it.");
        video3.AddComment("wealth", "Nice video.");

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Commenter}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line for separation between videos
        }
    }
}