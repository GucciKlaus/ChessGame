using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    abstract class Gamecharacter
    {
        bool isWhite = false;
        public bool CanMoveToTargetPosition()
        {
            return false;
        }


        public abstract String ToString();

        public abstract bool Movements();
    }
}
