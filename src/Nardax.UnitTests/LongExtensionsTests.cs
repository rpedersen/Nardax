using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class LongExtensionsTests
    {
        private long _inMin;
        private long _inMax;
        private long _outMin;
        private long _outMax;

        [TestInitialize]
        public void TestInitialize()
        {
            _inMin = 1;
            _inMax = 100;
            _outMin = 10;
            _outMax = 500;
        }

        [TestMethod]
        public void Map_NoConstralong_MlongoMin()
        {
            long value = 1;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Map_NoConstralong_MaxToMax()
        {
            long value = 100;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(500, result);
        }

        [TestMethod]
        public void Map_NoConstralong_MiddleToMiddle()
        {
            long value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(252, result);
        }

        [TestMethod]
        public void Map_WithConstralong_MiddleToMiddle()
        {
            long value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax, true);

            Assert.AreEqual(252, result);
        }

        [TestMethod]
        public void Constrain_LowValue_ReturnsMinimum()
        {
            long value = 0;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMin, result);
        }

        [TestMethod]
        public void Constrain_HighValue_ReturnsMaximum()
        {
            long value = 1000;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMax, result);
        }
    }
}