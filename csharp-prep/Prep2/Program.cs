using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userStringNumber = Console.ReadLine();
        int userIntNumber = int.Parse(userStringNumber);

        string letter = "";

        if (userIntNumber >= 90)
        {
             letter = "A";
        }
        else if (userIntNumber >= 80)
        {
             letter = "B";
        }
        else if (userIntNumber >= 70)
        {
             letter = "C";
        }
        else if (userIntNumber >= 60)
        {
             letter = "D";
        }
        else
        {
             letter = "F";
        }

        Console.WriteLine($"You have a {letter}");

        if (userIntNumber >= 70)
        {
            Console.WriteLine("Good job! You passed the class!");            
        }
        else
        {
            Console.WriteLine("You failed the class. Try harder next time.");
        }
    }
}