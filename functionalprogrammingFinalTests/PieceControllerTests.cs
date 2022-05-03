using functionalprogrammingFinal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using functionalprogrammingFinal.Interfaces;

namespace functionalprogrammingFinalTests
{
    [TestClass]
    public class PieceControllerTests
    {
        PieceController Controller;

        private bool ComparerFunction(Piece expectedPiece, Piece retrievedPiece) =>
            expectedPiece.Id == retrievedPiece.Id &&
            expectedPiece.Name == retrievedPiece.Name &&
            expectedPiece.Data == retrievedPiece.Data;

        private bool AllPiecesMatch(IEnumerable<Piece> ExpectedPieces, IEnumerable<Piece> RetrievedPieces) =>
            ExpectedPieces.Zip(RetrievedPieces, ComparerFunction)
            .All(comparisonResult => comparisonResult == true);

        [TestInitialize]
        public void Setup()
        {
            Controller = new PieceController();
        }

        [TestMethod]
        public void TestGet()
        {
            IEnumerable<Piece> ExpectedPieces = new List<Piece>
            {
                new Piece {
                    Id = 0,
                    Name = "pieza inicial",
                    Data = "Empty data :o"
                },
                new Piece
                {
                    Id = 1,
                    Name = "mid piece",
                    Data = "some dat xD"
                },
                new Piece
                {
                    Id = 2,
                    Name = "final pis xD",
                    Data = "datos full :p"
                }
            };
            Assert.IsTrue(AllPiecesMatch(ExpectedPieces, Controller.Get()));
        }

        [TestMethod]
        public void TestGetById()
        {
            IEnumerable<Piece> ExpectedPieces = new List<Piece>
            {
                new Piece
                {
                    Id = 1,
                    Name = "mid piece",
                    Data = "some dat xD"
                }
            };
            Assert.IsTrue(AllPiecesMatch(ExpectedPieces, Controller.Get(1)));
        }
    }
}
