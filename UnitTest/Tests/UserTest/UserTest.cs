using System;
using System.Collections.Generic;
using Domain;
using NUnit.Framework;

namespace UnitTest.Tests.UserTest
{
    public class UserTest
    {
        [Test]
        public void GetDaysOfWork_ListTimeSpan_SingleNumber_AssertTrue()
        {
            List<TimeSpan> timeSpans = new List<TimeSpan>();

            TimeSpan tmp1 = new TimeSpan(1, 1, 1, 1);
            TimeSpan tmp2 = new TimeSpan(1, 1, 1, 1);
            TimeSpan tmp3 = new TimeSpan(2, 23, 0, 0);
            
            timeSpans.Add(tmp1);
            timeSpans.Add(tmp2);
            timeSpans.Add(tmp3);
            
            Assert.AreEqual(5, new User().GetDaysOfWork(timeSpans));
        }

        [Test]
        public void GetDaysOfWork_ListTimeSpan_SingleNumber_AssertFalse()
        {
            List<TimeSpan> timeSpans = new List<TimeSpan>();

            TimeSpan tmp1 = new TimeSpan(1, 1, 1, 1);
            TimeSpan tmp2 = new TimeSpan(1, 1, 1, 1);
            TimeSpan tmp3 = new TimeSpan(2, 21, 59, 0);
            
            timeSpans.Add(tmp1);
            timeSpans.Add(tmp2);
            timeSpans.Add(tmp3);
            
            Assert.AreNotEqual(4, new User().GetDaysOfWork(timeSpans));
        }
    }
}