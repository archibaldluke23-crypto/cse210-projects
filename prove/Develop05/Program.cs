using System;
//              In this project I exceeded requirments by adding a leveling up system 
//              which gives you bonus points once you make it to the next level.
//              I also added a delete option so you can easily delete goals.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        Console.WriteLine("Welcome to Eternal Quest!");
        Console.Write("What is the filename you will be using? ");
        string filename = Console.ReadLine();
        string choice = "";
        while (choice != "7")
        {
            ShowMenu();
            choice = ChoiceSelection();
        }
        void ShowMenu()
        {
            manager.DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Delete Goal");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu:");
        }
        void CreateGoalMenu(GoalManager manager)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
        }
        void RecordEventMenu(GoalManager manager)
        {
            Console.WriteLine("The goals are:");
            List<Goal> goals = manager.GetGoals();
            manager.ListGoalDetails(true);
            int accomplished = IntInputFailsafe("Which goal did you accomplish? ", true);
            if (goals.Count < accomplished || 1 > accomplished)
            {
                Console.WriteLine("Number out of range. Please try again");
                RecordEventMenu(manager);
            }
            else
                manager.RecordEvent(accomplished - 1);
        }
        void DeleteMenu()
        {
            Console.WriteLine("The goals are:");
            manager.ListGoalDetails((true));
            int delete = IntInputFailsafe("Which goal would you like to delete? ", true);
            List<Goal> goals = manager.GetGoals();
            if (goals.Count < delete || 1 > delete)
            {
                Console.WriteLine("Number out of range. Please try again");
                DeleteMenu();
            }
            else
                manager.DeleteGoal(delete - 1);
        }
        void CreateGoal(string type)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            int points = IntInputFailsafe("What is the amount of points associated with this goal? ");
            
            if (type == "SimpleGoal")
            {
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points, false);
                manager.AddGoal(simpleGoal);
            }
            else if (type == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(name, description, points); 
                manager.AddGoal(eternalGoal);
            }
            else
            {
                int targetAmount = IntInputFailsafe("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = IntInputFailsafe("What is the bonus for accomplishing it that many times? ");

                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, targetAmount, bonus, 0); 
                manager.AddGoal(checklistGoal); 
            }
        }
        string ChoiceSelection()
        {
            choice = Console.ReadLine();
            if (choice == "1")
            {
                GoalChoiceSelection();
            }
            else if (choice == "2")
            {
                manager.ListGoalDetails();
            }
            else if (choice == "3")
            {
                manager.SaveGoals(filename);
            }
            else if (choice == "4")
            {
                manager.LoadGoals(filename);
            }
            else if (choice == "5")
            {
                RecordEventMenu(manager);
            }
            else if (choice == "6")
            {
                DeleteMenu();
            }
            else if (choice != "7")
            {
                Console.WriteLine("Invalid response: Please try again");
            }
            return choice;
        }
        void GoalChoiceSelection()
        {
            string goalChoice = "";
            do 
            {
                CreateGoalMenu(manager);
                goalChoice = Console.ReadLine();
                if (goalChoice == "1")
                {
                    CreateGoal("SimpleGoal");
                }
                else if (goalChoice == "2")
                {
                    CreateGoal("EternalGoal");      
                }
                else if (goalChoice == "3")
                {
                    CreateGoal("ChecklistGoal");
                }
                else
                {
                    Console.WriteLine("Invalid Response: Please try again.");
                    goalChoice = "4";
                }
            } while (goalChoice == "4");
        }
        int IntInputFailsafe(string question, bool reprint = false)
        {
            int answer = -1;
            do
            {
                try
                {
                    Console.Write(question);
                    answer = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid response. Please try again.");
                    if (reprint)
                    {
                        Console.WriteLine("The goals are:");
                        manager.ListGoalDetails(true);
                        return IntInputFailsafe(question, true);
                    }
                }
            } while(answer == -1);
            return answer;
        }
    }
}