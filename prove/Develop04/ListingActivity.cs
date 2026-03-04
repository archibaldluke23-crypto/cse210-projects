using System.Diagnostics;

public class ListingActivity : Activity
{
    private List<string> _prompts = ["Who are people that you appreciate?",
                                    "What are personal strengths of yours?",
                                    "Who are people that you have helped this week?",
                                    "When have you felt the Holy Ghost this month?",
                                    "Who are some of your personal heroes?"];

    private Random _rand = new Random(); 
    public ListingActivity() : base("Listing Activity", 
                                    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 
                                    "How many lists would you like to create? (Up to 5) ")
    {}
    public void Run()
    {
        Start();
        for (int i = _reps; i > 0; i--)
        {
            if (i < _reps)
                Console.WriteLine();
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            MakeList();
            
        }
        End();

    }
    private void MakeList()
    {
        int items = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_durationSeconds / _reps);
        DateTime currentTime = DateTime.Now;
        while (currentTime < endTime)
        {
            Console.Write(">");
            Console.ReadLine();
            items += 1;
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {items} items!");
    }
    private string GetRandomPrompt() // prevent dups
    {
        int index = _rand.Next(0, _prompts.Count() - 1);
        string prompt = _prompts[index];
        _prompts.RemoveAt(index);
        return prompt;
    }
}