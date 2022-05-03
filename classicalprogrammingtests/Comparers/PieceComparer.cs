using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classicalprogrammingtests.Comparers
{
    public class PieceComparer : IEqualityComparer<classicalprogramming.Interfaces.Piece>
    {
        public bool Equals(classicalprogramming.Interfaces.Piece x, classicalprogramming.Interfaces.Piece y)
        {
            if (x == null && y == null) { return true; }
            else if (x == null || y == null) { return false; }
            else if (object.ReferenceEquals(x, y)) { return true; }

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Data == y.Data;
        }

        public int GetHashCode([DisallowNull] classicalprogramming.Interfaces.Piece obj)
        {
            return $"{obj.Id}{obj.Name}{obj.Data}".GetHashCode();
        }
    }
}
