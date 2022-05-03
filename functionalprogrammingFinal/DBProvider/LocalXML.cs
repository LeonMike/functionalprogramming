using functionalprogrammingFinal.Interfaces.IEnumerable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace functionalprogrammingFinal.DBProvider
{
    public class LocalXML : DBProvider
    {
        public string ConnectionString { get; set; } = @"basedirectory=E:\git\functionalprogramming\functionalprogrammingcsharp";
        public ProjectsEnumerable Projects { get; set; } = new ProjectsEnumerable();
        public PiecesEnumerable Pieces { get; set; } = new PiecesEnumerable();

        public IEnumerableExtended Projects2 { get; set; } = new IEnumerableExtended();

        private XDocument projectDoc = null;
        private XDocument pieceDoc = null;

        public DBProvider OpenDb()
        {
            projectDoc = null;
            pieceDoc = null;
            string baseDir = ConnectionString.Split(";").FirstOrDefault(configParam => configParam.ToLower().StartsWith("basedirectory"));
            if (baseDir != null)
            {
                baseDir = baseDir.Substring(baseDir.IndexOf('=') + 1);
                projectDoc = XDocument.Load(baseDir + @"\SampleDB\Projects.xml");
                if (projectDoc != null)
                {
                    Projects = new ProjectsEnumerable(projectDoc.Descendants());
                    Projects2 = new IEnumerableExtended(projectDoc.Descendants());
                }
                pieceDoc = XDocument.Load(baseDir + @"\SampleDB\Pieces.xml");
                if (pieceDoc != null)
                {
                    Pieces = new PiecesEnumerable(pieceDoc.Descendants());
                }
            }
            return this;
        }
        public DBProvider CloseDb()
        {
            projectDoc = null;
            pieceDoc = null;
            return this;
        }

    }
}
