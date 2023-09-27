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
            int rowDiff = move.endposition.Row - move.startposition.Row;
            int colDiff = move.endposition.Column - move.startposition.Column;
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
                Gamecharacter targetCharacter = board[move.endposition.Row, move.endposition.Column];
                if (targetCharacter != null && targetCharacter.IsWhite != this.IsWhite)
                {
                    return true;
                }
                return false;
            }

            //  Doppelschritt machen kann (nur zu Beginn)
            if (rowDiff == 2 && colDiff == 0 && move.startposition.Row == 6 || move.startposition.Row==1 && board[move.endposition.Row, move.endposition.Column] == null)
            {
                int targetRow = (move.startposition.Row + move.endposition.Row) / 2;
                if (board[targetRow, move.endposition.Column] == null)
                {
                    return true;
                }
            }

            // Einzelschritt machen kann
            if (rowDiff == 1 && colDiff == 0 && board[move.endposition.Row, move.endposition.Column] == null)
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
