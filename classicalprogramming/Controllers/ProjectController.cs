using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace classicalprogramming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private DBProvider.DBProvider Provider() {
            return new DBProvider.LocalXML().OpenDb();
        }

        [HttpGet]
        public IEnumerable<Interfaces.Project> Get()
        {
            List<Interfaces.Project> projectsCasted = new List<Interfaces.Project>();
            foreach (DBProvider.DBTables.Project projectFound in Provider().Projects)
            {
                projectsCasted.Add(new Interfaces.Project {
                    Id = projectFound.Id,
                    Name = projectFound.Name,
                    Data = projectFound.Data
                });
            }
            return projectsCasted;
        }

        [HttpGet("{Id}")]
        public Interfaces.Project Get(int Id)
        {
            DBProvider.DBTables.Project projectFound = Provider().Projects.Find(
                    (project) =>
                    {
                        return Id == project.Id;
                    });
            Interfaces.Project projectCasted = new Interfaces.Project
            {
                Id = projectFound.Id,
                Name = projectFound.Name,
                Data = projectFound.Data
            };
            return projectCasted;
        }
    
    }
}
