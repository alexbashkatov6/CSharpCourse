using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private LinkedQueue<int> queue;  // ArrayQueue CircularQueue LinkedQueue
        [SetUp]
        public void Init()
        {
            queue = new F_Algorithms.LinkedQueue<int>();  // ArrayQueue CircularQueue LinkedQueue
        }

        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Dequeue();
            });
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadElement()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Peek());
        }
    }
}
