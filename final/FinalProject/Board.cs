public class Board
{
//   
//  (O)
//  /1\
//  
//  ###
//  |1|
//  
// (/)
// /2\
// 
// {XJ
// (2\
//     _____|
//    | WWW |
//    | |2| |
//    |_^^^_|_
//    | _+_ |
//    | |1| |
//    |_____|
// 
// 
// 
// 
// 
// 
// 
// 
// 
// 
// 
// 
// 
// 
// 

    private List<BoardPiece> _positions = new List<BoardPiece>();
    public Board(List<BoardPiece> playerBoardPieces)
    {
        
    }
    public void ShowBoard(List<int> moveOptions = null)
    {
        // Console.WriteLine( " _____ _____ _____ _____ _____ _____ _____ _____ ");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine( "|_____|_____|_____|_____|_____|_____|_____|_____|");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine( "|_____|_____|_____|_____|_____|_____|_____|_____|");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine( "|_____|_____|_____|_____|_____|_____|_____|_____|");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine( "|_____|_____|_____|_____|_____|_____|_____|_____|");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine( "|_____|_____|_____|_____|_____|_____|_____|_____|");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine( "|_____|_____|_____|_____|_____|_____|_____|_____|");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine( "|_____|_____|_____|_____|_____|_____|_____|_____|");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine($"| { } | { } | { } | { } | { } | { } | { } | { } |");
        // Console.WriteLine( "|_____|_____|_____|_____|_____|_____|_____|_____|");
    }
    public BoardPiece MovePiece(BoardPiece piece, int position) // return killed piece
    {
        throw new NotImplementedException();
    }
    public int CheckPosition(BoardPiece piece)
    {
        throw new NotImplementedException();
    }
    public BoardPiece OccupiedBy(int tilePosition)
    {
        throw new NotImplementedException();
    }
    public bool Occupied(int tilePosition)
    {
        throw new NotImplementedException();
    }
    public List<BoardPiece> GetPositions()
    {
        throw new NotImplementedException();
    }
}
