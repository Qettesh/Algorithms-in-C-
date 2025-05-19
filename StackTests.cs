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
    public class StackTests
    {
        private Stack_Array<int> _stack;
        [SetUp]
        public void Init()
        {
            _stack = new Stack_Array<int>();
        }

        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            Assert.That(_stack.IsEmpty, Is.True);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            _stack.Push(1);

            Assert.That(1, Is.EqualTo(_stack.Count));
            Assert.That(_stack.IsEmpty, Is.False);
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            _stack.Push(1);
            _stack.Push(2);

            Assert.That(2, Is.EqualTo(_stack.Peek()));
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            _stack.Push(1);
            _stack.Push(2);

            _stack.Pop();

            Assert.That(1, Is.EqualTo(_stack.Peek()));
        }
    }
}
