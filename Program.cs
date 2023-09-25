using ChessGame;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Chessfield.CreateGame2DArray();
        int[,] Field = new int[8, 8];
        PlaceFigures.Place(Field);
    }
    
}


