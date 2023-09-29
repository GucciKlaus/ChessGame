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
            Gamecharacter tempstart = chessfield[chessmove.startposition.row, chessmove.startposition.column];
            if(tempstart == null) return false;
            if (tempstart.CanMove(chessmove, chessfield) == true)
            {
                return ValidateMove(chessfield, tempstart, chessmove);
            }
            return false;
        }

        public static bool IsKingWhiteAlive(Gamecharacter[,] chessfield)
        {
            bool whiteKing = false;
            for(int row = 0; row < chessfield.GetLength(0); row++)
            {
                for(int col = 0; col < chessfield.GetLength(1); col++)
                {
                    if (chessfield[row,col] != null)
                    {
                        Gamecharacter temp = chessfield[row,col];
                        if (temp.GetType() == typeof(King))
                        {
                            if(temp.IsWhite == true)
                            {
                                whiteKing = true;
                            }
                        }
                    }
                }
            }
            return whiteKing;
        }

        public static bool IsKingBlackAlive(Gamecharacter[,] chessfield)
        {
            bool blackKing = false;
            for (int row = 0; row < chessfield.GetLength(0); row++)
            {
                for (int col = 0; col < chessfield.GetLength(1); col++)
                {
                    if (chessfield[row, col] != null)
                    {
                        Gamecharacter temp = chessfield[row, col];
                        if (temp.GetType() == typeof(King))
                        {
                            if (temp.IsWhite == false)
                            {
                                blackKing = true;
                            }
                        }
                    }
                }
            }
            return blackKing;
        }

        public static bool ValidateMove(Gamecharacter[,] chessfield, Gamecharacter tempstart, ChessMove chessmove)
        {
            //Nach endposition vergleiche und dann schauen ob da eine figur ist und wenn ja schau ob schwarz oder weiß wenn sie nicht diesselbe farbe wie die aktuelle figur hat true zurückliefern
            Gamecharacter tempend = null;
            if (chessfield[chessmove.endposition.row, chessmove.endposition.column] != null)
            {
                tempend = chessfield[chessmove.endposition.row, chessmove.endposition.column];
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
            Gamecharacter temp = chessfield[chessMove.startposition.row,chessMove.startposition.column];
            chessfield[chessMove.startposition.row, chessMove.startposition.column] = null;
            chessfield[chessMove.endposition.row, chessMove.endposition.column] = temp;
            return chessfield;
        }

        public static bool OnTurn(ChessMove chessMove, bool colorWhite, Gamecharacter[,] chessfield)
        {
            Gamecharacter temp = chessfield[chessMove.startposition.row, chessMove.startposition.column];
            if(temp.IsWhite == colorWhite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract override String ToString();

        public abstract bool CanMove(ChessMove move, Gamecharacter[,] board);
    }
}
