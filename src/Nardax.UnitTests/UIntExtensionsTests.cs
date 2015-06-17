using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class UIntExtensionsTests
    {
        private uint _inMin;
        private uint _inMax;
        private uint _outMin;
        private uint _outMax;

        [TestInitialize]
        public void TestInitialize()
        {
            _inMin = 1;
            _inMax = 100;
            _outMin = 10;
            _outMax = 500;
        }

        [TestMethod]
        public void Map_NoConstraint_MuintoMin()
        {
            uint expectedResults = 10;
            uint value = 1;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResults, result);
        }

        [TestMethod]
        public void Map_NoConstraint_MaxToMax()
        {
            uint expectedResults = 500;
            uint value = 100;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResults, result);
        }

        [TestMethod]
        public void Map_NoConstrauint_MiddleToMiddle()
        {
            uint expectedResults = 252;
            uint value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResults, result);
        }

        [TestMethod]
        public void Map_WithConstraint_MiddleToMiddle()
        {
            uint expectedResult = 252;
            uint value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax, true);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Constrain_LowValue_ReturnsMinimum()
        {
            uint value = 0;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMin, result);
        }

        [TestMethod]
        public void Constrain_HighValue_ReturnsMaximum()
        {
            uint value = 1000;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMax, result);
        }
    }
}