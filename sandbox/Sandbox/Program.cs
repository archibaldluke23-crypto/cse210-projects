using System;

namespace Sandbox
{
    public class Program
    {
        public static void Main()
        {
            // This is a one line comment 

            /*
            This is a 
            multi-line comment
            */
            // to quickly comment out multiple lines of code, highlight it and press Ctrl /
            Console.WriteLine("Hello World!");

            /* 
            WriteLine will take up the entire line in the terminal.
            But just Write will take up a portion of the line
            */
            Console.Write("Hello "); Console.WriteLine("World!!!");
            

            // This will get input from the user
            Console.Write("What is your favorite color? ");
            string color = Console.ReadLine();

            int x = 5;
            Console.WriteLine("Value of x is " + x);

            int y = 5;
            if (x > y) // Put the condision in parentheses without a colon
            {
                Console.WriteLine("greater");
            }
            else if (x == y)
            {
                Console.WriteLine("even");
            }

            string school = "BYU-Idaho";
            Console.WriteLine($"I am studying at {school}."); // Use $ as you would use f in python

            string valueInText = "42";
            int number = int.Parse(valueInText); // This converts a string into a int

            int number2 = 42;
            string textVersion = number2.ToString(); // This converts int's into strings
            
            for (int i = 10; i > 0; i-- )
            {
                Console.WriteLine(i);
            }

            // will give you a random number between 1 and 10
            Random randomGenerator = new Random();
            number = randomGenerator.Next(1, 11);
            Console.WriteLine(number);
        }
    }
}

