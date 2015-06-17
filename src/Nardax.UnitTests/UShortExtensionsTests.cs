using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class UShortExtensionsTests
    {
        private ushort _inMin;
        private ushort _inMax;
        private ushort _outMin;
        private ushort _outMax;

        [TestInitialize]
        public void TestInitialize()
        {
            _inMin = 1;
            _inMax = 100;
            _outMin = 10;
            _outMax = 500;
        }

        [TestMethod]
        public void Map_NoConstraushort_MushortoMin()
        {
            ushort value = 1;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Map_NoConstraushort_MaxToMax()
        {
            ushort value = 100;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(500, result);
        }

        [TestMethod]
        public void Map_NoConstraushort_MiddleToMiddle()
        {
            ushort value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(252, result);
        }

        [TestMethod]
        public void Map_WithConstraushort_MiddleToMiddle()
        {
            ushort value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax, true);

            Assert.AreEqual(252, result);
        }

        [TestMethod]
        public void Constrain_LowValue_ReturnsMinimum()
        {
            ushort value = 0;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMin, result);
        }

        [TestMethod]
        public void Constrain_HighValue_ReturnsMaximum()
        {
            ushort value = 1000;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMax, result);
        }
    }
}