using Microsoft.VisualStudio.TestTools.UnitTesting;
using classicalprogramming.Controllers;
using System.Collections.Generic;
using classicalprogrammingtests.Comparers;
using classicalprogramming.Interfaces;

namespace classicalprogrammingtests
{
    [TestClass]
    public class ProjectControllerTests
    {
        ProjectController Controller;

        private bool ComparerFunction(Project expectedPiece, Project retrievedPiece)
        {
            return expectedPiece.Id == retrievedPiece.Id &&
            expectedPiece.Name == retrievedPiece.Name &&
            expectedPiece.Data == retrievedPiece.Data;
        }

        [TestInitialize]
        public void Setup()
        {
            Controller = new ProjectController();
        }

        [TestMethod]
        public void TestGet()
        {
            int index;
            int totalExpectedProjects = 0;
            List<Project> RetrievedProjects = new List<Project>(Controller.Get());
            List<Project> ExpectedProjects = new List<Project>
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
            ProjectComparer comparer = new ProjectComparer();
            totalExpectedProjects = ExpectedProjects.Count;
            if (RetrievedProjects.Count == totalExpectedProjects)
            {
                for (index = 0; index < totalExpectedProjects; index++) {
                    Assert.IsTrue(ComparerFunction(ExpectedProjects[index], RetrievedProjects[index]), "Element at index " + index.ToString() + " did not match");
                }
            } else
            {
                throw new System.Exception("Expected number of elements was " + ExpectedProjects.Count.ToString() + ", but " + RetrievedProjects.Count.ToString() + " were retrieved");
            }
        }

        [TestMethod]
        public void TestGetById()
        {
            Project expectedProject = new Project
            {
                Id = 1,
                Name = "mid project",
                Data = "some dat"
            };
            Project retrievedProject = Controller.Get(1);
            ProjectComparer comparer = new ProjectComparer();
            Assert.IsTrue(ComparerFunction(expectedProject, retrievedProject), "Retrieved element did not match the expected one");
        }
    }
}
