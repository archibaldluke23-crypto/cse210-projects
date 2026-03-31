public class Queen : BoardPiece
{
    public Queen(Player owner, int position) : base("Queen", owner, position, 9, "(O)")
    {
        
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals)
    {
        throw new NotImplementedException();
    }
}