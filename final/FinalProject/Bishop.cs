public class Bishop : BoardPiece
{
    public Bishop(Player owner, int position, string bottomSprite, int number) : base("Bishop", owner, position, 3, "(/)", bottomSprite, number)
    {
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals, bool inCheck = false)
    {
        _inCheck = inCheck;
        _moveSet.Clear();
        _obsticals = obsticals;
        _enemyPieces.Clear();
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
        for (int x = 8; x <= 64;x += 8)
        {
            if (_position <= x && _position > x - 8) 
            {
                int numberToRightEnd = x - _position;
                int numberToLeftEnd = _position - (x - 7);
                int numberToTopEnd = (x - 8) / 8;
                int numberToBottomEnd = (64 - x) / 8;

                int diagonalNumberToTopRight = SetDiagonalNumbers(numberToRightEnd, numberToTopEnd);
                int diagonalNumberToTopLeft = SetDiagonalNumbers(numberToLeftEnd, numberToTopEnd);
                int diagonalNumberToBottomRight = SetDiagonalNumbers(numberToRightEnd, numberToBottomEnd);
                int diagonalNumberToBottomLeft = SetDiagonalNumbers(numberToLeftEnd, numberToBottomEnd);
                
                LimitMoveSet(diagonalNumberToTopRight, _moveSet, enemyPositions, _friendPositions, false, 7);
                LimitMoveSet(diagonalNumberToTopLeft, _moveSet, enemyPositions, _friendPositions, false, 9);
                LimitMoveSet(diagonalNumberToBottomRight, _moveSet, enemyPositions, _friendPositions, true, 9);
                LimitMoveSet(diagonalNumberToBottomLeft, _moveSet, enemyPositions, _friendPositions, true, 7);
                
            }
        }
        return _moveSet;
    }
    private void LimitMoveSet(int numberToEnd, List<int> moveSet, List<int> enemyPositions, List<int> friendPositions, bool addSign, int middleNumber)
    {
        BoardPiece king = _owner.FindPieceInList("k");
        for (int j = 1; j <= numberToEnd; j++)
        {
            int moveSpace;
            if (addSign)
                moveSpace = _position + (middleNumber * j);
            else
                moveSpace = _position - (middleNumber * j);
            if (enemyPositions.Contains(moveSpace))
            {
                AddToMoveSet(moveSpace);
                j += numberToEnd + 1;
            }
            else if (friendPositions.Contains(moveSpace))
            {
                j += numberToEnd + 1;
            }
            else
            {
                AddToMoveSet(moveSpace);
            }
        }
    }
}