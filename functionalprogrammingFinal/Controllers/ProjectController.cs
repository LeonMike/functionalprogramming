using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace functionalprogrammingFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private DBProvider.DBProvider Provider() => new DBProvider.LocalXML().OpenDb();

        [HttpGet]
        public IEnumerable<Interfaces.Project> Get() => Provider().Projects.
            Project().Select(project => new Interfaces.Project(project.Descendants()));

        [HttpGet("{Id}")]
        public IEnumerable<Interfaces.Project> Get(int Id) => Provider().Projects.
            Project(Id).Select(project => new Interfaces.Project(project.Descendants()));
    
    }
}
