public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    public Random _random = new Random();
    public string GetRandomPrompt()
    {
        int num = _random.Next(1,5);
        string prompt = _prompts[num];
        return prompt;
    }
}