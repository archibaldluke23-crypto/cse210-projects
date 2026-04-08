public class Pawn : BoardPiece
{
    private bool _isAtEnd;
    public Pawn(Player owner, int position, string bottomSprite, int number) : base("Pawn", owner, position, 1, "(O)", bottomSprite, number)
    {
        _isAtEnd = false;
    }
    public bool ViewIsAtEnd()
    {
        return _isAtEnd;
    }
    public override void ChangePosition(int position)
    {
        _position = position;
        _hasMoved = true;
        if (_owner.GetColor() == "White")
        {
            if (_position <= 8)
                _isAtEnd = true;
        }
        else
        {
            if (_position >= 57)
                _isAtEnd = true;
        }
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals, bool inCheck = false)
    {
        _inCheck = inCheck;
        _moveSet.Clear();
        _enemyPieces.Clear();
        _obsticals = obsticals;
        _friendPositions.Clear();
        List<int> enemyPositions = new List<int>();
        foreach (BoardPiece obstical in obsticals)
        {
            if (obstical.GetPosition() != -1)
            {
                if (obstical.GetOwner().GetColor() == _owner.GetColor())
                {
                    _friendPositions.Add(obstical.GetPosition());
                }
                else
                {
                    _enemyPieces.Add(obstical);
                    enemyPositions.Add(obstical.GetPosition());
                }
            }
        }
        int moveSpace;
        if (_owner.GetColor() == "White")
        {
            moveSpace = _position - 8;
            if (enemyPositions.Contains(moveSpace) == false && _friendPositions.Contains(moveSpace) == false)
            {
                AddToMoveSet(moveSpace);
                if (_hasMoved == false)
                {
                    if (enemyPositions.Contains(moveSpace - 8) == false && _friendPositions.Contains(moveSpace - 8) == false)
                    {
                    AddToMoveSet(moveSpace - 8);
                    }
                }
            }
            if (enemyPositions.Contains(moveSpace + 1))
            {
                AddToMoveSet(moveSpace + 1);
            }
            if (enemyPositions.Contains(moveSpace - 1))
            {
                AddToMoveSet(moveSpace - 1);
            }
        }
        else
        {
            moveSpace = _position + 8;
            if (enemyPositions.Contains(moveSpace) == false && _friendPositions.Contains(moveSpace) == false)
            {
                AddToMoveSet(moveSpace);
                if (_hasMoved == false)
                {
                    if (enemyPositions.Contains(moveSpace + 8) == false && _friendPositions.Contains(moveSpace + 8) == false)
                    {
                        AddToMoveSet(moveSpace + 8);
                    }
                }
            }
            if (enemyPositions.Contains(moveSpace + 1))
            {
                AddToMoveSet(moveSpace + 1);
            }
            if (enemyPositions.Contains(moveSpace - 1))
            {
                AddToMoveSet(moveSpace - 1);
            }
        }
        return _moveSet;
    }
    protected override void AddToMoveSet(int move)
    {
        BoardPiece king = _owner.FindPieceInList("k");
        if (_inCheck)
        {
            if (king.IsInCheck(_obsticals, move) == false)
            {
                _inCheck = true;
                bool checksKing = king.WouldBeInCheck(_position, move, _enemyPieces, _friendPositions);
                if (checksKing == false)
                {
                    if(move > 0 && move < 65)
                        _moveSet.Add(move);
                }
            }
        }
        else
        {
            bool checksKing = king.WouldBeInCheck(_position, move, _enemyPieces, _friendPositions);
            if (checksKing == false)
                {
                    if(move > 0 && move < 65)
                        _moveSet.Add(move);
                }
        }
    }
}