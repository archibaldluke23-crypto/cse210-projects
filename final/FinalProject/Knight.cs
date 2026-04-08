public class Knight : BoardPiece
{
    public Knight(Player owner, int position, string bottomSprite, int number) : base("Knight", owner, position, 3, "{XJ", bottomSprite, number)
    {
        
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals, bool inCheck = false)
    {
        _inCheck = inCheck;
        _moveSet.Clear();
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
                }
            }
        }
        // can move 6, 10, 15, 17
        for (int x = 8; x <= 64;x += 8)
        {
            if (_position <= x && _position > x - 8) // if _position = 12
            {
                if (_position > x - 6) // left most squares
                {
                    if (x > 8 && _friendPositions.Contains(_position - 10) == false) // left top
                        AddToMoveSet(_position - 10);
                    if (x < 64 && _friendPositions.Contains(_position + 6) == false) // left bottom
                        AddToMoveSet(_position + 6);
                }
                if (_position < x - 1) // right most squares
                {
                    if (x > 8 && _friendPositions.Contains(_position - 6) == false) // right top
                        AddToMoveSet(_position - 6);
                    if (x < 64 && _friendPositions.Contains(_position + 10) == false) // right bottom
                        AddToMoveSet(_position + 10);
                }
                if (_position > x - 7) // top and bottom left most squares
                {
                    if (x > 16 && _friendPositions.Contains(_position - 17) == false) // top left
                        AddToMoveSet(_position - 17);
                    if (x < 56 && _friendPositions.Contains(_position + 15) == false) // bottom left
                        AddToMoveSet(_position + 15);
                }
                if (_position < x) // top and bottom right most squares
                {
                    if (x > 16 && _friendPositions.Contains(_position - 15) == false) // top right
                        AddToMoveSet(_position - 15);
                    if (x < 56 && _friendPositions.Contains(_position + 17) == false) // bottom right
                        AddToMoveSet(_position + 17);
                }
            }
        }
        return _moveSet;
    }
}
        
    
