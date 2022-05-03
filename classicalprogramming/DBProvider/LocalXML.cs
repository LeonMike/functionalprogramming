using classicalprogramming.DBProvider.DBTables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace classicalprogramming.DBProvider
{
    public class LocalXML : DBProvider
    {
        public string ConnectionString { get; set; } = @"basedirectory=E:\git\functionalprogramming\functionalprogrammingcsharp";
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Piece> Pieces { get; set; } = new List<Piece>();

        private XDocument projectDoc = null;
        private XDocument pieceDoc = null;

        /*T ConvertFromXmlTo<T>(List<XElement> XmlOrigin, ref List<T> TResult)
        {
            int newId;
            foreach (XElement projectEl in XmlOrigin)
            {
                newId = (projectEl.Element("Id") != null) ? int.Parse(projectEl.Element("Id").Value) : -1;
                TResult.Add(new T
                {
                    Id = newId,
                    Name = projectEl.Element("Name")?.Value,
                    Data = projectEl.Element("Data")?.Value
                });
            }
        }*/

        public DBProvider OpenDb()
        {
            projectDoc = null;
            pieceDoc = null;
            string baseDir = "";
            int newId = -1;
            foreach (string param in ConnectionString.Split(";")) {
                if (param.ToLower().StartsWith("basedirectory"))
                    baseDir = param.Substring(param.IndexOf("=") + 1);
            }
            if (baseDir != "") {
                projectDoc = XDocument.Load(baseDir + @"\SampleDB\Projects.xml");
                if (projectDoc != null)
                {
                    foreach (XElement projectEl in projectDoc.Root.Elements("Project").ToList()) {
                        newId = (projectEl.Element("Id") != null) ? int.Parse(projectEl.Element("Id").Value) : -1;
                        Projects.Add(new DBTables.Project
                        {
                            Id = newId,
                            Name = projectEl.Element("Name")?.Value,
                            Data = projectEl.Element("Data")?.Value
                        });
                    }
                }
                pieceDoc = XDocument.Load(baseDir + @"\SampleDB\Pieces.xml");
                if (pieceDoc != null)
                {
                    foreach (XElement pieceEl in pieceDoc.Root.Elements("Piece").ToList())
                    {
                        newId = (pieceEl.Element("Id") != null) ? int.Parse(pieceEl.Element("Id").Value) : -1;
                        Pieces.Add(new DBTables.Piece
                        {
                            Id = newId,
                            Name = pieceEl.Element("Name").Value,
                            Data = pieceEl.Element("Data").Value
                        });
                    }
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
