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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return IsWhite ? "w K" : "b K";
        }
    }
}
