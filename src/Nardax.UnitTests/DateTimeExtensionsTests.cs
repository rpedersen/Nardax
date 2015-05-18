using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.Tests
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        private DateTime _date;

        [TestInitialize]
        public void TestInitialize()
        {
            _date = new DateTime(1974, 7, 3);
        }

        [TestMethod]
        public void Floor_DateTimeWithSeconds_ReturnsHoursRoundedDownToHours()
        {
            var expectedDateTime = new DateTime(1974, 7, 3, 11, 0, 0);

            _date = new DateTime(1974, 7, 3, 11, 10, 42);
            var timespan = new TimeSpan(0, 1, 0, 0);

            var actualDateTime = _date.Floor(timespan);

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void Round_DateTimeWithMinutes_ReturnsnDateTimeRoundedToNearestHours()
        {
            var expectedDateTime = new DateTime(1974, 7, 3, 11, 0, 0);

            _date = new DateTime(1974, 7, 3, 10, 35, 42);
            var timespan = new TimeSpan(0, 1, 0, 0);

            var actualDateTime = _date.Round(timespan);

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void Round_DateTimeWithMinutes_ReturnsnDateTimeRoundedUpToNearestHours()
        {
            var expectedDateTime = new DateTime(1974, 7, 3, 11, 0, 0);

            _date = new DateTime(1974, 7, 3, 10, 20, 42);
            var timespan = new TimeSpan(0, 1, 0, 0);

            var actualDateTime = _date.Ceiling(timespan);

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void SecondsFrom_DateWithSeconds_ReturnsDistanceAsSeconds()
        {
            var expectedNumberOfSeconds = 10;
            var dateWithSeconds = _date.AddSeconds(expectedNumberOfSeconds * -1);

            var actualNumberOfSeconds = _date.SecondsFrom(dateWithSeconds);

            Assert.AreEqual(expectedNumberOfSeconds, actualNumberOfSeconds);
        }

        [TestMethod]
        public void SecondsFromUnixEpoch_DateFourtyTwoSecondsPastUnixEpoch_ReturnsFourtyTwo()
        {
            var expectedSeconds = 42;

            var unixEpocPlusFourtyTwoSeconds = new DateTime(1970, 1, 1, 0, 0, expectedSeconds);

            var actualseconds = unixEpocPlusFourtyTwoSeconds.SecondsFromUnixEpoch();

            Assert.AreEqual(expectedSeconds, actualseconds);
        }

        [TestMethod]
        public void MillisecondsOfDay_DateTimeWithFourtyTwoHundredMilliseconds_ReturnsFourtyTwoHundredMilliseconds()
        {
            var expectedMilliseconds = 4200;
            var datetimeWithFourtyTwoHundredMilliseconds = new DateTime(1974, 7, 3).AddMilliseconds(expectedMilliseconds);

            var actualMilliseconds = datetimeWithFourtyTwoHundredMilliseconds.MillisecondOfDay();

            Assert.AreEqual(expectedMilliseconds, actualMilliseconds);
        }

        [TestMethod]
        public void Midnight_DateTimeWithFourtyTwoMinutes_ReturnsMidnight()
        {
            var expectedDateTime = new DateTime(1970, 7, 3);

            var dateTimeWithFourtyTwoMinutes = expectedDateTime.AddMinutes(42);

            var actualDateTime = dateTimeWithFourtyTwoMinutes.Midnight();

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void Noon_DateAtMidnight_ReturnsSameDateAtNoon()
        {
            var expectedDateTime = new DateTime(1974, 7, 3, 12, 0, 0);

            var actualDateTime = _date.Noon();

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void SetTime_Hour_SetsHour()
        {
            var expectedDateTime = new DateTime(1974, 7, 3, 8, 0, 0);

            var actualDateTime = _date.SetTime(8);

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void SetTime_HourMinute_SetsHourMinute()
        {
            var expectedDateTime = new DateTime(1974, 7, 3, 8, 42, 0);

            var actualDateTime = _date.SetTime(8, 42);

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void SetTime_HourMinuteSecond_SetsHourMinuteSecound()
        {
            var expectedDateTime = new DateTime(1974, 7, 3, 8, 42, 24);

            var actualDateTime = _date.SetTime(8, 42, 24);

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void SetTime_HourMinuteSecondMillisecond_SetsHourMinuteSecoundMillisecond()
        {
            var expectedDateTime = new DateTime(1974, 7, 3, 8, 42, 24, 37);

            var actualDateTime = _date.SetTime(8, 42, 24, 37);

            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void Min_DateLessThanValue_ReturnsDate()
        {
            var result = _date.Min(DateTime.MaxValue);

            Assert.AreEqual(_date, result);
        }

        [TestMethod]
        public void Min_DateEqualsValue_ReturnsDate()
        {
            var date2 = new DateTime(1974, 7, 3);

            var result = _date.Min(date2);

            Assert.AreEqual(_date, result);
        }

        [TestMethod]
        public void Min_DateGreaterThanValue_ReturnsValue()
        {
            var value = new DateTime(1974, 4, 7);

            var result = _date.Min(value);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Max_DateLessThanValue_ReturnsValue()
        {
            var value = new DateTime(1994, 9, 6);

            var result = _date.Max(value);

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void Max_DateEqualsValue_ReturnsDate()
        {
            var date2 = new DateTime(1974, 7, 3);

            var result = _date.Max(date2);

            Assert.AreEqual(_date, result);
        }

        [TestMethod]
        public void Max_DateGreaterThanValue_ReturnsDate()
        {
            var result = _date.Max(DateTime.MinValue);

            Assert.AreEqual(_date, result);
        }
    }
}
