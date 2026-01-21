using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumInt = randomGenerator.Next(1, 101);

        int numberInt = 9999;
        while (numberInt != magicNumInt)
        {
            Console.Write("What is your guess? ");
            string number = Console.ReadLine();
            numberInt = int.Parse(number);


            if (numberInt > magicNumInt)
            {
                Console.WriteLine("Lower");
            }
            else if (numberInt < magicNumInt)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}