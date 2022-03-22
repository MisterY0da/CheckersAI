using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Move : IEquatable<Move>
    {
        public int RowStart { get; }
        public int ColStart { get; }
        public int RowEnd { get; }
        public int ColEnd { get; }

        public Move(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            RowStart = rowStart;
            ColStart = colStart;
            RowEnd = rowEnd;
            ColEnd = colEnd;
        }

        public bool Equals(Move other)
        {
            return RowStart == other.RowStart && ColStart == other.ColStart &&
                   RowEnd == other.RowEnd && ColEnd == other.ColEnd;
        }
    }
}
