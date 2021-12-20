using System;
using Domain;
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
    }
}