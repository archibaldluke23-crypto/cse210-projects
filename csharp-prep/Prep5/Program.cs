using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();

        int userNumber = PromptUserNumber();

        int birthYear;
        PromtUserBirthYear(out birthYear);

        int squaredNum = SquareNumber(userNumber);

        DisplayResult(name, squaredNum, birthYear);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        string numberText = Console.ReadLine();
        int number = int.Parse(numberText);
        return number;
    }
    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("What is your birth year? ");
        string birthYearText = Console.ReadLine();
        birthYear = int.Parse(birthYearText);
    }
    static int SquareNumber(int x)
    {
        x = x * x;
        return x;
    }
    static void DisplayResult(string name, int squaredNum, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNum}");
        int age = 2026 - birthYear;
        Console.WriteLine($"{name}, you will turn {age} this year.");
    } 
}