using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Chessfield
    {
        public static void CreateGame2DArray()
        {
            //51 * 33
            Console.Clear();
            String[,] board = new string[33, 50];
            int counter = 1;
            int linecounter = 8;
            bool firstline = true;
            String headLine = "     a     b     c     d     e     f     g     h    ";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(headLine);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    if (j == 0)
                    {
                        if (firstline == true && counter == 3)
                        {
                            board[i, j] = linecounter + "  ";
                            linecounter--;
                            counter = 0;
                            firstline = false;
                        }
                        if (counter == 4)
                        {
                            board[i, j] = linecounter + "  ";
                            linecounter--;
                            counter = 0;
                        }
                        else
                        {
                            if (board[i, j] == null)
                            {
                                board[i, j] = "   ";
                            }
                        }
                    }
                    else
                    {
                        board[i, j] = "0";
                    }
                    Console.Write(board[i, j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                counter++;
                Console.WriteLine();
            }
            bool color = false;
            //x-Achse
            for (int a = 0; a < 8 * 4; a += 4)
            {
                //3-zeilen
                for (int i = 2; i < 5; i++)
                {
                    //y-Achse
                    for (int y = 4; y < board.GetLength(1); y += 6)
                    {
                        if (color == false)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            color = true;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            color = false;
                        }
                        Console.SetCursorPosition(y, i + a);
                        Console.Write("     ");
                    }
                }
                if (color == false)
                {
                    color = true;
                }
                else
                {
                    color = false;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Input:");
            string? input = Console.ReadLine();
        }
    }
}
