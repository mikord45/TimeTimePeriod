using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeAndTimePeriod;
using System;

namespace TimeAndTimePeriodTests
{

    [TestClass]
    public class TimeTests
    {
        private Time time;
        private Time time2;
        private Time time3;
        private Time time4;
        private Time time5;

        [TestInitialize()]
        public void Startup()
        {
            time = new Time("23:33:22");
            time2 = new Time(20, 03, 32);
            time3 = new Time(20, 39);
            time4 = new Time(10);
            time5 = new Time("10:00:00");
        }

        [TestMethod]
        public void ValidConstructorsTests()
        {
            Assert.AreEqual(time.Hours, 23);
            Assert.AreEqual(time.Minutes, 33);
            Assert.AreEqual(time.Seconds, 22);

            Assert.AreEqual(time2.Hours, 20);
            Assert.AreEqual(time2.Minutes, 3);
            Assert.AreEqual(time2.Seconds, 32);

            Assert.AreEqual(time3.Hours, 20);
            Assert.AreEqual(time3.Minutes, 39);
            Assert.AreEqual(time3.Seconds, 0);

            Assert.AreEqual(time4.Hours, 10);
            Assert.AreEqual(time4.Minutes, 0);
            Assert.AreEqual(time4.Seconds, 0);

            Assert.AreEqual(time5.Hours, 10);
            Assert.AreEqual(time5.Minutes, 0);
            Assert.AreEqual(time5.Seconds, 0);
        }

        [TestMethod]
        public void InvalidConstructorsTests()
        {
            Assert.ThrowsException<Exception>(() => new Time(44, 22, 11));
            Assert.ThrowsException<Exception>(() => new Time(23, 63, 11));
            Assert.ThrowsException<Exception>(() => new Time(11, 22, 61));
            Assert.ThrowsException<Exception>(() => new Time(11, 62));
            Assert.ThrowsException<Exception>(() => new Time(30));
            Assert.ThrowsException<Exception>(() => new Time("44:33:22"));
            Assert.ThrowsException<Exception>(() => new Time("12:80:22"));
            Assert.ThrowsException<Exception>(() => new Time("12:33:70"));
        }

        [TestMethod]
        public void ToStringTests()
        {
            Assert.AreEqual(time.ToString(),"23:33:22");
            Assert.AreEqual(time2.ToString(), "20:03:32");
            Assert.AreEqual(time3.ToString(), "20:39:00");
            Assert.AreEqual(time4.ToString(), "10:00:00");
            Assert.AreEqual(time5.ToString(), "10:00:00");
        }

        [TestMethod]
        public void EqualsTests()
        {
            Assert.IsFalse(time.Equals((object)time2));
            Assert.IsFalse(time3.Equals(time4));
            Assert.IsTrue(time4.Equals(time5));
            Assert.IsTrue(time4.Equals((object)time5));
        }

        [TestMethod]
        public void CompareOperatorsTests()
        {
            Assert.IsFalse(time2 > time3);
            Assert.IsTrue(time2 < time3);
            Assert.IsFalse(time2 == time3);
            Assert.IsTrue(time2 != time3);
            Assert.IsTrue(time4 >= time5);
            Assert.IsTrue(time5 <= time4);
            Assert.IsTrue(time4 == time5);
            Assert.IsFalse(time5 != time4);
        }

        [TestMethod]
        public void SumOperatorTests()
        {
            Time timeHelper = time2 + time3;
            Assert.AreEqual(timeHelper.Hours, 16);
            Assert.AreEqual(timeHelper.Minutes, 42);
            Assert.AreEqual(timeHelper.Seconds, 32);
        }

        [TestMethod]
        public void DiffOperatorTests()
        {
            Time timeHelper = time2 - time3;
            Assert.AreEqual(timeHelper.Hours, 0);
            Assert.AreEqual(timeHelper.Minutes, 0);
            Assert.AreEqual(timeHelper.Seconds, 0);
            Time timeHelper2 = time3 - time2;
            Assert.AreEqual(timeHelper2.Hours, 0);
            Assert.AreEqual(timeHelper2.Minutes, 35);
            Assert.AreEqual(timeHelper2.Seconds, 28);
        }

        [TestMethod]
        public void SumFunctionsTests()
        {
            TimePeriod timePeriod = new TimePeriod(15, 44, 33);
            Time time6 = time.Plus(timePeriod);
            Console.WriteLine(time6);
            Assert.AreEqual(time6.Hours, 15);
            Assert.AreEqual(time6.Minutes, 17);
            Assert.AreEqual(time6.Seconds, 55);
            Time time7 = Time.Plus(time2, timePeriod);
            Assert.AreEqual(time7.Hours, 11);
            Assert.AreEqual(time7.Minutes, 48);
            Assert.AreEqual(time7.Seconds, 05);
        }

    }
}
