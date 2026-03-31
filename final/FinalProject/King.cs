public class King : BoardPiece
{
    private bool _inCheck;
    public King(Player owner, int position) : base("King", owner, position, 0, "(O)")
    {
        
    }
    public List<int> Check(BoardPiece enemyType, int enemyPosition)
    {
        throw new NotImplementedException();
    }
    public bool EndGame()
    {
        throw new NotImplementedException();
    }
    public override int Castle(bool clearPath, int otherPiecePosition, bool askPlayer = false)
    {
        return base.Castle(clearPath, otherPiecePosition);
        throw new NotImplementedException();
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals)
    {
        throw new NotImplementedException();
    }
}