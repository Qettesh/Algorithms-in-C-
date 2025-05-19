using Algorithm_Suite_Lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Suite_Lib.Tests
{
    [TestFixture]
    public class LinkedListQueueTests
    {
        private LinkedListQueue<int> _queue;
        [SetUp]
        public void Init()
        {
            _queue = new LinkedListQueue<int>();
        }

        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            Assert.That(_queue.IsEmpty, Is.True);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            _queue.Enqueue(1);

            Assert.That(1, Is.EqualTo(_queue.Count));
            Assert.That(_queue.IsEmpty, Is.False);
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);

            _queue.Dequeue();

            Assert.That(2, Is.EqualTo(_queue.Peek()));
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);

            Assert.That(1, Is.EqualTo(_queue.Peek()));
        }
    }
}
