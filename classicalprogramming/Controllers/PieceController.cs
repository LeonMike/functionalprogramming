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
    public class PieceController : ControllerBase
    {
        private DBProvider.DBProvider Provider()
        {
            return new DBProvider.LocalXML().OpenDb();
        }

        [HttpGet]
        public IEnumerable<Interfaces.Piece> Get()
        {
            List<Interfaces.Piece> piecesCasted = new List<Interfaces.Piece>();
            foreach (DBProvider.DBTables.Piece pieceFound in Provider().Pieces)
            {
                piecesCasted.Add(new Interfaces.Piece
                {
                    Id = pieceFound.Id,
                    Name = pieceFound.Name,
                    Data = pieceFound.Data
                });
            }
            return piecesCasted;
        }

        [HttpGet("{Id}")]
        public Interfaces.Piece Get(int Id)
        {
            DBProvider.DBTables.Piece pieceFound = Provider().Pieces.Find(
                    (piece) =>
                    {
                        return Id == piece.Id;
                    });
            Interfaces.Piece pieceCasted = new Interfaces.Piece
            {
                Id = pieceFound.Id,
                Name = pieceFound.Name,
                Data = pieceFound.Data
            };
            return pieceCasted;
        }

    }
}
