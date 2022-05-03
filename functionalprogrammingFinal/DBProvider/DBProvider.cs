using functionalprogrammingFinal.Interfaces.IEnumerable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace functionalprogrammingFinal.DBProvider
{
    public interface DBProvider
    {
        public string ConnectionString { get; set; }
        public ProjectsEnumerable Projects { get; set; }
        public PiecesEnumerable Pieces { get; set; }

        public IEnumerableExtended Projects2 { get; set; }
        public DBProvider OpenDb();
        public DBProvider CloseDb();

    }
}
