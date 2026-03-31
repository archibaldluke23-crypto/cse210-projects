public class Knight : BoardPiece
{
    public Knight(Player owner, int position) : base("Knight", owner, position, 3, "(O)")
    {
        
    }
    public override List<int> ViewMoveOptions(List<BoardPiece> obsticals)
    {
        throw new NotImplementedException();
    }
}