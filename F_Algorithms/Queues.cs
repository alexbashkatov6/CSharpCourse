using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] queue;
        private int head;
        private int tail;
        public int Count => tail - head;
        public bool IsEmpty => Count == 0;
        public int Capacity => queue.Length;

        public ArrayQueue()
        {
            const int defaultCapacity = 4;
            queue = new T[defaultCapacity];
        }

        public ArrayQueue(int capacity)
        {
            queue = new T[capacity];
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return queue[head];
        }

        public void Enqueue(T item)
        {
            if (queue.Length == tail)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(queue, head, largerArray, 0, Count);
                queue = largerArray;
                head = 0;
                tail = Count;
            }
            queue[tail++] = item;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            queue[head++] = default(T);
            if (IsEmpty)
                head = tail = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = head; i < tail; i++)
            {
                yield return queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] queue;
        private int head;
        private int tail;
        public int Count => head <= tail ? tail - head : queue.Length - (head - tail);
        public bool IsEmpty => Count == 0;
        public int Capacity => queue.Length;

        public CircularQueue()
        {
            const int defaultCapacity = 4;
            queue = new T[defaultCapacity];
        }

        public CircularQueue(int capacity)
        {
            queue = new T[capacity];
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return queue[head];
        }

        public void Enqueue(T item)
        {
            if (Count == queue.Length - 1)
            {
                int countPriorResize = Count;
                T[] newArray = new T[2 * queue.Length];

                Array.Copy(queue, head, newArray, 0, queue.Length - head);
                Array.Copy(queue, 0, newArray, queue.Length - head, tail);

                queue = newArray;

                head = 0; 
                tail = countPriorResize;
            }
            queue[tail] = item;
            if (tail < queue.Length - 1)
            {
                tail++;
            }
            else
            {
                tail = 0;
            }
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            queue[head++] = default(T);
            if (IsEmpty)
                head = tail = 0;
            else if (head == queue.Length)
                head = 0;

        }

        public IEnumerator<T> GetEnumerator()
        {
            if (head <= tail)
            {
                for (int i = head; i < tail; i++)
                {
                    yield return queue[i];
                }
            }
            else
            {
                for (int i = head; i < queue.Length; i++)
                {
                    yield return queue[i];
                }
                for (int i = 0; i < tail; i++)
                {
                    yield return queue[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class LinkedQueue<T> : IEnumerable<T>
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

        public void Enqueue(T item)
        {
            items.AddLast(item);
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            items.RemoveFirst();
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
