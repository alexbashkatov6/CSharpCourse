using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    public class SinglyLinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }
        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
            //Head = new Node<T>(value);
        }

        public void AddFirst(Node<T> node)
        {
            // save off current head
            Node<T> tmp = Head;
            Head = node;
            Head.Next = tmp;

            if (++Count == 1)
                Tail = Head;
        }
        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
            //Head = new Node<T>(value);
        }

        public void AddLast(Node<T> node)
        {
            if (IsEmpty)
                Head = node;
            else
                Tail.Next = node;
            Tail = node;
            Count++;
        }

        public bool IsEmpty => Count == 0;

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            Head = Head.Next;
            if (Count-- == 1)
                Tail = null;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            if (Count-- == 1)
            {
                Head = Tail = null;
            }
            else
            {
                // find the penultimate node
                Node<T> tmp = Head;
                while (tmp.Next != Tail)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                Tail = tmp;
            }
        }

        public class DoublyLinkedNode<T>
        {
            public T Value { get; set; }
            public DoublyLinkedNode<T> Next { get; set; }
            public DoublyLinkedNode<T> Prev { get; set; }

            public DoublyLinkedNode(T value)
            {
                Value = value;
            }
        }

        public class DoublyLinkedList<T>
        {
            public DoublyLinkedNode<T> Head { get; private set; }
            public DoublyLinkedNode<T> Tail { get; private set; }
            public int Count { get; private set; }
            public bool IsEmpty => Count == 0;

            public void AddFirst(T value)
            {
                AddFirst(new DoublyLinkedNode<T>(value));
            }

            public void AddFirst(DoublyLinkedNode<T> node)
            {
                // save off current head
                DoublyLinkedNode<T> tmp = Head;
                Head = node;
                Head.Next = tmp;
                tmp.Prev = Head;

                if (++Count == 1)
                    Tail = Head;
            }
            public void AddLast(T value)
            {
                AddLast(new DoublyLinkedNode<T>(value));
            }

            public void AddLast(DoublyLinkedNode<T> node)
            {
                // save off current tail
                DoublyLinkedNode<T> tmp = Tail;
                Tail = node;
                Tail.Prev = tmp;
                tmp.Next = Tail;

                if (++Count == 1)
                    Head = Tail;
            }

            public void RemoveFirst()
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                Head = Head.Next;
                Head.Prev = null;
                if (Count-- == 1)
                    Tail = null;
            }

            public void RemoveLast()
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                Tail = Tail.Prev;
                Tail.Next = null;
                if (Count-- == 1)
                    Head = null;
            }
        }
    }
}
