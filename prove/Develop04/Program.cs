using System;

class Program
{
    /*
    In this project I exceeded requirments by asking the user how many times they would like to repeat a 
    specific action for each activity then had the program loop that part of the activity. 
    I also made sure that duplicate questions would not be repeated within the same activity session. 
    */
    static void Main(string[] args)
    {
        Console.Clear();
        int choice = 0;
        do
        {
        ShowMenu();
        choice = int.Parse(Console.ReadLine());
        RunChoice(choice);
        } while (choice != 4);
    
        void ShowMenu()
        {
            
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
        }
        void RunChoice(int choice)
        {
          
            if (choice == 1)
            {
                BreathingActivity activity1 = new BreathingActivity();
                activity1.Run();
            }
            else if (choice == 2)
            {
                ReflectionActivity activity2 = new ReflectionActivity();
                activity2.Run();
            }
            else if (choice == 3)
            {
                ListingActivity activity3 = new ListingActivity();
                activity3.Run();
            }
            else if (choice != 4)
            {
                Console.Clear();

                Console.WriteLine("Error: Invalide choice. Try again.");
            }
        }
    }
}