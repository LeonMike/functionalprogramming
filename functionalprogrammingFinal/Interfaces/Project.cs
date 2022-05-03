using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace functionalprogrammingFinal.Interfaces
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public Project() { }

        public Project(IEnumerable<XElement> baseMap)
        {
            Interfaces.IEnumerable.IEnumerableExtended Extended = new Interfaces.IEnumerable.IEnumerableExtended(baseMap);
            Id = Extended.Property("Id").ToInt();
            Name = Extended.Property("Name").ToString();
            Data = Extended.Property("Data").ToString();
        }
    }
}
