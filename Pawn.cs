using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Pawn : Gamecharacter
    {
        public override bool CanMove(ChessMove move, Gamecharacter[,] board)
        {
            int rowDiff = move.endposition.row - move.startposition.row;
            int colDiff = move.endposition.column - move.startposition.column;
            //Vergleichen negativ
            rowDiff = (rowDiff < 0) ? rowDiff * -1 : rowDiff;
            colDiff = (colDiff < 0) ? colDiff * -1 : colDiff;

            // erlaubten Grenzen 
            if (rowDiff > 2 || colDiff > 1)
            {
                return false;
            }

            //  diagonal schlagen
            if (rowDiff == 1 && colDiff == 1)
            {
                if (board[move.endposition.row,move.endposition.column] != null)
                {
                    return true;
                }
                return false;
            }

            //  Doppelschritt machen kann (nur zu Beginn)
            if (rowDiff == 2 && colDiff == 0 && move.startposition.row == 6 || move.startposition.row==1 && board[move.endposition.row, move.endposition.column] == null)
            {
                int betweenrow = (move.startposition.row + move.endposition.row) / 2;
                if (board[betweenrow, move.endposition.column] == null)
                {
                    return true;
                }
            }

            // Einzelschritt machen kann
            if (rowDiff == 1 && colDiff == 0 && board[move.endposition.row, move.endposition.column] == null)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return IsWhite ? "w P" : "b P";
        }
    }
}
