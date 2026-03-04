using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
                                    "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 
                                    "How many breaths would you like to take? ")
    {}
    public void Run()
    {
        Start();
        int breathTime = _durationSeconds / (_reps * 2);

        for (float i = _reps; i > 0; i--)
        {
            Console.Write("Breathe in...");
            ShowCountdown(breathTime);
            Console.Write("Now breathe out...");
            ShowCountdown(breathTime);
            Console.Write("\n");
        }
        End();
        
    }
}