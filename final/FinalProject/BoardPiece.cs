public abstract class BoardPiece
{
    protected string _name;
    protected int _number;
    protected Player _owner;
    protected bool _isDead;
    protected int _position;
    protected string _spriteTop;
    protected string _spriteBottom;
    protected int _value;
    protected bool _hasMoved;
    protected bool _inCheck;
    protected List<BoardPiece> _enemyPieces = new List<BoardPiece>();
    protected List<int> _friendPositions = new List<int>();
    protected List<BoardPiece> _obsticals = new List<BoardPiece>();
    protected List<int> _moveSet = new List<int>();
    public BoardPiece(string name, Player owner, int position, int value, string spriteTop, string SpriteBottom, int number)
    {
        _name = name;
        _owner = owner;
        _position = position;
        _value = value;
        _spriteTop = spriteTop;
        _spriteBottom = SpriteBottom;
        _hasMoved = false;
        _number = number;
        

        if (_position == -1)
        {
            _spriteTop = "   ";
            _spriteBottom = "   ";
        }
    }
    public int Die()
    {
        _isDead = true;
        _position = -1;
        return _value;

    }
    public string GetSpriteTop()
    {
        return _spriteTop;
    }
    public string GetSpriteBottom()
    {
        return _spriteBottom;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetSpecificName()
    {
        if (_name == "Pawn")
            return "p" + _number;
        if (_name == "Rook")
            return "r" + _number;
        if (_name == "Bishop")
            return "b" + _number;
        if (_name == "Knight")
            return "k" + _number;
        if (_name == "Queen")
            if (_number == 0)
                return "q";
            else
                return "q" + _number;
        return "k"; // if king
    }
    public string GetNumber()
    {
        if (_number > 0)
            return _number.ToString();
        return " ";
    }

    public Player GetOwner()
    {
        return _owner;
    }
    public virtual void ChangePosition(int position)
    {
        _position = position;
        _hasMoved = true;
        _inCheck = false;
    }
    public int GetPosition()
    {
        return _position;
    }
    protected string FindDirectionTowardsPiece(int startingPosition, int endPosition)
    {
        if (startingPosition > endPosition) // if start is below
        {
            for (int i = 1; i < 8; i++)
            {
                if (startingPosition == 8 * i + endPosition)
                    return "Up";
                if (startingPosition == 7 * i + endPosition)
                    return "UpRight";
                if (startingPosition == 9 * i + endPosition)
                    return "UpLeft";
                if (startingPosition == 1 * i + endPosition)
                    return "Left";
                
            }
        }
        else
        {
            for (int i = 1; i < 8; i++)
            {
                if (startingPosition == -8 * i + endPosition)
                    return "Down";
                if (startingPosition == -7 * i + endPosition)
                    return "DownLeft";
                if (startingPosition == -9 * i + endPosition)
                    return "DownRight";
                if (startingPosition == -1 * i + endPosition)
                    return "Right";
                
            }
        }
        return "";
    }
    protected int FindDistenceTowardsPosition(int startingPosition, int endingPosition, string direction)
    {
        int biggerNumber = 1;
        int smallerNumber = 1;
        if (startingPosition > endingPosition)
        {
            biggerNumber = startingPosition;
            smallerNumber = endingPosition;
        }
        else if (startingPosition < endingPosition)
        {
            biggerNumber = endingPosition;
            smallerNumber = startingPosition;
        }
        if (direction == "Up" || direction == "Down")
        {
            return (biggerNumber - smallerNumber) / 8;
        }
        if (direction == "Left" || direction == "Right")
        {
            return biggerNumber - smallerNumber;
        }
        if (direction == "UpRight" || direction == "DownLeft")
        {
            return (biggerNumber - smallerNumber) / 7;
        }
        if (direction == "UpLeft" || direction == "DownRight")
        {
            return (biggerNumber - smallerNumber) / 9;
        }
        return 0;
    }
    protected virtual void AddToMoveSet(int move)
    {
        BoardPiece king = _owner.FindPieceInList("k");
        if (_inCheck)
        {
            if (king.IsInCheck(_obsticals, move) == false)
            {
                _inCheck = true;
                bool checksKing = king.WouldBeInCheck(_position, move, _enemyPieces, _friendPositions);
                if (checksKing == false)
                    _moveSet.Add(move);
            }
        }
        else
        {
            bool checksKing = king.WouldBeInCheck(_position, move, _enemyPieces, _friendPositions);
            if (checksKing == false)
                _moveSet.Add(move);
        }
    }
    public virtual int Castle(int otherPiecePosition, Board board, bool askPlayer = false)
    {
        return _position;
    }
    public void PutInCheck()
    {
        _inCheck  = true;
    }
    protected int SetDiagonalNumbers(int numberToRightOrLeft, int numberToTopOrBottom)
    {
        if (numberToRightOrLeft <= numberToTopOrBottom)
        {
            return numberToRightOrLeft;
        }
        else
        {
            return numberToTopOrBottom;
        }
    }
    public virtual bool IsInCheck(List<BoardPiece> pieces, int potentialMove)
    {
        return false;
    }
    public virtual bool WouldBeInCheck(int friendCurrentPosition, int potentialPosition, List<BoardPiece> enemyPieces, List<int> friendPositions)
    {
        return false;
    }
    public virtual bool IsSquareChecked(List<BoardPiece> enemyPieces, int moveSpace, List<int> moveSet)
    {
        return false;
    }
    public abstract List<int> ViewMoveOptions(List<BoardPiece> obsticals, bool inCheck = false);
}