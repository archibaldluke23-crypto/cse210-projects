public class Rook : BoardPiece
{
    public Rook(Player owner, int position) : base("Rook", owner, position, 5, "(O)")
    {
    }
    public override int Castle(bool clearPath, int otherPiecePosition,  bool askPlayer = false)
    {
        return base.Castle(clearPath, otherPiecePosition);
        throw new NotImplementedException();
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals)
    {
        throw new NotImplementedException();
    }
}