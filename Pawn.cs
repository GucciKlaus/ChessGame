using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Pawn : Gamecharacter
    {
        public override bool CanMove()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return IsWhite ? "w P" : "b P";
        }
    }
}
