using Algorithm_Suite_Lib;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Suite_Lib.Tests
{
    [TestFixture]
    public class QueueArrayTests
    {
        private QueueArray<int> _queue;
        [SetUp]
        public void Init()
        {
            _queue = new QueueArray<int>();
        }

        [Test]
        public void Capacity_EnqueueManyItems_DoubledCapacity()
        {
            
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            _queue.Enqueue(4);
            _queue.Enqueue(5);

            Assert.That(8, Is.EqualTo(_queue.Capacity));
        }

        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            
            Assert.That(_queue, Is.Empty);
        }

        [Test]
        public void Count_EnqueueOneItem_ReturnsOne()
        {
            
            _queue.Enqueue(1);
            Assert.That(_queue.IsEmpty, Is.False);
            Assert.That(1, Is.EqualTo(_queue.Count));
        }

        [Test]
        public void Peek_EnqueueTOneItemAndDequeue_ReturnsHeadElement()
        {
            
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            
            Assert.That(1, Is.EqualTo(_queue.Peek()));
        }

        [Test]
        public void Peek_EnqueueTwoItemsAndDequeue_ReturnsHeadElement()
        {
            
            _queue.Enqueue(1);
            _queue.Enqueue(2);

            _queue.Dequeue();

            Assert.That(2, Is.EqualTo(_queue.Peek()));
        }
    }
}
