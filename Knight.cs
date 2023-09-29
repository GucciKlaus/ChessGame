using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Knight : Gamecharacter
    {
        public override bool CanMove(ChessMove move, Gamecharacter[,] board)
        {
            int rowDiff = move.endposition.row - move.startposition.row;
            int colDiff = move.endposition.column - move.startposition.column;
            //Vergleichen negativ
            rowDiff = (rowDiff < 0) ? rowDiff * -1 : rowDiff;
            colDiff = (colDiff < 0) ? colDiff * -1 : colDiff;

            if (rowDiff == 2 && colDiff == 1)
            {
                return true;
            }else if(rowDiff == 1 && colDiff == 2) {
                return true;
            }else if(rowDiff == -2  && colDiff == -1) {
                return true;
            }
            else if(rowDiff == -1 && colDiff == -2){
                return true;
            }
            else
            {
                return false;
            }

        }

        public override string ToString()
        {
            return IsWhite ? "w k" : "b k";
        }
    }
}
