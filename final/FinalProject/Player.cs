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
    public Player(string color, Board board)
    {
        _color = color;
        _board = board;
        if (_color == "White")
        {
            _startPositions = [64,63,62,61,60,59,58,57,56,55,54,53,52,51,50,49];
        }
        else
        {
            _startPositions = [1,2,3,5,4,6,7,8,9,10,11,12,13,14,15,16];
        }
       
        _score = 39;
    }
    public void SetUpPieces(Player player)
    {
        string spriteLetter;
        if (_color == "White")
            spriteLetter = "W";
        else 
            spriteLetter = "B";

        _playerInstenceToPass = player;
         Pawn pawn1 = new Pawn(player, _startPositions[15], $"/{spriteLetter}\\", 1);
        _pieces.Add(pawn1);
        Pawn pawn2 = new Pawn(player, _startPositions[14], $"/{spriteLetter}\\", 2);
        _pieces.Add(pawn2);
        Pawn pawn3 = new Pawn(player, _startPositions[13], $"/{spriteLetter}\\", 3);
        _pieces.Add(pawn3);
        Pawn pawn4 = new Pawn(player, _startPositions[12], $"/{spriteLetter}\\", 4);
        _pieces.Add(pawn4);
        Pawn pawn5 = new Pawn(player, _startPositions[11], $"/{spriteLetter}\\", 5);
        _pieces.Add(pawn5);
        Pawn pawn6 = new Pawn(player, _startPositions[10], $"/{spriteLetter}\\", 6);
        _pieces.Add(pawn6);
        Pawn pawn7 = new Pawn(player, _startPositions[9], $"/{spriteLetter}\\", 7);
        _pieces.Add(pawn7);
        Pawn pawn8 = new Pawn(player, _startPositions[8], $"/{spriteLetter}\\", 8);
        _pieces.Add(pawn8);
        Rook rook1 = new Rook(player, _startPositions[7], $"|{spriteLetter}|", 1);
        _pieces.Add(rook1);
        Knight knight1 = new Knight(player, _startPositions[6], $"/{spriteLetter})", 1);
        _pieces.Add(knight1);
        Bishop bishop1 = new Bishop(player, _startPositions[5], $"/{spriteLetter}\\", 1);
        _pieces.Add(bishop1);
        Queen queen = new Queen(player, _startPositions[4], $"|{spriteLetter}|", 0);
        _pieces.Add(queen);
        King king = new King(player, _startPositions[3], $"|{spriteLetter}|", 0);
        _pieces.Add(king);
        Bishop bishop2 = new Bishop(player, _startPositions[2], $"/{spriteLetter}\\", 2);
        _pieces.Add(bishop2);
        Knight knight2 = new Knight(player, _startPositions[1], $"/{spriteLetter})", 2);
        _pieces.Add(knight2);
        Rook rook2 = new Rook(player, _startPositions[0], $"|{spriteLetter}|", 2);
        _pieces.Add(rook2);
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

        if (_selectedPiece == null)
        {
            _board.ShowBoard();
            Console.WriteLine("Invalid Piece. Please try again ");
            SelectPiece();
        }
        else
        {
            _currentPieceMoveOptions = _selectedPiece.ViewMoveOptions(_board.GetPieces(), _isInCheck);
            if (_currentPieceMoveOptions.Count() == 0)
            {
                _board.ShowBoard();
                Console.WriteLine("You can't move this piece anywhere");
                SelectPiece();
            }
            else
                _board.ShowBoard(_currentPieceMoveOptions);
        }
    }
    public bool MovePiece()
    {
        _board.ShowBoard(_currentPieceMoveOptions);
        bool castled = false;
        if (_selectedPiece.GetName() == "Rook" || _selectedPiece.GetName() == "King")
            castled = Castle();
        if (castled == false)
        {
            Console.Write("Where would you like to move to? (type 'back' to select different piece)");
            int pastPosition = _selectedPiece.GetPosition();
            string input = Console.ReadLine().ToLower();
            if (input == "back")
            {
                _board.ShowBoard();
                SelectPiece();
                return MovePiece();
            }
            int placeToMove = 0;
            try
            {
                placeToMove = int.Parse(input);
            }
            catch
            {
                Console.WriteLine("Invalid Response. Please try again ");
                return MovePiece();
            }
            if (_currentPieceMoveOptions.Contains(placeToMove) == false)
            {
                Console.WriteLine("Can't move to there. Enter a valid space.");
                return MovePiece();
            }
            _enemyKilled = _board.MovePiece(_selectedPiece, placeToMove);
            _selectedPiece.ChangePosition(placeToMove);
            Transform();
            _isInCheck = false;
            List<int> newMoves = _selectedPiece.ViewMoveOptions(_board.GetPieces());
            foreach (int newMove in newMoves)
            {
                if (_board.OccupiedBy(newMove).GetName() == "King")
                {
                    _board.OccupiedBy(newMove).PutInCheck();
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
        if (piece != null)
        {
            if (piece.GetPosition() != -1)
                _score -= piece.Die();
        }
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
            int position = _selectedPiece.GetPosition();
            foreach (int number in endOfBoard)
            {
                if (position == number)
                {
                    string spriteLetter = "";
                    if (_color == "White")
                        spriteLetter = "W";
                    else
                        spriteLetter = "B";
                    Console.Write("What would you like to turn your pawn into?(r/b/k/q) ");
                    string pieceName = Console.ReadLine();
                    _score -= _selectedPiece.Die();
                    if (pieceName == "r")
                    {
                        Rook rook3 = new Rook(_playerInstenceToPass, position, $"|{spriteLetter}|", 3);
                        _pieces.Add(rook3);
                        _score += 5;
                        _board.SetBoardPieces([rook3]);
                        _selectedPiece = rook3;
                    }
                    else if (pieceName == "b")
                    {
                        Bishop bishop3 = new Bishop(_playerInstenceToPass, position, $"/{spriteLetter}\\", 3);
                        _pieces.Add(bishop3);
                        _score += 3;
                        _board.SetBoardPieces([bishop3]);
                        _selectedPiece = bishop3;
                    }
                    else if (pieceName == "k")
                    {
                        Knight knight3 = new Knight(_playerInstenceToPass, position, $"/{spriteLetter})", 3);
                        _pieces.Add(knight3);
                        _score += 3;
                        _board.SetBoardPieces([knight3]);
                        _selectedPiece = knight3;
                    }
                    else if (pieceName == "q")
                    {
                        Queen queen2 = new Queen(_playerInstenceToPass, position, $"|{spriteLetter}|", 2);
                        _pieces.Add(queen2);
                        _score += 9;
                        _board.SetBoardPieces([queen2]);
                        _selectedPiece = queen2;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Response. Please try again. ");
                        Transform();
                    }
                }
            }
        }
    }
    public bool Castle() // error pieces disappear when selecting a rook or king
    {
        bool castled = false;
        bool tryAgain = false;
        string partnerName = "";
        bool rookOrKing = false;
        if (_selectedPiece.GetName() == "Rook")
        {
            partnerName = "k";
            rookOrKing = true;
        }
        else if (_selectedPiece.GetName() == "King")
        {
            partnerName = "r1";
            rookOrKing = true;
        }
        if (rookOrKing)
        {
            do
            {
                
                BoardPiece partnerPiece = FindPieceInList(partnerName);
                int selectedPosition = _selectedPiece.GetPosition();
                int partnerPosition = partnerPiece.GetPosition(); // error when selecting the king
                bool countUpSquares = false;
                bool clearPath = true;
                int UpOrDownASquare = -1;
                if (selectedPosition < partnerPosition)
                {
                    UpOrDownASquare = 1;
                    countUpSquares = true;
                }
                for (int i = selectedPosition + UpOrDownASquare; i < partnerPosition || i > partnerPosition;)
                {
                    bool spaceTaken = _board.Occupied(i);
                    if (spaceTaken == true)
                    {
                        clearPath = false;
                        i = partnerPosition;
                    }
                    else if (countUpSquares)
                    {
                        i++;
                    }
                    else
                    {
                        i--;
                    }
                }
                if (tryAgain == false && clearPath == false)
                {
                    tryAgain = true;
                    partnerName = "r2";
                }
                else if (tryAgain == true && clearPath == false)
                {
                    tryAgain = false;
                }
                if (clearPath)
                {
                    List<BoardPiece> enemies = new List<BoardPiece>();
                    foreach (BoardPiece boardPiece in _pieces)
                    {
                        if (boardPiece.GetPosition() != -1)
                            {
                                if (boardPiece.GetOwner().GetColor() != _color)
                                    enemies.Add(boardPiece);
                            }
                    }
                    int selectedMovedTo = _selectedPiece.Castle(partnerPosition, _board, true);
                    int partnerMovedTo = partnerPiece.Castle(selectedPosition, _board);
                    if (FindPieceInList("k").IsSquareChecked(enemies, selectedMovedTo, []) == false)
                    {
                        _board.MovePiece(_selectedPiece, selectedMovedTo);
                        _board.MovePiece(partnerPiece, partnerMovedTo);
                        _selectedPiece.ChangePosition(selectedMovedTo);
                        partnerPiece.ChangePosition(partnerMovedTo);
                        castled = true;
                        _selectedPiece = partnerPiece;
                        _currentPieceMoveOptions = _selectedPiece.ViewMoveOptions(_board.GetPieces(), _isInCheck);
                    }
                    else
                    {
                        Console.WriteLine("Cant castle into a checked square.");
                    }
                }
            } while (tryAgain == true);
        }
        return castled;
    }
    public int ShowScore()
    {
        return _score;
    }
    public bool InCheckMode()
    {
        Console.WriteLine($"{_color} is in check!");
        _isInCheck = true;
        bool aMoveExists = false;
        foreach (BoardPiece piece in _pieces)
        {
            List<int> moves = piece.ViewMoveOptions(_board.GetPieces(), true);
            if (moves.Count() > 0)
                aMoveExists = true;
        }
        if (aMoveExists)
            return false;
    return true;
    }
    public BoardPiece FindPieceInList(string pieceName, bool general = false)
    {
        foreach (BoardPiece piece in _pieces) 
        {
            if (general)
            {
                    if (piece.GetName() == pieceName)
                {
                    return piece;
                }
            }
            if (piece.GetSpecificName() == pieceName)
            {
                return piece;
            }
        }
        return null;
    }
}