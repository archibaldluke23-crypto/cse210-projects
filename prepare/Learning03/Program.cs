using System;

class Program
{
    static void Main(string[] args)
    {
        // Fraction f = new Fraction();
        // Console.WriteLine(f.GetFractionString());
        // Console.WriteLine(f.GetDecimalValue());

        // Fraction p = new Fraction(5);
        // Console.WriteLine(p.GetFractionString());
        // Console.WriteLine(p.GetDecimalValue());

        // Fraction a = new Fraction(3,4);
        // Console.WriteLine(a.GetFractionString());
        // Console.WriteLine(a.GetDecimalValue());

        // Fraction x = new Fraction(1,3);
        // Console.WriteLine(x.GetFractionString());
        // Console.WriteLine(x.GetDecimalValue());
        Random randomGenerator = new Random();
        for (int i = 1; i < 21; i++)
        {
            
            int number1 = randomGenerator.Next(1, 10);
            int number2 = randomGenerator.Next(1, 10);
            Fraction x = new Fraction(number1, number2);
            Console.WriteLine($"Fraction {i}: string: {x.GetFractionString()} Number: {x.GetDecimalValue()}");

        }
    }
}