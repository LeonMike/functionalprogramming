using functionalprogrammingFinal.Interfaces.IEnumerable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace functionalprogrammingFinal.DBProvider
{
    public class ProjectsEnumerable : IEnumerableExtended
    {
        public ProjectsEnumerable() : base() { }

        public ProjectsEnumerable(IEnumerable<XElement> BaseMap) : base(BaseMap) { }

        public ProjectsEnumerable Project() => new ProjectsEnumerable(
            Property("Project"));

        public ProjectsEnumerable Project(int Id) => new ProjectsEnumerable(
            Property("Project", Id.ToString()));


    }
}
