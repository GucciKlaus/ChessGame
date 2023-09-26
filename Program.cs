using ChessGame;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Chessfield field = new Chessfield();
        bool inputcorrect = true;
        string? input = "";
        // Game loop
        do
        {
            field.DrawGame2DArray();
            field.DrawGame2DArrayFigures();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(0, 34);
            if(inputcorrect != true)
            {
                Console.WriteLine("Invalid Input");
            }
            Console.Write("Input:");
            input = Console.ReadLine();
            if (ChessMove.TryParse(input, out ChessMove move))
            {
                Console.Write(move.ToString());
            }
            else
            {
                inputcorrect = false;
            }

        } while (input.ToLower() != "ende");

    }


    
    
}


