public class King : BoardPiece
{
    private int _positionsRow;
    private int _friendCurrentPosition;
    public King(Player owner, int position, string bottomSprite, int number) : base("King", owner, position, 0, "_+_", bottomSprite, number)
    {
        _inCheck = false;
    }
    public override bool IsInCheck(List<BoardPiece> pieces, int potentialMove) // if the king is in check, other pieces will call this function to limit their moveset
    {
        List<BoardPiece> enemyPieces = new List<BoardPiece>();
        List<BoardPiece> friendPieces = new List<BoardPiece>();
        List<int> friendPositions = [potentialMove];
        foreach (BoardPiece piece in pieces)
        {
            if (piece.GetOwner().GetColor() != _owner.GetColor())
            {
                enemyPieces.Add(piece);
            }
            else
                friendPieces.Add(piece);
                friendPositions.Add(piece.GetPosition());
        }
        foreach (BoardPiece enemyPiece in enemyPieces)
        {
            foreach (int enemyMove in enemyPiece.ViewMoveOptions(pieces))
            {
                if (enemyMove == _position)
                {
                    if (potentialMove == enemyPiece.GetPosition())
                        return false; // if the friend is able to land on and kill the enemy
                    foreach (int move in enemyPiece.ViewMoveOptions(pieces))
                    {
                        string direction = FindDirectionTowardsPiece(enemyPiece.GetPosition(), _position);
                        for (int i = 1; i < 8; i++)
                        {
                            if (direction == "Down")
                            {
                            
                                if (8 * i + enemyPiece.GetPosition() == potentialMove)
                                {
                                    return false;
                                }
                            }
                            if (direction == "Up")
                            {
                            
                                if (-8 * i + enemyPiece.GetPosition() == potentialMove)
                                {
                                    return false;
                                }
                            }
                            if (direction == "Right")
                            {
                            
                                if (1 * i + enemyPiece.GetPosition() == potentialMove)
                                {
                                    return false;
                                }
                            }
                            if (direction == "Left")
                            {
                            
                                if (-1 * i + enemyPiece.GetPosition() == potentialMove)
                                {
                                    return false;
                                }
                            }
                            if (direction == "UpRight")
                            {
                            
                                if (-7 * i + enemyPiece.GetPosition() == potentialMove)
                                {
                                    return false;
                                }
                            }
                            if (direction == "UpLeft")
                            {
                            
                                if (-9 * i + enemyPiece.GetPosition() == potentialMove)
                                {
                                    return false;
                                }
                            }
                            if (direction == "DownRight")
                            {
                            
                                if (9 * i + enemyPiece.GetPosition() == potentialMove)
                                {
                                    return false;
                                }
                            }
                            if (direction == "DownLeft")
                            {
                            
                                if (7 * i + enemyPiece.GetPosition() == potentialMove)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    return true;
                }
            }
            
        }
        return false;
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
                    newPosition = _position + 2;
                }
                else
                {
                    newPosition = _position - 2;
                }
            }
        }
        return newPosition;
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals, bool inCheck = false)
    {
        _inCheck = inCheck;
        List<int> moveSet = new List<int>();
        List<int> friendPositions = new List<int>();
        List<BoardPiece> enemyPieces = new List<BoardPiece>();
        foreach (BoardPiece obstical in obsticals)
        {
            if (obstical.GetPosition() != -1)
            {
                if (obstical.GetOwner().GetColor() == _owner.GetColor())
                {
                    friendPositions.Add(obstical.GetPosition());
                }
                else
                    enemyPieces.Add(obstical);
            }
        }
        for (int x = 8; x <= 64;x += 8)
        {
            if (_position <= x && _position > x - 8)
            {
                _positionsRow = x;
                bool canMoveRight = false;
                bool canMoveLeft = false;
                bool canMoveUp = false;
                bool canMoveDown = false;
                if (_position != x) // move right
                {
                    canMoveRight = true;
                    if (friendPositions.Contains(_position + 1) == false)
                        IsSquareChecked(enemyPieces, obsticals, _position + 1, moveSet);
                }
                if (_position != x - 7) // move left
                {
                    canMoveLeft = true;
                    if (friendPositions.Contains(_position - 1) == false)
                        IsSquareChecked(enemyPieces, obsticals, _position - 1, moveSet);
                }
                if (_position > 8) // move up
                {
                    canMoveUp = true;
                    if (friendPositions.Contains(_position - 8) == false)
                        IsSquareChecked(enemyPieces, obsticals, _position - 8, moveSet);
                }
                if (_position < 57) // move down
                {
                    canMoveDown = true;
                    if (friendPositions.Contains(_position + 8) == false)
                        IsSquareChecked(enemyPieces, obsticals, _position + 8, moveSet);
                }
                if (canMoveRight && canMoveUp && friendPositions.Contains(_position - 7) == false) // up right
                    IsSquareChecked(enemyPieces, obsticals, _position - 7, moveSet);
                if (canMoveLeft && canMoveUp && friendPositions.Contains(_position - 9) == false) // up left
                    IsSquareChecked(enemyPieces, obsticals, _position - 9, moveSet);
                if (canMoveRight && canMoveDown && friendPositions.Contains(_position + 9) == false) // down right
                   IsSquareChecked(enemyPieces, obsticals, _position + 9, moveSet);
                if (canMoveLeft && canMoveDown && friendPositions.Contains(_position + 7) == false) // down left
                    IsSquareChecked(enemyPieces, obsticals, _position + 7, moveSet);
            }
        }
        return moveSet;      
    }
    public bool IsSquareChecked(List<BoardPiece> enemyPieces, List<BoardPiece> obsticals, int moveSpace, List<int> moveSet)
    {
        bool wouldBeInCheck = false;
        int selfIndex = 1;
        foreach (BoardPiece obstical in obsticals)
        {
            if (obstical.GetOwner().GetColor() == _owner.GetColor() && obstical.GetName() == _name) // if the piece is this king piece
            {
                selfIndex = obsticals.IndexOf(obstical);
            }
        }
        BoardPiece self = obsticals[selfIndex];
        obsticals.RemoveAt(selfIndex);
        foreach (BoardPiece enemyPiece in enemyPieces)
        {
            
            foreach (int enemyMove in enemyPiece.ViewMoveOptions(obsticals))
            {
                if (enemyPiece.GetName() == "Pawn")
                {
                    string direction = FindDirectionTowardsPiece(enemyPiece.GetPosition(), enemyMove);
                    int distence = FindDistenceTowardsPosition(enemyPiece.GetPosition(), enemyMove, direction);
                    if ((enemyMove + 1 == moveSpace || enemyMove - 1 == moveSpace) && (direction == "Up" || direction == "Down") && (distence < 2))
                        wouldBeInCheck = true;
                }
                if (enemyMove == moveSpace)
                {
                    if (enemyPiece.GetName() == "Pawn") // pawns cant kill by just moving up or down
                    {
                        string direction = FindDirectionTowardsPiece(enemyPiece.GetPosition(), enemyMove);
                        if (direction != "Up" && direction != "Down")
                        {
                            wouldBeInCheck = true;
                        }
                    }
                    else
                        wouldBeInCheck = true;
                }
            }
        }
        if (wouldBeInCheck == false)
            moveSet.Add(moveSpace);
        obsticals.Add(self);
        return wouldBeInCheck;
    }
    // is used to prevent a player from moving a piece in a way that would reveil the king to check.
    public override bool WouldBeInCheck(int friendCurrentPosition, int potentialPosition, List<BoardPiece> enemyPieces, List<int> friendPositions)
    {
        bool safe = true;
        _friendCurrentPosition = friendCurrentPosition;
        int NumberToRightEnd = _positionsRow - _position; // 4
        int NumberToLeftEnd = _position - (_positionsRow - 7); //3
        int NumberToTopEnd = (_positionsRow - 8) / 8; // 1
        int NumberToBottomEnd = (64 - _positionsRow) / 8; // 6
        if (friendCurrentPosition >= _positionsRow - 7 && friendCurrentPosition <= _positionsRow) // if in same row of king
        {
            if (friendCurrentPosition < _position) // if left of king
            {
                for (int i = 1; i <= NumberToLeftEnd; i++)
                {
                    safe = PotentialPositionCheck(-1, NumberToLeftEnd, potentialPosition, friendPositions, enemyPieces);
                    i += NumberToLeftEnd;
                }
            }
            if (friendCurrentPosition > _position) // if right of king
            {
                for (int i = 1; i <= NumberToRightEnd; i++)
                {
                    safe = PotentialPositionCheck(1, NumberToRightEnd, potentialPosition, friendPositions, enemyPieces);
                    i += NumberToRightEnd;
                }
            }
        }
        else if (friendCurrentPosition < _position) // if above king
        {
            for (int i = 1; i <= NumberToTopEnd; i++)
            {
                if (friendCurrentPosition == _position - (8 * i)) // if directly above
                {
                    safe = PotentialPositionCheck(-8, NumberToTopEnd, potentialPosition, friendPositions, enemyPieces);
                    i += NumberToTopEnd;
                }
                else if (friendCurrentPosition == _position - (7 * i)) // if diagonally top right
                {
                    int DiagonalNumberToTopRight = SetDiagonalNumbers(NumberToRightEnd, NumberToTopEnd);
                    safe = PotentialPositionCheck(-7, DiagonalNumberToTopRight, potentialPosition, friendPositions, enemyPieces);
                    i += NumberToTopEnd;
                }
                else if (friendCurrentPosition == _position - (9 * i)) // if diagonally top left
                {
                    int DiagonalNumberToTopLeft = SetDiagonalNumbers(NumberToLeftEnd, NumberToTopEnd);
                    safe = PotentialPositionCheck(-9, DiagonalNumberToTopLeft, potentialPosition, friendPositions, enemyPieces);
                    i += NumberToTopEnd;
                }
            }
        }
        else if (friendCurrentPosition > _position) // if below king
        {
            for (int i = 1; i <= NumberToBottomEnd; i++)
            {
                if (friendCurrentPosition == _position + (8 * i)) // if directly below
                {
                    safe = PotentialPositionCheck(8, NumberToBottomEnd, potentialPosition, friendPositions, enemyPieces);
                    i += NumberToBottomEnd;
                }
                else if (friendCurrentPosition == _position + (9 * i)) // if diagonally bottom right
                {
                    int DiagonalNumberToBottomRight = SetDiagonalNumbers(NumberToRightEnd, NumberToBottomEnd);
                    safe = PotentialPositionCheck(9, DiagonalNumberToBottomRight, potentialPosition, friendPositions, enemyPieces);
                    i += NumberToBottomEnd;
                }
                else if (friendCurrentPosition == _position + (7 * i)) // if diagonally bottom left
                {
                    int DiagonalNumberToBottomLeft = SetDiagonalNumbers(NumberToLeftEnd, NumberToBottomEnd);
                    safe = PotentialPositionCheck(7, DiagonalNumberToBottomLeft, potentialPosition, friendPositions, enemyPieces);
                    i += NumberToBottomEnd;
                }
            }
        }
        if (safe == false)
            return true;
        else
        {
            return false;
            
        }
    }
    private bool PotentialPositionCheck(int multiplier, int NumberToEnd, int potentialPosition, List<int> friendPositions, List<BoardPiece> enemyPieces)
    {
        bool safe = true;
        string enemy1;
        string enemy2;
        if (multiplier == 8 || multiplier == -8 || multiplier == 1 || multiplier == -1)
        {
            enemy1 = "Queen";
            enemy2 = "Rook";
        }
        else
        {
            enemy1 = "Bishop";
            enemy2 = "Pawn";
        }
        for (int x = 1; x <= NumberToEnd; x++)
        {
            int formulaForPosition = _position + multiplier * x;
            if (potentialPosition == formulaForPosition) // see if its still in the same line
            {
                return safe;
            }
                
            if (_friendCurrentPosition != formulaForPosition) // if it moves out of the line
            {
                safe = FindClosestToKing(friendPositions, enemyPieces, formulaForPosition, enemy1, enemy2);
                if (safe == false)
                    x += NumberToEnd;
            }
        }
        return safe;
    }
    private bool FindClosestToKing(List<int> friendPositions, List<BoardPiece> enemyPieces, int space, string enemyName1, string enemyName2 = "")
    {
        if(friendPositions.Contains(space)) // if the piece is in line first
            return true; // safe stop checking
        foreach (BoardPiece enemyPiece in enemyPieces)
        {
            if (enemyPiece.GetPosition() == space) // if the piece is in line first
            {
                if (enemyPiece.GetName() == enemyName1 || enemyPiece.GetName() == enemyName2)
                    return false;
                else 
                    return true;
            }
        }
        return true;
    }
}