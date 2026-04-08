public class Board
{

    private Pawn _blankPiece = new Pawn(null, -1, "   ", 0);
    private Dictionary<int, BoardPiece> _positions = new Dictionary<int, BoardPiece>();
    private Dictionary<int, string> _moveOptions = new Dictionary<int, string>();
    private List<BoardPiece> _playerBoardPieces = new List<BoardPiece>();
    public Board()
    {
        for (int x = 1; x < 65; x++)
        {
            _positions.Add(x, _blankPiece);
            _moveOptions.Add(x, "___");
        }
    }
    public void SetBoardPieces(List<BoardPiece> boardPieces)
    {

        foreach (BoardPiece piece in boardPieces)
        {
            _playerBoardPieces.Add(piece);
            int index = piece.GetPosition();
            _positions[index] = piece;
        }
    }
    public string BoardRow(int i, bool top = true)
    {
        if (top)
        {
            return $"|   {_positions[i].GetSpriteTop()} {_positions[i].GetNumber()} |   {_positions[i+1].GetSpriteTop()} {_positions[i+1].GetNumber()} |   {_positions[i+2].GetSpriteTop()} {_positions[i+2].GetNumber()} |   {_positions[i+3].GetSpriteTop()} {_positions[i+3].GetNumber()} |   {_positions[i+4].GetSpriteTop()} {_positions[i+4].GetNumber()} |   {_positions[i+5].GetSpriteTop()} {_positions[i+5].GetNumber()} |   {_positions[i+6].GetSpriteTop()} {_positions[i+6].GetNumber()} |   {_positions[i+7].GetSpriteTop()} {_positions[i+7].GetNumber()} |";
        }
        else
        {
            return $"|   {_positions[i].GetSpriteBottom()}   |   {_positions[i+1].GetSpriteBottom()}   |   {_positions[i+2].GetSpriteBottom()}   |   {_positions[i+3].GetSpriteBottom()}   |   {_positions[i+4].GetSpriteBottom()}   |   {_positions[i+5].GetSpriteBottom()}   |   {_positions[i+6].GetSpriteBottom()}   |   {_positions[i+7].GetSpriteBottom()}   | ";
        }
    }
    private string BottomOfBox(int i)
    {
        return $"|___{_moveOptions[i]}___|___{_moveOptions[i+1]}___|___{_moveOptions[i+2]}___|___{_moveOptions[i+3]}___|___{_moveOptions[i+4]}___|___{_moveOptions[i+5]}___|___{_moveOptions[i+6]}___|___{_moveOptions[i+7]}___|";
    }
    public void ShowBoard(List<int> moveOptions = null)
    {
        if (moveOptions != null)
        {
            foreach(int moveOption in moveOptions)
            {
                if (moveOption < 10)
                    _moveOptions[moveOption] = $"{moveOption}^^";
                else
                    _moveOptions[moveOption] = $"{moveOption}^"; // displays the availible spaces a piece can move to.
            }
        }
        Console.WriteLine(   " _________ _________ _________ _________ _________ _________ _________ _________ ");
        Console.WriteLine(BoardRow(1));
        Console.WriteLine(BoardRow(1, false));
        Console.WriteLine(BottomOfBox(1));
        Console.WriteLine(BoardRow(9));
        Console.WriteLine(BoardRow(9, false));
        Console.WriteLine(BottomOfBox(9));
        Console.WriteLine(BoardRow(17));
        Console.WriteLine(BoardRow(17, false));
        Console.WriteLine(BottomOfBox(17));
        Console.WriteLine(BoardRow(25));
        Console.WriteLine(BoardRow(25, false));
        Console.WriteLine(BottomOfBox(25));
        Console.WriteLine(BoardRow(33));
        Console.WriteLine(BoardRow(33, false));
        Console.WriteLine(BottomOfBox(33));
        Console.WriteLine(BoardRow(41));
        Console.WriteLine(BoardRow(41, false));
        Console.WriteLine(BottomOfBox(41));
        Console.WriteLine(BoardRow(49));
        Console.WriteLine(BoardRow(49, false));
        Console.WriteLine(BottomOfBox(49));
        Console.WriteLine(BoardRow(57));
        Console.WriteLine(BoardRow(57, false));
        Console.WriteLine(BottomOfBox(57));
        if (moveOptions != null)
        {
            foreach(int moveOption in moveOptions)
                {
                    _moveOptions[moveOption] = $"___"; // revert back to og
                }
        }
    }
    public BoardPiece MovePiece(BoardPiece piece, int newPosition) // return killed piece
    {
        BoardPiece dieingPiece = _positions[newPosition];
        _playerBoardPieces.Remove(dieingPiece);
        _positions[newPosition] = piece;
        if (newPosition != piece.GetPosition())
            _positions[piece.GetPosition()] = _blankPiece;
        return dieingPiece;
    }
    public BoardPiece OccupiedBy(int tilePosition)
    {
        return _positions[tilePosition];
    }
    public bool Occupied(int tilePosition)
    {
        if (tilePosition > 0 && tilePosition < 65)
        {
            if (_positions[tilePosition].GetPosition() == -1)
                return false;
        }
        return true;
    }
    public List<BoardPiece> GetPieces()
    {
        return _playerBoardPieces;
    }
}
