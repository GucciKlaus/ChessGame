using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Queen : Gamecharacter
    {
        public override bool CanMove(ChessMove move, Gamecharacter[,] board)
        {
            bool rookCheck = CanRookMove(move, board);
            bool bishopCeck = CanBishopMove(move, board);
            bool kingCheck = CanKingMove(move, board);
            if(rookCheck == true || bishopCeck == true || kingCheck == true)
            {
                return true;
            }

            

            return false;
        }

        public override string ToString()
        {
            return IsWhite ? "w Q" : "b Q";
        }

        public bool CanRookMove(ChessMove move, Gamecharacter[,] board)
        {
            int rowDiff = move.endposition.row - move.startposition.row;
            int colDiff = move.endposition.column - move.startposition.column;
            int startRow = move.startposition.row;
            int endRow = move.endposition.row;
            int startColumn = move.startposition.column;
            int endColumn = move.endposition.column;
            //Vergleichen negativ
            rowDiff = (rowDiff < 0) ? rowDiff * -1 : rowDiff;
            colDiff = (colDiff < 0) ? colDiff * -1 : colDiff;
            //Prüfen ob sich Figuren im Weg des zuges befinden
            bool verificateCrash = true;
            //Vergleichen ob die Startrow oder die endrow größer ist
            if (startRow > endRow)
            {
                int temp = startRow;
                startRow = endRow;
                endRow = temp;
            }
            //Selbe beim Column
            if (startColumn > endColumn)
            {
                int temp = startColumn;
                startColumn = endColumn;
                endColumn = temp;
            }

            if (rowDiff > 0 ^ colDiff > 0)
            {
                if (rowDiff > 0)
                {
                    for (int row = startRow; row <= endRow; row++)
                    {
                        if (startRow + 1 == endRow)
                        {
                            verificateCrash = true;
                            continue;
                        }

                        if (board[row, move.endposition.column] != null)
                        {
                            if (row++ == move.endposition.row)
                            {
                                return true;
                            }
                            else
                            {
                                verificateCrash = false;
                            }

                        }
                    }

                }
                else
                {
                    for (int col = startColumn; col <= endColumn; col++)
                    {
                        if (startColumn + 1 == endColumn)
                        {
                            verificateCrash = true;
                            continue;
                        }

                        if (board[move.endposition.row, col] != null)
                        {
                            if (col++ == move.endposition.row)
                            {
                                return true;
                            }
                            else
                            {
                                verificateCrash = false;
                            }

                        }

                    }

                }
                if (verificateCrash == true)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool CanKingMove(ChessMove move, Gamecharacter[,] board)
        {
            int rowDiff = move.endposition.row - move.startposition.row;
            int colDiff = move.endposition.column - move.startposition.column;
            //Vergleichen negativ
            rowDiff = (rowDiff < 0) ? rowDiff * -1 : rowDiff;
            colDiff = (colDiff < 0) ? colDiff * -1 : colDiff;

            if (rowDiff == 1 && colDiff == 0)
            {
                return true;
            }
            else if (colDiff == 1 && rowDiff == 0)
            {
                return true;
            }
            else if (rowDiff == 1 && colDiff == 1)
            {
                return true;
            }
            return false;
        }

        public bool CanBishopMove(ChessMove move, Gamecharacter[,] board)
        {
            int rowDif = move.endposition.row - move.startposition.row;
            int colDif = move.endposition.column - move.startposition.column;
            int startRow = move.startposition.row;
            int endRow = move.endposition.row;
            int startCol = move.startposition.column;
            int endCol = move.endposition.column;
            bool verificateCrash = true;


            //Vergleich negativ
            rowDif = rowDif > 0 ? rowDif : rowDif * -1;
            colDif = colDif > 0 ? colDif : colDif * -1;
            //Vergleichen ob end/start row und end/start col größer ist
            if (startRow > endRow)
            {
                int temp = startRow;
                startRow = endRow;
                endRow = temp;
            }

            if (startCol > endCol)
            {
                int temp = startCol;
                startCol = endCol;
                endCol = temp;
            }



            if (rowDif == colDif)
            {
                for (int row = startRow; row < endRow; row++)
                {
                    for (int col = startCol; col < endCol; col++)
                    {
                        if (startRow + 1 == endRow && startCol + 1 == endCol)
                        {
                            verificateCrash = true;
                            break;
                        }

                        if (board[row, col] != null)
                        {
                            if (row + 1 == endRow || col + 1 == endCol)
                            {
                                return true;
                            }
                            else
                            {
                                verificateCrash = false;
                            }

                        }

                    }
                }
            }
            else
            {
                return false;
            }

            if (verificateCrash == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
