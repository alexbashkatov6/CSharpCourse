using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 4;
        private T[] heap;

        public int Count { get; private set; }
        public bool IsFull => Count == heap.Length;
        public bool IsEmpty => Count == 0;

        public MaxHeap() : this(DefaultCapacity)
        {
        }

        public MaxHeap(int capacity)
        {
            heap = new T[capacity];
        }

        public void Insert(T value)
        {
            if (IsFull)
            {
                var newHeap = new T[heap.Length * 2];
                Array.Copy(heap, newHeap, heap.Length);
                heap = newHeap;
            }
            heap[Count] = value;
            Swim(Count);
            Count++;
        }

        private void Swim(int indexOfSwimingItem)
        {
            T newValue = heap[indexOfSwimingItem];
            while (indexOfSwimingItem > 0 && IsParentLess(indexOfSwimingItem))
            {
                heap[indexOfSwimingItem] = GetParent(indexOfSwimingItem);
                indexOfSwimingItem = ParentIndex(indexOfSwimingItem);
            }
            heap[indexOfSwimingItem] = newValue;

            bool IsParentLess(int index)
            {
                return newValue.CompareTo(GetParent(index)) > 0;
            }
        }

        private T GetParent(int index)
        {
            return heap[ParentIndex(index)];
        }

        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public IEnumerable<T> Values()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return heap[i];
            }
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Is empty");
            return heap[0];
        }

        public T Remove()
        {
            return Remove(0);
        }

        private T Remove(int index)
        {
            if (IsEmpty)
                throw new InvalidOperationException("Is empty");
            T removedValue = heap[index];
            heap[index] = heap[Count - 1];
            if (index == 0 || heap[index].CompareTo(GetParent(index)) < 0)
                Sink(index, Count - 1);
            else
                Swim(index);

            Count--;
            return removedValue;
        }

        private void Sink(int indexOfSinkingItem, int lastHeapIndex)
        {
            //int lastHeapIndex = Count - 1;
            while (indexOfSinkingItem <= lastHeapIndex)
            {
                int leftChildIndex = LeftChildIndex(indexOfSinkingItem);
                int rightChildIndex = RightChildIndex(indexOfSinkingItem);

                if (leftChildIndex > lastHeapIndex)
                    break;

                int childIndexToSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex);

                if (SinkingIsLessThen(childIndexToSwap))
                {
                    Exchange(indexOfSinkingItem, childIndexToSwap);
                }
                else
                    break;
                indexOfSinkingItem = childIndexToSwap;
            }

            int GetChildIndexToSwap(int leftChildIndex, int rightChildIndex)
            {
                int childToSwap;
                if (rightChildIndex > lastHeapIndex)
                {
                    childToSwap = leftChildIndex;
                }
                else
                {
                    int compareTo = heap[leftChildIndex].CompareTo(heap[rightChildIndex]);
                    childToSwap = compareTo > 0 ? leftChildIndex : rightChildIndex;
                }
                return childToSwap;
            }

            bool SinkingIsLessThen(int childToSwap)
            {
                return heap[indexOfSinkingItem].CompareTo(heap[childToSwap]) < 0;
            }
        }

        private void Exchange(int left, int right)
        {
            T tmp = heap[left];
            heap[left] = heap[right];
            heap[right] = tmp;
        }

        private int LeftChildIndex(int index)
        {
            return 2*index + 1;
        }

        private int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        public void Sort()
        {
            int lastHeapIndex = Count - 1;
            for(int i = 0; i < lastHeapIndex; i++)
            {
                Exchange(0, lastHeapIndex - i);
                Sink(0, lastHeapIndex - i - 1);
            }
        }
    }
}
