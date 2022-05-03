using Microsoft.VisualStudio.TestTools.UnitTesting;
using classicalprogramming.Controllers;
using System.Collections.Generic;
using classicalprogrammingtests.Comparers;

namespace classicalprogrammingtests
{
    [TestClass]
    public class PieceControllerTests
    {
        PieceController Controller;

        [TestInitialize]
        public void Setup()
        {
            Controller = new PieceController();
        }

        [TestMethod]
        public void TestGet()
        {
            int index;
            int totalExpectedPieces = 0;
            List<classicalprogramming.Interfaces.Piece> RetrievedPieces = new List<classicalprogramming.Interfaces.Piece>(Controller.Get());
            List<classicalprogramming.Interfaces.Piece> ExpectedPieces = new List<classicalprogramming.Interfaces.Piece>
            {
                new classicalprogramming.Interfaces.Piece {
                    Id = 0,
                    Name = "pieza inicial",
                    Data = "Empty data :o"
                },
                new classicalprogramming.Interfaces.Piece
                {
                    Id = 1,
                    Name = "mid piece",
                    Data = "some dat xD"
                },
                new classicalprogramming.Interfaces.Piece
                {
                    Id = 2,
                    Name = "final pis xD",
                    Data = "datos full :p"
                }
            };
            PieceComparer comparer = new PieceComparer();
            totalExpectedPieces = ExpectedPieces.Count;
            if (RetrievedPieces.Count == totalExpectedPieces)
            {
                for (index = 0; index < totalExpectedPieces; index++) {
                    Assert.IsTrue(comparer.Equals(ExpectedPieces[index], RetrievedPieces[index]), "Element at index " + index.ToString() + " did not match");
                }
            } else
            {
                throw new System.Exception("Expected number of elements was " + ExpectedPieces.Count.ToString() + ", but " + RetrievedPieces.Count.ToString() + " were retrieved");
            }
        }

        [TestMethod]
        public void TestGetById()
        {
            classicalprogramming.Interfaces.Piece expectedPiece = new classicalprogramming.Interfaces.Piece
            {
                Id = 1,
                Name = "mid piece",
                Data = "some dat xD"
            };
            classicalprogramming.Interfaces.Piece retrievedPiece = Controller.Get(1);
            PieceComparer comparer = new PieceComparer();
            Assert.IsTrue(comparer.Equals(expectedPiece, retrievedPiece), "Retrieved element did not match the expected one");
        }
    }
}
