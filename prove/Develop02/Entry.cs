using System;
using System.IO;
public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _streak;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        if (_streak != null && _streak != "") // Only display this last line if the entry has a streak field filled in. 
            Console.WriteLine($"{_streak} day journal streak!");
        Console.WriteLine();
    }
    public string ToFileLine(string separator)
    {
        // converts the entry into a string to be stored in a file
        string line = ($"{_date}{separator}{_prompt}{separator}{_response}{separator}{_streak}");

        return line;

    }
    public Entry FromFileLine(string line, string separator)
    {
        Entry lineEntry = new Entry();
        // splits the line into different sections 
        string[] parts = line.Split(separator);
        // stores those sections into Entry fields
        lineEntry._date = parts[0];
        lineEntry._prompt = parts[1];
        lineEntry._response = parts[2];
        lineEntry._streak = parts[3];

        return lineEntry;
    }
}