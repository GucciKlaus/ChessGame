using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    abstract class Gamecharacter
    {
        public bool  IsWhite { get; set; }
       

        public static bool CanMoveToTargetPosition(ChessMove chessmove,Gamecharacter[,]chessfield)
        {
            for(int row = 0; row < chessfield.GetLength(0); row ++)
            {
                for(int col = 0; col < chessfield.GetLength(1); col++)
                {
                    if(row == chessmove.startposition.Row && col == chessmove.endposition.Column)
                    {
                        string figure = chessfield[row,col].ToString();
                        
                    }
                }
            }


            return false;
        }




        public abstract override String ToString();

        public abstract bool CanMove(ChessMove move, Chessfield[,] board);
    }
}
