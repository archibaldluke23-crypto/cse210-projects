public class Player
{
    private string _color;
    private List<BoardPiece> _pieces = new List<BoardPiece>();
    private BoardPiece _selectedPiece;
    private int _score;
    private bool _isInCheck;
    private BoardPiece _enemyKilled;
    private Board _board;
    private List<int> _startPositions;
    private List<int> _currentPieceMoveOptions;
    private Player _playerInstenceToPass;
    public Player(string color, Board board, Player player)
    {
        _playerInstenceToPass = player;
        _color = color;
        _board = board;
        if (_color == "White")
        {
            List<int> _startPositions = [64,63,62,61,60,59,58,57,56,55,54,53,52,51,50,49];
        }
        else
        {
            List<int> startPositions = [1,2,3,5,4,6,7,8,9,10,11,12,13,14,15,16];
        }
        Pawn pawn1 = new Pawn(player, _startPositions[15]);
        _pieces.Add(pawn1);
        Pawn pawn2 = new Pawn(player, _startPositions[14]);
        _pieces.Add(pawn2);
        Pawn pawn3 = new Pawn(player, _startPositions[13]);
        _pieces.Add(pawn3);
        Pawn pawn4 = new Pawn(player, _startPositions[12]);
        _pieces.Add(pawn4);
        Pawn pawn5 = new Pawn(player, _startPositions[11]);
        _pieces.Add(pawn5);
        Pawn pawn6 = new Pawn(player, _startPositions[10]);
        _pieces.Add(pawn6);
        Pawn pawn7 = new Pawn(player, _startPositions[9]);
        _pieces.Add(pawn7);
        Pawn pawn8 = new Pawn(player, _startPositions[8]);
        _pieces.Add(pawn8);
        Rook rook1 = new Rook(player, _startPositions[7]);
        _pieces.Add(rook1);
        Knight knight1 = new Knight(player, _startPositions[6]);
        _pieces.Add(knight1);
        Bishop bishop1 = new Bishop(player, _startPositions[5]);
        _pieces.Add(bishop1);
        Queen queen = new Queen(player, _startPositions[4]);
        _pieces.Add(queen);
        King king = new King(player, _startPositions[3]);
        _pieces.Add(king);
        Bishop bishop2 = new Bishop(player, _startPositions[2]);
        _pieces.Add(bishop2);
        Knight knight2 = new Knight(player, _startPositions[1]);
        _pieces.Add(knight2);
        Rook rook2 = new Rook(player, _startPositions[0]);
        _pieces.Add(rook2);
        _score = 39;
    }
    public string GetColor()
    {
        return _color;
    }
    public List<BoardPiece> GetBoardPieces()
    {
        return _pieces;
    }
    public void SelectPiece()
    {
        Console.Write("What piece would you like to move? ");
        string pieceToMove = Console.ReadLine();
        _selectedPiece = FindPieceInList(pieceToMove);
        List<int> _currentPieceMoveOptions = _selectedPiece.ViewMoveOptions(_board.GetPositions());
        _board.ShowBoard(_currentPieceMoveOptions);
    }
    public bool MovePiece()
    {
        Castle();
        Console.Write("Where would you like to move to? ");
        int placeToMove = int.Parse(Console.ReadLine());
        if (_board.OccupiedBy(placeToMove).GetOwner().GetColor() == _color)
        {
            Console.WriteLine("Square Occupide by your own piece: Try again.");
        }
        else
        {
            _enemyKilled = _board.MovePiece(_selectedPiece, placeToMove);
            _selectedPiece.ChangePosition(placeToMove);
            foreach (int moveOption in _currentPieceMoveOptions)
            {
                BoardPiece piece = _board.OccupiedBy(moveOption);
                if (piece.GetName() == "King" && piece.GetOwner().GetColor() != _color)
                {
                    piece.Check(_selectedPiece, _board.CheckPosition(_selectedPiece));
                    return true;
                }
            }
        }
        return false;
    }
    public BoardPiece GetEnemyKilled()
    {
        return _enemyKilled;
    }
    public void RemoveKilledPiece(BoardPiece piece)
    {
        _board.MovePiece(piece, 65);
        _score -= piece.Die();
    }
    public void Transform()
    {
        List<int> endOfBoard;
        if (_color == "White")
        {
            endOfBoard = [1,2,3,4,5,6,7,8];
        }
        else
        {
            endOfBoard = [57,58,59,60,61,62,63,64];
        }
        if (_selectedPiece.GetName() == "Pawn")
        {
            int position = _board.CheckPosition(_selectedPiece);
            foreach (int number in endOfBoard)
            {
                if (position == number)
                {
                    Console.Write("What would you like to turn your pawn into? ");
                    string pieceName = Console.ReadLine();
                    _score -= _selectedPiece.Die();
                    if (pieceName == "Rook")
                    {
                        Rook rook3 = new Rook(_playerInstenceToPass, position);
                        _pieces.Add(rook3);
                        _score += 5;
                    }
                    else if (pieceName == "Bishop")
                    {
                        Bishop bishop3 = new Bishop(_playerInstenceToPass, position);
                        _pieces.Add(bishop3);
                        _score += 3;
                    }
                    else if (pieceName == "Knight")
                    {
                        Knight knight3 = new Knight(_playerInstenceToPass, position);
                        _pieces.Add(knight3);
                        _score += 3;
                    }
                    else if (pieceName == "Queen")
                    {
                        Queen queen2 = new Queen(_playerInstenceToPass, position);
                        _pieces.Add(queen2);
                        _score += 9;
                    }
                }
            }
        }
    }
    public void Castle()
    {
        string partnerName;
        if (_selectedPiece.GetName() == "Rook")
        {
            partnerName = "King";
        }
        else
        {
            partnerName = "Rook";
        }
        BoardPiece partnerPiece = FindPieceInList(partnerName);
        int selectedPosition = _board.CheckPosition(_selectedPiece);
        int partnerPosition = _board.CheckPosition(partnerPiece);
        bool countUpSquares = false;
        bool clearPath = true;
        if (selectedPosition < partnerPosition)
        {
            countUpSquares = true;
        }
        for (int i = selectedPosition + 1; i < partnerPosition || i > partnerPosition;)
        {
            bool spaceTaken = _board.Occupied(i);
            if (spaceTaken == true)
            {
                clearPath = false;
            }
            if (countUpSquares)
            {
                i++;
            }
            else
            {
                i--;
            }
        }
        int selectedMovedTo = _selectedPiece.Castle(clearPath, partnerPosition, true);
        int partnerMovedTo = partnerPiece.Castle(clearPath, selectedPosition);
        _board.MovePiece(_selectedPiece, selectedMovedTo);
        _board.MovePiece(partnerPiece, partnerMovedTo);
    }
    public int ShowScore()
    {
        return _score;
    }
    public bool InCheckMode()
    {
        Console.WriteLine($"{_color} is in check!");
        _isInCheck = true;
        SelectPiece();
        bool _nextPlayerInCheck = MovePiece();
        return _nextPlayerInCheck;
    }
    public BoardPiece FindPieceInList(string pieceName)
    {
        foreach (BoardPiece piece in _pieces)
        {
            if (piece.GetName() == pieceName)
            {
                return piece;
            }
        }
        return null;
    }
}