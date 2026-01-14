using System;
// This is a one line comment 

/*
This is a 
multi-line comment
*/
namespace Sandbox
{
    public class Program
    {
        public static void Main()
        {
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

            int y = 3;
            if (x > y) // Put the condision in parentheses without a colon
            {
                Console.WriteLine("greater");
            }

            string school = "BYU-Idaho";
            Console.WriteLine($"I am studying at {school}."); // Use $ as you would use f in python
        }
    }
}

