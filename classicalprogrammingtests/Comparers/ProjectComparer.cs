using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classicalprogrammingtests.Comparers
{
    public class ProjectComparer : IEqualityComparer<classicalprogramming.Interfaces.Project>
    {
        public bool Equals(classicalprogramming.Interfaces.Project x, classicalprogramming.Interfaces.Project y)
        {
            if (x == null && y == null) { return true; }
            else if (x == null || y == null) { return false; }
            else if (object.ReferenceEquals(x, y)) { return true; }

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Data == y.Data;
        }

        public int GetHashCode([DisallowNull] classicalprogramming.Interfaces.Project obj)
        {
            return $"{obj.Id}{obj.Name}{obj.Data}".GetHashCode();
        }
    }
}
