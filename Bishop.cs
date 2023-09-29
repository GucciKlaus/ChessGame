using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Bishop : Gamecharacter
    {
        public override bool CanMove(ChessMove move, Gamecharacter[,] board)
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
                        if(startRow+1 == endRow && startCol+1 == endCol)
                        {
                            verificateCrash = true;
                            break;
                        }

                        if (board[row, col] != null)
                        {
                            if(row+1 == endRow || col+1 == endCol)
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

        public override string ToString()
        {
            return IsWhite ? "w B" : "b B";
        }
    }
}
