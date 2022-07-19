using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class StackTests
    {
        private LinkedStack<int> stack;  // ArrayStack
        [SetUp]
        public void Init()
        {
            stack = new F_Algorithms.LinkedStack<int>();  // ArrayStack
        }

        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            Assert.Throws<InvalidOperationException> (() =>
            {
                stack.Pop();
            });
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadElement()
        {
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            stack.Push(1);
            stack.Push(2);

            stack.Pop();
            
            Assert.AreEqual(1, stack.Peek());
        }
    }
}
