﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Knight : Gamecharacter
    {
        public override bool CanMove(ChessMove move, Chessfield[,] board)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return IsWhite ? "w k" : "b k";
        }
    }
}
