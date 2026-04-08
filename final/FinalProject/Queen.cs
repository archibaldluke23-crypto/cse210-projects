using System.Diagnostics;

public class Queen : BoardPiece
{
    public Queen(Player owner, int position, string bottomSprite, int number) : base("Queen", owner, position, 9, "WWW", bottomSprite, number)
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

                LimitMoveSet(numberToRightEnd, enemyPositions, true, 1);
                LimitMoveSet(numberToLeftEnd, enemyPositions, false, 1);
                LimitMoveSet(numberToTopEnd, enemyPositions, false, 8);
                LimitMoveSet(numberToBottomEnd, enemyPositions, true, 8);

                int diagonalNumberToTopRight = SetDiagonalNumbers(numberToRightEnd, numberToTopEnd);
                int diagonalNumberToTopLeft = SetDiagonalNumbers(numberToLeftEnd, numberToTopEnd);
                int diagonalNumberToBottomRight = SetDiagonalNumbers(numberToRightEnd, numberToBottomEnd);
                int diagonalNumberToBottomLeft = SetDiagonalNumbers(numberToLeftEnd, numberToBottomEnd);
                
                LimitMoveSet(diagonalNumberToTopRight, enemyPositions, false, 7);
                LimitMoveSet(diagonalNumberToTopLeft, enemyPositions, false, 9);
                LimitMoveSet(diagonalNumberToBottomRight, enemyPositions, true, 9);
                LimitMoveSet(diagonalNumberToBottomLeft, enemyPositions, true, 7);
                
            }
        }
        return _moveSet;
    }
    private void LimitMoveSet(int numberToEnd, List<int> enemyPositions, bool addSign, int middleNumber)
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
                j += numberToEnd;
            }
            else if (_friendPositions.Contains(moveSpace))
            {
                j += numberToEnd;
            }
            else
            {
                AddToMoveSet(moveSpace);
            }
        }
    }
}
        
    
