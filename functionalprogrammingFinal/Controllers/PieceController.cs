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
    public class PieceController : ControllerBase
    {
        private DBProvider.DBProvider Provider() => new DBProvider.LocalXML().OpenDb();

        [HttpGet]
        public IEnumerable<Interfaces.Piece> Get() => Provider().Pieces.
            Piece().Select(project => new Interfaces.Piece(project.Descendants()));

        [HttpGet("{Id}")]
        public IEnumerable<Interfaces.Piece> Get(int Id) => Provider().Pieces.
            Piece(Id).Select(project => new Interfaces.Piece(project.Descendants()));
    
    }
}
