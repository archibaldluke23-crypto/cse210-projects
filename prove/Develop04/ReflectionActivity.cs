using System.Diagnostics;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = ["Think of a time when you stood up for someone else.", 
                                    "Think of a time when you did something really difficult.", 
                                    "Think of a time when you helped someone in need.", 
                                    "Think of a time when you did something truly selfless."];
    private List<string> _questions = ["Why was this experience meaningful to you?",
                                        "Have you ever done anything like this before?",
                                        "How did you get started?",
                                        "How did you feel when it was complete?",
                                        "What made this time different than other times when you were not as successful?",
                                        "What is your favorite thing about this experience?",
                                        "What could you learn from this experience that applies to other situations?",
                                        "What did you learn about yourself through this experience?",
                                        "How can you keep this experience in mind in the future?"];
    private Random _rand = new Random();
    public ReflectionActivity() : base("Reflection Activity", 
                                        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 
                                        "How many questions would you like to ponder on? (Up to 9) ")
    {}
    public void Run()
    {
        Start();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();
        int ponderTime = _durationSeconds / _reps;

        for (float i = _reps; i > 0; i--)
        {
            Console.Write($"> {GetRandomQuestion()}");
            ShowSpinner(ponderTime);
        }
        End();

    }
    private string GetRandomPrompt()
    {
        int index = _rand.Next(0, _prompts.Count() - 1);
        string prompt = _prompts[index];
        return prompt;
    }
    private string GetRandomQuestion() // prevent dups
    {
        int index = _rand.Next(0, _questions.Count() - 1);
        string question = _questions[index];
        _questions.RemoveAt(index);
        return question;
    }
}