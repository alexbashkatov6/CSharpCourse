using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F_Algorithms;
using NUnit.Framework;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class SinglyLinkedListTests
    {
        private SinglyLinkedList<int> list;
        [SetUp]
        public void Init()
        {
            list = new F_Algorithms.SinglyLinkedList<int>();
        }

        [Test]
        public void CreateEmptyList_CorrectState()
        {
            Assert.IsTrue(list.IsEmpty);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [Test]
        public void AddFirst_and_AddLast_OneItem_CorrectState()
        {
            list.AddFirst(1);

            CheckStateWithSingleNode(list);

            list.RemoveFirst();
            list.AddLast(1);

            CheckStateWithSingleNode(list);
        }

        [Test]
        public void AddRemoveToGetToStateWithSingleNode_CorrectState()
        {
            list.AddFirst(1);
            list.AddFirst(2);
            list.RemoveFirst();

            CheckStateWithSingleNode(list);

            list.AddFirst(2);
            list.RemoveLast();

            CheckStateWithSingleNode(list);
        }

        private void CheckStateWithSingleNode(SinglyLinkedList<int> list)
        {
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.IsEmpty);
            Assert.AreSame(list.Head, list.Tail);
        }

        [Test]
        public void AddFirst_and_AddLast_AddItemsInCorrectOrder()
        {
            list.AddFirst(1);
            list.AddFirst(2);

            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);

            list.AddLast(3);
            Assert.AreEqual(3, list.Tail.Value);
        }

        [Test]
        public void RemoveFirst_EmptyList_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Test]
        public void RemoveLast_EmptyList_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Test]
        public void RemoveFirst_RemoveLast_CorrectState()
        {
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddFirst(4);
            list.RemoveFirst();
            list.RemoveLast();

            Assert.AreEqual(3, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);
        }
    }
}
