using ChessGame;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Chessfield field = new Chessfield();
        bool inputcorrect = true;
        bool turnWhite = true;
        string? input = "";
        // Game loop
        do
        {
            bool[] alive = CheckEnd(field.chessfield);
            if (alive[0] == false)
            {
                Console.WriteLine("Black wins!");
                break;
            }
            else if (alive[1] == false)
            {
                Console.WriteLine("White wins!");
                break;
            }

            field.DrawGame2DArray();
            field.DrawGame2DArrayFigures();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 34);
            if (inputcorrect != true)
            {
                Console.WriteLine("Invalid Input");
                inputcorrect = true;
            }
            Console.WriteLine(TurnOrder(turnWhite));

            Console.Write("Input:");
            input = Console.ReadLine();
            if (ChessMove.TryParse(input, out ChessMove move))
            {
                if (Gamecharacter.CanMoveToTargetPosition(move, field.chessfield) == true && Gamecharacter.OnTurn(move, turnWhite, field.chessfield))
                {
                    field.chessfield = Gamecharacter.ChangePosition(move, field.chessfield);
                    if (turnWhite == true)
                    {
                        turnWhite = false;
                    }
                    else
                    {
                        turnWhite = true;
                    }
                }
                else
                {
                    inputcorrect = false;
                }

            }
            else
            {
                inputcorrect = false;
            }

        } while (input.ToLower() != "ende");

    }

    public static String TurnOrder(bool isWhite)
    {
        if (isWhite == true)
        {
            return "Weiß ist am Zug";
        }
        else
        {
            return "Schwarz ist am Zug";
        }
    }

    public static bool[] CheckEnd(Gamecharacter[,] chessfield)
    {
        bool[] result = new bool[2];
        result[0] = Gamecharacter.IsKingWhiteAlive(chessfield);
        result[1] = Gamecharacter.IsKingBlackAlive(chessfield);
        return result;
    }


}


