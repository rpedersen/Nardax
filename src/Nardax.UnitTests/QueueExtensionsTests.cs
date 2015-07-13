using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.UnitTests
{
    [TestClass]
    public class QueueExtensionsTests
    {

        private Queue<int> _numbers;

        [TestInitialize]
        public void TestInitialize()
        {
            _numbers = new Queue<int>();
        }

        [TestMethod]
        public void EnqueueRange_ValidSet_DequeuesInOrder()
        {
            _numbers.Enqueue(1);
            _numbers.Enqueue(2);
            _numbers.Enqueue(3);

            var range = new[] { 4, 5, 6 };

            _numbers.EnqueueRange(range);

            Assert.AreEqual(1, _numbers.Dequeue());
            Assert.AreEqual(2, _numbers.Dequeue());
            Assert.AreEqual(3, _numbers.Dequeue());
            Assert.AreEqual(4, _numbers.Dequeue());
            Assert.AreEqual(5, _numbers.Dequeue());
            Assert.AreEqual(6, _numbers.Dequeue());
        }
    }
}