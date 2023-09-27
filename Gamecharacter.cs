using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    abstract class Gamecharacter
    {
        public bool IsWhite { get; set; }


        public static bool CanMoveToTargetPosition(ChessMove chessmove, Gamecharacter[,] chessfield)
        {

            Gamecharacter tempstart = chessfield[chessmove.startposition.Row, chessmove.startposition.Column];
            if (tempstart.CanMove(chessmove, chessfield) == true)
            {
                return ValidateMove(chessfield, tempstart, chessmove);
            }
            return false;
        }

        public static bool ValidateMove(Gamecharacter[,] chessfield, Gamecharacter tempstart, ChessMove chessmove)
        {
            //Nach endposition vergleiche und dann schauen ob da eine figur ist und wenn ja schau ob schwarz oder weiß wenn sie nicht diesselbe farbe wie die aktuelle figur hat true zurückliefern
            Gamecharacter tempend = null;
            if (chessfield[chessmove.endposition.Row, chessmove.endposition.Column] != null)
            {
                tempend = chessfield[chessmove.endposition.Row, chessmove.endposition.Column];
                if (tempend.IsWhite == tempstart.IsWhite)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else { return true; }
        }

        public static Gamecharacter[,] ChangePosition(ChessMove chessMove, Gamecharacter[,] chessfield)
        {
            Gamecharacter temp = chessfield[chessMove.startposition.Row,chessMove.startposition.Column];
            chessfield[chessMove.startposition.Row, chessMove.startposition.Column] = null;
            chessfield[chessMove.endposition.Row, chessMove.endposition.Column] = temp;
            return chessfield;
        }


        public abstract override String ToString();

        public abstract bool CanMove(ChessMove move, Gamecharacter[,] board);
    }
}
