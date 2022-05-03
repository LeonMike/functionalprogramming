using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace classicalprogramming.DBProvider.DBTables
{
    [Serializable()]
    public class Piece
    {
        [XmlElement]
        public int Id { get; set; }
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public string Data { get; set; }
    }
}
