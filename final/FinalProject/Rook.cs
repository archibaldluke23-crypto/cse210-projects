public class Rook : BoardPiece
{
    public Rook(Player owner, int position, string bottomSprite, int number) : base("Rook", owner, position, 5, "###", bottomSprite, number)
    {
    }
    public override int Castle(int otherPiecePosition, Board board, bool askPlayer = false)
    {
        string input = "Y";
        int newPosition = _position;
        if (_hasMoved == false)
        {
            if (askPlayer)
            {
                Console.WriteLine("Would you like to castle? (Y/N): ");
                input = Console.ReadLine();
            }
            if (input == "Y")
            {
                if (otherPiecePosition > _position)
                {
                    newPosition = otherPiecePosition - 1;
                }
                else
                {
                    newPosition = otherPiecePosition + 1;
                }
            }
        }
        return newPosition;
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals, bool inCheck = false)
    {
        _inCheck = inCheck;
        _moveSet.Clear();
        List<int> enemyPositions = new List<int>();
        _friendPositions.Clear();
        _enemyPieces.Clear();
        _obsticals = obsticals;
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
            if (_position <= x && _position > x - 8) // if _position = 12
            {
                int NumberToRightEnd = x - _position; // 4
                int NumberToLeftEnd = _position - (x - 7); //3
                int NumberToTopEnd = (x - 8) / 8; // 1
                int NumberToBottomEnd = (64 - x) / 8; // 6
                LimitMoveSet(NumberToRightEnd, _moveSet, enemyPositions, _friendPositions, true, 1);
                LimitMoveSet(NumberToLeftEnd, _moveSet, enemyPositions, _friendPositions, false, 1);
                LimitMoveSet(NumberToTopEnd, _moveSet, enemyPositions, _friendPositions, false, 8);
                LimitMoveSet(NumberToBottomEnd, _moveSet, enemyPositions, _friendPositions, true, 8);
                
            }
        }
        return _moveSet;
    }
    private void LimitMoveSet(int NumberToEnd, List<int> moveSet, List<int> enemyPositions, List<int> friendPositions, bool addSign, int middleNumber)
    {
        BoardPiece king = _owner.FindPieceInList("k");
        for (int j = 1; j <= NumberToEnd; j++)
        {
            int moveSpace;
            if (addSign)
                moveSpace = _position + (middleNumber * j);
            else
                moveSpace = _position - (middleNumber * j);
            if (enemyPositions.Contains(moveSpace))
            {
                
                AddToMoveSet(moveSpace);
                j += NumberToEnd + 1;
            }
            else if (friendPositions.Contains(moveSpace))
            {
                j += NumberToEnd + 1;
            }
            else
            {
                AddToMoveSet(moveSpace);
            }
        }
    }
}
        
    
