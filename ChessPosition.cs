using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class ChessPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public static bool TryParse(string s, out ChessPosition position)
        {
            position = null;
            if (s[0] >= 'a' && s[0] <= 'h' && s[1] >= '1' && s[1] <= '8')
            {
                int column = s[0] - 'a' + 1;
                int row = s[1] - '0';

                position.Row = row;
                position.Column = column;
                return true;
            }

            return false;
        }
    }
    
}
