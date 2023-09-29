using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Rook : Gamecharacter
    {
        //Nur reihen oder zeilen
        public override bool CanMove(ChessMove move, Gamecharacter[,] board)
        {
            int rowDiff = move.endposition.Row - move.startposition.Row;
            int colDiff = move.endposition.Column - move.startposition.Column;
            int startRow = move.startposition.Row;
            int endRow = move.endposition.Row;
            int startColumn = move.startposition.Column;
            int endColumn = move.endposition.Column;
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

                        if (board[row, move.endposition.Column] != null)
                        {
                            if (row++ == move.endposition.Row)
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

                        if (board[move.endposition.Row, col] != null)
                        {
                            if(col++ == move.endposition.Row)
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

        public override string ToString()
        {
            return IsWhite ? "w R" : "b R";
        }
    }
}
