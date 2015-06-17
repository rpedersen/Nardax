using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class DoubleExtensionsTests
    {
        private double _inMin;
        private double _inMax;
        private double _outMin;
        private double _outMax;

        [TestInitialize]
        public void TestInitialize()
        {
            _inMin = 1;
            _inMax = 100;
            _outMin = 10;
            _outMax = 500;
        }

        [TestMethod]
        public void Map_NoConstradouble_MdoubleoMin()
        {
            double value = 1;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Map_NoConstradouble_MaxToMax()
        {
            double value = 100;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(500, result);
        }

        [TestMethod]
        public void Map_NoConstradouble_MiddleToMiddle()
        {
            double expectedResult = 252.52525252525251d;
            double value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Map_WithConstradouble_MiddleToMiddle()
        {
            double expectedResult = 252.52525252525251d;
            double value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax, true);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Constrain_LowValue_ReturnsMinimum()
        {
            double value = 0;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMin, result);
        }

        [TestMethod]
        public void Constrain_HighValue_ReturnsMaximum()
        {
            double value = 1000;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMax, result);
        }
    }
}