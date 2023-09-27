using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Pawn : Gamecharacter
    {
        //Klärt ab ob der Zug dieser Figur möglich ist
        public override bool CanMove(ChessMove move, Chessfield[,] board)
        {
            bool throwmove = false;
            bool jumpstart = false;
            //Schauen ob der Zug grundsätzlich mit einem Bauern gültig ist
            if (move.endposition.Row >= move.startposition.Row + 2 && move.endposition.Column >= move.startposition.Column++)
            {
                return false;
            }
            //Prüfen ob Werfen oder Jumpstart
            if (move.endposition.Column < move.startposition.Column || move.endposition.Column > move.startposition.Column)
            {
                throwmove = true;
            }
            else if (move.startposition.Row == 6 || move.startposition.Row == 2)
            {
                if (move.endposition.Row - move.startposition.Row == 2)
                {
                    jumpstart = true;
                }
            }
            //Prüfen ob wer im Weg steht
            for (int row = 2; row < 8; row ++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (row == move.endposition.Row && col == move.endposition.Column)
                    {
                        if (board[row,col]  != null && throwmove==true)
                        {
                            return true;
                        }
                        if (board[row, col] == null)
                        {
                            return true;
                        }
                        if (board[row, col] == null && board[row--,col--] == null && jumpstart == true)
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }

        public override string ToString()
        {
            return IsWhite ? "w P" : "b P";
        }
    }
}
