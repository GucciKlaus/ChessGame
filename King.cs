using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class King : Gamecharacter
    {
        public override bool CanMove(ChessMove move, Gamecharacter[,] board)
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
            else if (colDiff == 1 && rowDiff== 0)
            {
                return true;
            }else if (rowDiff == 1 && colDiff == 1) { 
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return IsWhite ? "w K" : "b K";
        }
    }
}
