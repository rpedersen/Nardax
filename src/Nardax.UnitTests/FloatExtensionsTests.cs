using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class FloatExtensionsTests
    {
        private float _inMin;
        private float _inMax;
        private float _outMin;
        private float _outMax;

        [TestInitialize]
        public void TestInitialize()
        {
            _inMin = 1;
            _inMax = 100;
            _outMin = 10;
            _outMax = 500;
        }

        [TestMethod]
        public void Map_NoConstrafloat_MfloatoMin()
        {
            float value = 1;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Map_NoConstrafloat_MaxToMax()
        {
            float value = 100;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(500, result);
        }

        [TestMethod]
        public void Map_NoConstrafloat_MiddleToMiddle()
        {
            float expectedResult = 252.525253f;
            float value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Map_WithConstrafloat_MiddleToMiddle()
        {
            float expectedResult = 252.525253f;
            float value = 50;
            var result = value.Map(_inMin, _inMax, _outMin, _outMax, true);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Constrain_LowValue_ReturnsMinimum()
        {
            float value = 0;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMin, result);
        }

        [TestMethod]
        public void Constrain_HighValue_ReturnsMaximum()
        {
            float value = 1000;
            var result = value.Constrain(_inMin, _inMax);

            Assert.AreEqual(_inMax, result);
        }
    }
}