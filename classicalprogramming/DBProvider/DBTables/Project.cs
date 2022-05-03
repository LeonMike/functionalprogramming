using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace classicalprogramming.DBProvider.DBTables
{
    [Serializable()]
    [XmlRoot(ElementName = "Project")]
    public class Project
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Data")]
        public string Data { get; set; }
    }
}
