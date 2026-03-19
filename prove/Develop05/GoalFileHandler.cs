using System.IO; 
public class GoalFileHandler
{
    public void Save(string filename, int level, int score, List<Goal> goals)
    {
        File.WriteAllText(filename, $"{level},{score}\n");
        foreach (Goal goal in goals)
        {
            GoalData goalData = goal.ToGoalData();
            File.AppendAllText(filename, goalData.ToString());
        }
    }
    public SaveData Load(string filename)
    {
        SaveData saveData = new SaveData();
        bool firstTime = true;
        try
        {
            foreach (string line in File.ReadLines(filename))
            {
                if (firstTime)
                {
                    string[] parts = line.Split(",");
                    saveData.level = int.Parse(parts[0]);
                    saveData.score = int.Parse(parts[1]);
                    firstTime = false;
                }
                else
                {
                    GoalData goalData = new GoalData();
                    goalData.LineToGoalData(line);
                    saveData.goals.Add(goalData);
                }
            }
            return saveData;
        }
        catch(Exception)
        {
            Console.Write("Error: File not found. Please enter a different filename: ");
            return Load(Console.ReadLine());

        }
    }
    public Goal CreateGoalFromData(GoalData data)
    {
        if(data._type == "SimpleGoal")
        {
            SimpleGoal simpleGoal = new SimpleGoal(data._name, data._description, data._points, data._isComplete);
            return simpleGoal;
        }
        else if (data._type == "EternalGoal")
        {
            EternalGoal eternalGoal = new EternalGoal(data._name, data._description, data._points);
            return eternalGoal;
        }
        else
        {
            ChecklistGoal checklistGoal = new ChecklistGoal(data._name, data._description, data._points, data._targetAmount, data._bonus, data._amountCompleted);
            return checklistGoal;
        }
    }
}