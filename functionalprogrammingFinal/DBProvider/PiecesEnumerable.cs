using functionalprogrammingFinal.Interfaces.IEnumerable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace functionalprogrammingFinal.DBProvider
{
    public class PiecesEnumerable: IEnumerableExtended
    {
        public PiecesEnumerable() : base() { }

        public PiecesEnumerable(IEnumerable<XElement> BaseMap) : base(BaseMap) { }

        public PiecesEnumerable Piece() => new PiecesEnumerable(
            Property("Piece"));

        public PiecesEnumerable Piece(int Id) => new PiecesEnumerable(
            Property("Piece", Id.ToString()));
    }
}
