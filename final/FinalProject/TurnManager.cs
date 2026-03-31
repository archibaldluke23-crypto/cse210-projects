public class TurnManager
{
    private Player _player1;
    private Player _player2;
    private List<BoardPiece> _allPieces;
    private string _currentTurn;
    private bool _nextPlayerInCheck;
    private BoardPiece _lastKilledPiece;
    private Board _board;
    private bool endGame;
    public TurnManager()
    {
        _currentTurn = "White";
       List<BoardPiece> player1Pieces =  _player1.GetBoardPieces();
       List<BoardPiece> player2Pieces =  _player2.GetBoardPieces();
       foreach (BoardPiece boardPiece in player1Pieces)
       {
            _allPieces.Add(boardPiece);
       }
       foreach (BoardPiece boardPiece in player2Pieces)
       {
            _allPieces.Add(boardPiece);
       }

        _board = new Board(_allPieces);
        _player1 = new Player("White", _board, _player1);
        _player2 = new Player("Black", _board, _player2);
    }
    public bool TakeTurn()
    {
        if (_currentTurn == "White")
        {
            Console.WriteLine($"Score: White {_player1.ShowScore()}, Black {_player2.ShowScore()}");
            Console.WriteLine("Whites turn:");
            _board.ShowBoard();
            if (_nextPlayerInCheck)
            {
                endGame = _player1.InCheckMode();
            }
            _player1.SelectPiece();
            _nextPlayerInCheck = _player1.MovePiece();
            _lastKilledPiece = _player1.GetEnemyKilled();
            _player2.RemoveKilledPiece(_lastKilledPiece);

            _currentTurn = "Black";

        }
        else
        {
            Console.WriteLine($"Score: White {_player1.ShowScore()}, Black {_player2.ShowScore()}");
            Console.WriteLine("Blacks turn:");
            _board.ShowBoard();
            if (_nextPlayerInCheck)
            {
                endGame = _player2.InCheckMode();
            }
            _player2.SelectPiece();
            _nextPlayerInCheck = _player2.MovePiece();
            _lastKilledPiece = _player2.GetEnemyKilled();
            _player1.RemoveKilledPiece(_lastKilledPiece);

            _currentTurn = "White";

        }
        return endGame;
    }
}