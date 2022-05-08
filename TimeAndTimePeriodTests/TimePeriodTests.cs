using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeAndTimePeriod;
using System;


namespace TimeAndTimePeriodTests
{
    [TestClass]
    public class TimePeriodTests
    {

        private TimePeriod timePeriod1;
        private TimePeriod timePeriod2;
        private TimePeriod timePeriod3;
        private TimePeriod timePeriod4;
        private TimePeriod timePeriod5;
        private TimePeriod timePeriod6;
        private TimePeriod timePeriod6_2;
        private TimePeriod timePeriod7;
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

            timePeriod1 = new TimePeriod(45, 1, 1);
            timePeriod2 = new TimePeriod(23, 44);
            timePeriod3 = new TimePeriod(3423525342);
            timePeriod4 = new TimePeriod(time2, time);
            timePeriod5 = new TimePeriod(time, time2);
            timePeriod6 = new TimePeriod(time4, time5);
            timePeriod6_2 = new TimePeriod(time4, time5);
            timePeriod7 = new TimePeriod("543:44:22");
        }

        [TestMethod]
        public void ValidConstructorsTests()
        {
            Assert.AreEqual(timePeriod1.Seconds, 162061);
            Assert.AreEqual(timePeriod2.Seconds, 85440);
            Assert.AreEqual(timePeriod3.Seconds, 3423525342);
            Assert.AreEqual(timePeriod4.Seconds, 12590);
            Assert.AreEqual(timePeriod5.Seconds, 73810);
            Assert.AreEqual(timePeriod6.Seconds, 0);
            Assert.AreEqual(timePeriod6_2.Seconds, 0);
            Assert.AreEqual(timePeriod7.Seconds, 1957462);
        }

        [TestMethod]
        public void InvalidConstructorsTests()
        {
            Assert.ThrowsException<Exception>(() => new TimePeriod(44, 62, 11));
            Assert.ThrowsException<Exception>(() => new TimePeriod(44, 22, 71));
            Assert.ThrowsException<Exception>(() => new TimePeriod(44, 62));
            Assert.ThrowsException<Exception>(() => new TimePeriod(-342));
            Assert.ThrowsException<Exception>(() => new TimePeriod("45:66:33"));
            Assert.ThrowsException<Exception>(() => new TimePeriod("45:33:66"));
        }

        [TestMethod]
        public void ToStringTests()
        {
            Assert.AreEqual(timePeriod1.ToString(), "45:01:01");
            Assert.AreEqual(timePeriod2.ToString(), "23:44:00");
            Assert.AreEqual(timePeriod3.ToString(), "950979:15:42");
            Assert.AreEqual(timePeriod4.ToString(), "03:29:50");
            Assert.AreEqual(timePeriod5.ToString(), "20:30:10");
            Assert.AreEqual(timePeriod6.ToString(), "00:00:00");
            Assert.AreEqual(timePeriod6_2.ToString(), "00:00:00");
            Assert.AreEqual(timePeriod7.ToString(), "543:44:22");
        }

        [TestMethod]
        public void EqualsTests()
        {
            Assert.IsFalse(timePeriod1.Equals((object)timePeriod2));
            Assert.IsTrue(timePeriod6.Equals((object)timePeriod6_2));
            Assert.IsFalse(timePeriod2.Equals(timePeriod3));
            Assert.IsTrue(timePeriod6.Equals(timePeriod6_2));
        }

        [TestMethod]
        public void CompareOperatorsTests()
        {
            Assert.IsTrue(timePeriod1 > timePeriod2);
            Assert.IsFalse(timePeriod1 > timePeriod7);
            Assert.IsTrue(timePeriod1 < timePeriod7);
            Assert.IsFalse(timePeriod3 < timePeriod7);
            Assert.IsTrue(timePeriod6 >= timePeriod6_2);
            Assert.IsFalse(timePeriod6 >= timePeriod7);
            Assert.IsTrue(timePeriod6_2 <= timePeriod6);
            Assert.IsFalse(timePeriod7 <= timePeriod1);
            Assert.IsTrue(timePeriod6 == timePeriod6_2);
            Assert.IsFalse(timePeriod1 == timePeriod2);
            Assert.IsTrue(timePeriod1 != timePeriod2);
            Assert.IsFalse(timePeriod6 != timePeriod6_2);
        }
        [TestMethod]
        public void SumOperatorTests()
        {
            TimePeriod timePeriod8 = timePeriod1 + timePeriod2;
            Assert.AreEqual(timePeriod8.Seconds, 247501);
        }

        [TestMethod]
        public void SumFunctionsTests()
        {
            TimePeriod timePeriod9 = timePeriod1.Plus(timePeriod4);
            Assert.AreEqual(timePeriod9.Seconds, 174651);
            TimePeriod timePeriod10 = TimePeriod.Plus(timePeriod2, timePeriod3);
            Assert.AreEqual(timePeriod10.Seconds, 3423610782);
            TimePeriod timePeriod11 = TimePeriod.Plus(timePeriod2, timePeriod3, timePeriod4);
            Assert.AreEqual(timePeriod11.Seconds, 3423623372);
        }

    }
}
