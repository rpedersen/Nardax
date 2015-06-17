using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class ULongExtensionsTests
    {
        private ulong _inMin;
        private ulong _inMax;
        private ulong _outMin;
        private ulong _outMax;

        [TestInitialize]
        public void TestInitialize()
        {
            _inMin = 1;
            _inMax = 100;
            _outMin = 10;
            _outMax = 500;
        }

        [TestMethod]
        public void Map_NoConstraint_MulongoMin()
        {
            ulong expectedResult = 10;
            ulong value = 1;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Map_NoConstraint_MaxToMax()
        {
            ulong expectedResult = 500;
            ulong value = 100;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Map_NoConstraint_MiddleToMiddle()
        {
            ulong expectedResult = 252;
            ulong value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Map_WithConstraint_MiddleToMiddle()
        {
            ulong expectedResult = 252;
            ulong value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax, true);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Constrain_LowValue_ReturnsMinimum()
        {
            ulong value = 0;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMin, result);
        }

        [TestMethod]
        public void Constrain_HighValue_ReturnsMaximum()
        {
            ulong value = 1000;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMax, result);
        }
    }
}