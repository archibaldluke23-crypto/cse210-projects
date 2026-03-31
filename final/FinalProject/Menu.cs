public class Menu
{
private TurnManager _turnManager = new TurnManager();
private bool _endGame = false;
    public void Run()
    {
        Console.WriteLine("Welcome to chess!");
        Console.WriteLine("Player 1 is white and Player 2 is black");
        while (_endGame == false)
        {
            _endGame = _turnManager.TakeTurn();
        }
        Console.WriteLine("Game Over. Thanks for playing");
    }
}