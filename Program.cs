using ChessGame;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Chessfield field = new Chessfield();

        string? input = "";
        // Game loop
        do
        {
            field.DrawGame2DArray();
            field.DrawGame2DArrayFigures();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(0, 34);
            Console.Write("Input:");
            input = Console.ReadLine();


        } while (input.ToLower() !="ende");
        
    }
    
}


