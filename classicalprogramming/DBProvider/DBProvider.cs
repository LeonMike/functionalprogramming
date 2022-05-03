using classicalprogramming.DBProvider.DBTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classicalprogramming.DBProvider
{
    public interface DBProvider
    {
        public string ConnectionString { get; set; }
        public List<Project> Projects { get; set; }
        public List<Piece> Pieces { get; set; }
        public DBProvider OpenDb();
        public DBProvider CloseDb();

    }
}
