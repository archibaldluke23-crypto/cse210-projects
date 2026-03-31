public abstract class BoardPiece
{
    protected string _name;
    protected Player _owner;
    protected bool _isDead;
    protected int _position;
    protected string _sprite;
    protected int _value;
    protected bool _hasMoved;
    public BoardPiece(string name, Player owner, int position, int value, string sprite)
    {
        _name = name;
        _owner = owner;
        _position = position;
        _value = value;
        _sprite = sprite;
        _hasMoved = false;
    }
    public int Die()
    {
        _isDead = true;
        _position = -1;
        return _value;

    }
    public string GetSprite()
    {
        return _sprite;
    }
    public string GetName()
    {
        return _name;
    }
    public Player GetOwner()
    {
        return _owner;
    }
    public void ChangePosition(int position)
    {
        _position = position;
        _hasMoved = true;
    }
    public virtual int Castle(bool clearPath, int otherPiecePosition, bool askPlayer = false)
    {
        return _position;
    }
    public virtual List<int> Check(BoardPiece enemyType, int enemyPosition)
    {
        return [-1];
    }
    public abstract List<int> ViewMoveOptions(List<BoardPiece> obsticals);
}