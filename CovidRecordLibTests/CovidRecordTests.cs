using Microsoft.VisualStudio.TestTools.UnitTesting;
using CovidRecordLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidRecordLib.Tests
{
    [TestClass()]
    public class CovidRecordTests
    {
        [TestMethod()]
        public void IdTest()
        {
            CovidRecord covidRecord = new CovidRecord(5, "Rungsted", 4, 2, 1);
            Assert.AreEqual(5, covidRecord.Id);
        }

        [TestMethod()]
        public void CityTest()
        {
            CovidRecord covidRecord = new CovidRecord(5, "Rungsted", 4, 2, 1);
            Assert.AreEqual("Rungsted", covidRecord.City);
            Assert.ThrowsException<ArgumentException>(() => covidRecord.City = "R");
        }

        [TestMethod()]
        public void HouseholdTest()
        {
            CovidRecord covidRecord = new CovidRecord(5, "Rungsted", 4, 2, 1);
            Assert.AreEqual(4, covidRecord.Household);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => covidRecord.Household = 0);
        }

        [TestMethodAttribute()]
        public void TestedTest()
        {
            CovidRecord covidRecord = new CovidRecord(5, "Rungsted", 4, 2, 1);
            Assert.AreEqual(2, covidRecord.Tested);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => covidRecord.Tested = -1);
        }

        [TestMethodAttribute()]
        public void SickTest()
        {
            CovidRecord covidRecord = new CovidRecord(5, "Rungsted", 4, 2, 1);
            Assert.AreEqual(1, covidRecord.Sick);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => covidRecord.Sick = -1);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            
        }
    }
}