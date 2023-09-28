using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGame
{
    internal class Chessfield
    {
        public Gamecharacter[,] chessfield = new Gamecharacter[8, 8];

        public Chessfield()
        {
            Place(chessfield);
        }
        public void DrawGame2DArrayFigures()
        {
            int offsetRow = 3;
            int offsetCol = 5;
            int rowHight = 4;
            int colWidth = 6;

            for (int row = 0; row < chessfield.GetLength(0); row++)
            {
                for (int col = 0; col < chessfield.GetLength(1); col++)
                {
                    if (chessfield[row, col] != null)
                    {
                        Console.SetCursorPosition(offsetCol + col * colWidth, offsetRow + row * rowHight);
                        Console.Write(chessfield[row, col].ToString());
                    }
                }
            }
        }
        public void DrawGame2DArray()
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

        }

        public static void Place(Gamecharacter[,] ChessField)
        {
            for (int ChessColor = 0; ChessColor < 2; ChessColor++)
            {
                //Erstellen der Bauern
                //for (int j = 0; j < 8; j++)
                //{
                //    ChessField[6 - ChessColor * 5, j] = new Pawn { IsWhite = ChessColor == 0 };
                //}
                int rookRow = ChessColor == 0 ? 7 : 0;
                ChessField[rookRow, 0] = new Rook { IsWhite = ChessColor == 0 };
                ChessField[rookRow, 7] = new Rook { IsWhite = ChessColor == 0 };


                int knightRow = ChessColor == 0 ? 7 : 0;
                ChessField[knightRow, 1] = new Knight { IsWhite = ChessColor == 0 };
                ChessField[knightRow, 6] = new Knight { IsWhite = ChessColor == 0 };


                int bishopRow = ChessColor == 0 ? 7 : 0;
                ChessField[bishopRow, 2] = new Bishop { IsWhite = ChessColor == 0 };
                ChessField[bishopRow, 5] = new Bishop { IsWhite = ChessColor == 0 };


                int queenRow = ChessColor == 0 ? 7 : 0;
                ChessField[queenRow, 3] = new Queen { IsWhite = ChessColor == 0 };


                int kingRow = ChessColor == 0 ? 7 : 0;
                ChessField[kingRow, 4] = new King { IsWhite = ChessColor == 0 };

            }
        }
    }
}
