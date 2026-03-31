public class Bishop : BoardPiece
{
    public Bishop(Player owner, int position) : base("Bishop", owner, position, 3, "(/)")
    {
        
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals)
    {
        throw new NotImplementedException();
    }
}