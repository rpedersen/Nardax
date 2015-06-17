using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class ShortExtensionsTests
    {
        private short _inMin;
        private short _inMax;
        private short _outMin;
        private short _outMax;

        [TestInitialize]
        public void TestInitialize()
        {
            _inMin = 1;
            _inMax = 100;
            _outMin = 10;
            _outMax = 500;
        }

        [TestMethod]
        public void Map_NoConstraint_MinToMin()
        {
            short value = 1;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Map_NoConstraint_MaxToMax()
        {
            short value = 100;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(500, result);
        }

        [TestMethod]
        public void Map_NoConstraint_MiddleToMiddle()
        {
            short value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(252, result);
        }

        [TestMethod]
        public void Map_WithConstraint_MiddleToMiddle()
        {
            short value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax, true);

            Assert.AreEqual(252, result);
        }

        [TestMethod]
        public void Constrain_LowValue_ReturnsMinimum()
        {
            short value = 0;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMin, result);
        }

        [TestMethod]
        public void Constrain_HighValue_ReturnsMaximum()
        {
            short value = 1000;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMax, result);
        }
    }
}
