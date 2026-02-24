using System;
using System.Reflection.Metadata;

class Program
{ // Mary Waters - European History
//The Causes of World War II by Mary Waters
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Joe", "mamma");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment("Mark", "Word Problems", "2.3", "5-15");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(assignment.GetWritingInformation());
    }
}