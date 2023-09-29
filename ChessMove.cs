using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class ChessMove
    {
        public ChessPosition? startposition { get; set; }
        public ChessPosition? endposition { get; set; }

        public static bool TryParse(string s, out ChessMove move)
        {
            move = new ChessMove();
            s = s.Trim().ToLower();
            
            if(s.Length == 5 && s[2] == '-')
            {
                String[] position = s.Split('-');
                for(int i = 0; i < position.Length; i++)
                {
                    bool compareL = CheckLetters(position[i]);
                    bool compareN = CheckNumbers(position[i]);
                    if(compareL==false || compareN == false)
                    {
                        move = null;
                        return false;
                    }
                }
                ChessPosition chessPosition = new ChessPosition();
                if (ChessPosition.TryParse(position[0], out var startPosition) && ChessPosition.TryParse(position[1], out var endPosition))
                {
                    move.startposition = startPosition;
                    move.endposition = endPosition;
                    return true;
                }
                else { move = null; return false; }
                
            }
            else
            {
                move = null;
                return false;
            }
            
        }

        public static bool CheckLetters(String s)
        {
            string lettersToCheck = "abcdefgh";

            foreach (char letter in lettersToCheck)
            {
                if (s.Contains(letter))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckNumbers(String s)
        {
            string lettersToCheck = "12345678";

            foreach (char letter in lettersToCheck)
            {
                if (s.Contains(letter))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
