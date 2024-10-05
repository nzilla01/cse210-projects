using System;
using System.Collections.Generic;

class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }
}

class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        isHidden = false;
    }

    public bool IsHidden => isHidden;

    public void Hide()
    {
        isHidden = true;
    }

    public override string ToString()
    {
        return isHidden ? "_____" : text;
    }
}

class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> words;
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public void HideWords(int count)
    {
        int hiddenCount = 0;
        while (hiddenCount < count)
        {
            int index = random.Next(words.Count);
            if (!words[index].IsHidden)
            {
                words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool AllWordsHidden()
    {
        return words.TrueForAll(word => word.IsHidden);
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(Reference);
        Console.WriteLine(string.Join(" ", words));
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that He gave His only begotten Son"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding"),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ who strengthens me"),
        };

        // Loop through each scripture
        foreach (var scripture in scriptures)
        {
            while (true)
            {
                scripture.Display();
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to move to the next scripture.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideWords(2);  // Hide 2 words each time

                if (scripture.AllWordsHidden())
                {
                    scripture.Display();
                    Console.WriteLine("\nAll words are hidden. Moving to the next scripture.");
                    break;
                }
            }
        }

        Console.WriteLine("All scriptures have been processed.");
    }
}

