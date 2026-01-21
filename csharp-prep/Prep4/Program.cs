using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int userNumInt = 1;

        while (userNumInt != 0)
        {
            Console.Write("Enter number: ");
            string userNum = Console.ReadLine();
            userNumInt = int.Parse(userNum);

            if (userNumInt != 0)
                numbers.Add(userNumInt);
        }

        int sum = 0;
        int largestNum = 0;
        foreach (int number in numbers)
        {
            sum = number + sum;

            if (number > largestNum)
            {
                largestNum = number;
            }
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        Console.WriteLine($"The largest number is: {largestNum}");

        
    }
}