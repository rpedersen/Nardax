using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class DecimalExtensionsTests
    {
        private decimal _inMin;
        private decimal _inMax;
        private decimal _outMin;
        private decimal _outMax;

        [TestInitialize]
        public void TestInitialize()
        {
            _inMin = 1;
            _inMax = 100;
            _outMin = 10;
            _outMax = 500;
        }

        [TestMethod]
        public void Map_NoConstradecimal_MdecimaloMin()
        {
            decimal value = 1;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Map_NoConstradecimal_MaxToMax()
        {
            decimal value = 100;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(500, result);
        }

        [TestMethod]
        public void Map_NoConstradecimal_MiddleToMiddle()
        {
            decimal expectedResult = 252.52525252525252525252525253m;
            decimal value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Map_WithConstradecimal_MiddleToMiddle()
        {
            decimal expectedResult = 252.52525252525252525252525253m;
            decimal value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax, true);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Constrain_LowValue_ReturnsMinimum()
        {
            decimal value = 0;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMin, result);
        }

        [TestMethod]
        public void Constrain_HighValue_ReturnsMaximum()
        {
            decimal value = 1000;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMax, result);
        }
    }
}