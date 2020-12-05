using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class BoardingPass
    {
        public int Row { get; init; }
        public int Column { get; init; }

        public int GetSeatId()
        {
            return Row * 8 + Column;
        }

        public static BoardingPass FromString(string encodedPass)
        {
            int minRow = 0;
            int maxRow = 127;
            int minCol = 0;
            int maxCol = 7;

            foreach (char dir in encodedPass.Substring(0, 7))
            {
                if (dir == 'F')
                {
                    maxRow = (int)Math.Floor((minRow + maxRow) / 2.0);
                }
                else
                {
                    minRow = (int)Math.Ceiling((minRow + maxRow) / 2.0);
                }
            }

            foreach (char dir in encodedPass.Substring(7, 3))
            {
                if (dir == 'L')
                {
                    maxCol = (int)Math.Floor((minCol + maxCol) / 2.0);
                }
                else
                {
                    minCol = (int)Math.Ceiling((minCol + maxCol) / 2.0);
                }
            }

            return new BoardingPass { Column = minCol, Row = minRow };
        }

        public string ToString()
        {
            return $"Row {Row}, Column {Column}";
        }

    }
}
