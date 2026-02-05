using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //                              To exceed requirements for this assignment I added a new streak 
    //                              feature that asks the user, after they choose to save their entries for the day,
    //                              how many days they have journaled in a row. This will be tied to the last entry 
    //                              saved everyday encouraging the user to get their streak up. 
    // Set up variables
    static Journal _journal = new Journal(); 
    static PromptGenerator _prompts = new PromptGenerator();
    
    static bool started = false;
    static bool quit = false;
    static void Main(string[] args)
    {
        
        
        // Option loop
        while (quit == false)
        {
            ShowMenu();
            
            Console.Write("What would you like to do?");
            string choice = Console.ReadLine();
            int intChoice = int.Parse(choice);

            if (intChoice == 1)
            {
                WriteNewEntry();
            }
            else if (intChoice == 2)
            {
                DisplayJournal();
            }
            else if (intChoice == 3)
            {
                LoadJournal();
            }
            else if (intChoice == 4)
            {
                SaveJournal();
            }
            else if (intChoice == 5)
            {
                quit = true;
            }
            else
            {
                Console.WriteLine("Invalide response. Please type a valid number (1-5)");
            }
        }
        
    }

    static void ShowMenu()
    {
        if (started == false) // First time trigger
        {
            Console.WriteLine("Welcome to the Journal Program");
            started = true;
        }
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
    }
    static void WriteNewEntry()
    {
        // Set up a new entry
        Entry _entry = new Entry();
        // Give prompts to the PromptGenerator
        _prompts._prompts = ["What did I learn today—about myself, someone else, or the world?",
                             "What challenged me today, and how did I respond to it?",
                             "What small detail from today do I not want to forget?",
                             "How did I take care of myself today (physically, mentally, or spiritually)?",
                             "How did I take care of others today?"];
        string newPrompt = _prompts.GetRandomPrompt();
        Console.WriteLine(newPrompt);

        string today = DateTime.Today.ToString("d");

        _entry._date = today;
        _entry._prompt = newPrompt;
        _entry._response = Console.ReadLine();

        _journal.AddEntry(_entry); //Add it to the list
    }
    static void DisplayJournal()
    {
        _journal.DisplayAll();
        
    }
    static void SaveJournal()
    {
        Console.Write("What is the file name?");
        string fileName = Console.ReadLine();
        
        Console.Write("How many days in a row have you journaled for?");
        string streak = Console.ReadLine();
        

        _journal.SaveToFile(fileName, streak);
    }
    static void LoadJournal()
    {
        Console.Write("What is the file name?");
        string fileName = Console.ReadLine();

        _journal.LoadFromFile(fileName);
    }
}