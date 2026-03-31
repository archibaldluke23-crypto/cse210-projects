public class Pawn : BoardPiece
{
    private bool _canKill;
    private bool _isAtEnd;
    public Pawn(Player owner, int position) : base("Pawn", owner, position, 1, "(O)")
    {
        _canKill = false;
        _isAtEnd = false;
    }
    public int KillMove(string color, int enemyPosition)
    {
        _position = enemyPosition;
        throw new NotImplementedException();
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals)
    {
        throw new NotImplementedException();
    }
}