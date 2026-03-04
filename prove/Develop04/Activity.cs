public class Activity
{
    protected string _name;
    protected string _description;
    protected string _repDescription;
    protected int _durationSeconds;
    protected int _reps;
    protected Activity(string name, string description, string repDescription)
    {
        _name = name;
        _description = description;
        _repDescription = repDescription;
    }
    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        GetDuration();
        Console.Write(_repDescription);
        GetReps();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

    }
    public void End()
    {
        Console.WriteLine("\nWell done!!!");
        ShowSpinner(5);
        Console.WriteLine($"You have completed another {_durationSeconds} seconds of the {_name}");
        ShowSpinner(5);
        Console.Clear();

    }
    protected void GetDuration()
    {
        _durationSeconds = int.Parse(Console.ReadLine());
    }
    protected void GetReps()
    {
        _reps = int.Parse(Console.ReadLine());
    }
    protected void ShowSpinner(int seconds)
    {
        // | / - \
        List<string> symbols = ["|", "/", "-", "\\"];
        double currentTime = 0;
        int currentSymbol = 1;
        Console.Write(symbols[currentSymbol]);
        while (currentTime < seconds) 
        {
            
            Thread.Sleep(100);
            Console.Write("\b \b");
            Console.Write(symbols[currentSymbol]);
            currentTime += 0.1;
            if (currentSymbol != 3)
                currentSymbol += 1;
            else
                currentSymbol = 0;
        }
        Console.Write("\b \b \n");
    }
    protected void ShowCountdown(int seconds)
    {
        Console.Write(seconds);
        for (int i = seconds - 1; i >= 0; i--)
        {
            
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write(i);
        }
        Console.Write("\b \b \n");

    }
}