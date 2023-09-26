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
       

        public bool CanMoveToTargetPosition(Gamecharacter[,]chessfield)
        {



            return false;
        }


        public abstract override String ToString();

        public abstract bool CanMove();
    }
}
