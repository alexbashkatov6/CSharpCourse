using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private T[] items;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public ArrayStack()
        {
            const int defaultCapacity = 4;
            items = new T[defaultCapacity];
        }

        public ArrayStack(int capacity)
        {
            items = new T[capacity];
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return items[Count-1];
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            items[--Count] = default(T);
        }

        public void Push(T item)
        {
            if (items.Length == Count)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(items, 0, largerArray, 0, Count);

                items = largerArray;
            }
            items[Count++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count-1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class LinkedStack<T> : IEnumerable<T>
    {
        private SinglyLinkedList<T> items = new SinglyLinkedList<T>();
        public int Count => items.Count;
        public bool IsEmpty => Count == 0;

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return items.Head.Value;
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            items.RemoveFirst();
        }

        public void Push(T item)
        {
            items.AddFirst(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current_node = items.Head;
            for (int i = 0; i < Count; i++)
            {
                yield return current_node.Value;
                current_node = current_node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
