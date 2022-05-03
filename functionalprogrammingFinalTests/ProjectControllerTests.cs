using functionalprogrammingFinal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using functionalprogrammingFinal.Interfaces;

namespace functionalprogrammingFinalTests
{
    [TestClass]
    public class ProjectControllerTests
    {
        ProjectController Controller;

        private bool ComparerFunction(Project expectedPiece, Project retrievedPiece) =>
            expectedPiece.Id == retrievedPiece.Id &&
            expectedPiece.Name == retrievedPiece.Name &&
            expectedPiece.Data == retrievedPiece.Data;

        private bool AllProjectsMatch(IEnumerable<Project> ExpectedProjects, IEnumerable<Project> RetrievedProjects) =>
            ExpectedProjects.Zip(RetrievedProjects, ComparerFunction)
            .All(comparisonResult => comparisonResult == true);

        [TestInitialize]
        public void Setup()
        {
            Controller = new ProjectController();
        }

        [TestMethod]
        public void TestGet()
        {
            IEnumerable<Project> ExpectedProjects = new List<Project>
            {
                new Project {
                    Id = -1,
                    Name = null,
                    Data = "Empty data"
                },
                new Project
                {
                    Id = 1,
                    Name = "mid project",
                    Data = "some dat"
                },
                new Project
                {
                    Id = 2,
                    Name = "final prj",
                    Data = "datos full"
                }
            };
            Assert.IsTrue(AllProjectsMatch(ExpectedProjects, Controller.Get()));
        }

        [TestMethod]
        public void TestGetById()
        {
            IEnumerable<Project> ExpectedProjects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "mid project",
                    Data = "some dat"
                }
            };
            Assert.IsTrue(AllProjectsMatch(ExpectedProjects, Controller.Get(1)));
        }
    }
}
