using System;
using System.Collections.Generic;
using Application.Services.Sprint;
using Domain;
using Infrastructure.SqlServer.Repositories.Sprint;
using NUnit.Framework;

namespace UnitTest.Tests.SprintTest
{
    public class SprintTest
    {
        [Test]
        public void GetSprintDuration_noInput_SingleTimeSpan_AssertTrue()
        {
            Sprint sprint = new Sprint
            {
                Id = 1,
                IdProject = 1,
                SprintNumber = 1,
                Description = "",
                Deadline = new DateTime(1998,04,30),
                StartDate = new DateTime(1998,04,20)
            };

            Assert.AreEqual(new TimeSpan(10,0,0,0), sprint.GetSprintDuration());
        }

        [Test]
        public void GetSprintDuration_noInput_SingleTimeSpan_AssertFalse()
        {
            Sprint sprint = new Sprint
            {
                Id = 1,
                IdProject = 1,
                SprintNumber = 1,
                Description = "",
                Deadline = new DateTime(1998,04,20),
                StartDate = new DateTime(1998,04,30)
            };

            Assert.AreNotEqual(new TimeSpan(10,0,0,0), sprint.GetSprintDuration());
        }

        [Test]
        public void FindMaxSprintNumber_sprintList_MaxSprintNumber()
        {
            // Arrange
            var sprintService = new SprintService(new SprintRepository());
            
            const int numberOfSprints = 5;
            const int expectedResult = 42;
            var sprints = new List<Sprint>();
            var numbers = new [] {1, 5, 42, 20, 3};
            
            for (int i = 0; i < numberOfSprints; i++)
            {
                sprints.Add(new Sprint
                {
                    Deadline = new DateTime(1998,04,20),
                    Description = "Description for unit test",
                    IdProject = 0,
                    SprintNumber = numbers[i],
                    StartDate = new DateTime(1998,04,10)
                });
            }
            
            // Act
            var actualResult = sprintService.FindMaxSprintNumber(sprints);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, 0);
        }
        
        [Test]
        public void FindMaxSprintNumber_emptySprintList_0()
        {
            // Arrange
            var sprintService = new SprintService(new SprintRepository());
            
            const int expectedResult = 0;
            var sprints = new List<Sprint>();
            
            // Act
            var actualResult = sprintService.FindMaxSprintNumber(sprints);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, 0);
        }
    }
}