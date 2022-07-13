using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class SequantialSearchSt<TKey, TValue>
    {
        private class Node
        {
            public TKey Key { get; }
            public TValue Value { get; set; }
            public Node Next { get; set; }
            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        private Node first;
        private readonly EqualityComparer<TKey> comparer;
        public int Count { get; private set; }

        public SequantialSearchSt()
        {
            comparer = EqualityComparer<TKey>.Default;
        }

        public SequantialSearchSt(EqualityComparer<TKey> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException();
        }

        public bool TryGet(TKey key, out TValue val)
        {
            for (Node x = first; x != null; x = x.Next)
            {
                if (comparer.Equals(x.Key, key))
                {
                    val = x.Value;
                    return true;
                }
            }
            val = default(TValue);
            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            for (Node x = first; x != null; x = x.Next)
            {
                if (comparer.Equals(x.Key, key))
                {
                    x.Value = val;
                    return;
                }
            }

            first = new Node(key, val, first);

            Count++;
        }

        public bool Contains(TKey key)
        {
            for (Node x = first; x != null; x = x.Next)
            {
                if (comparer.Equals(x.Key, key))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            for (Node x = first; x != null; x = x.Next)
            {
                yield return x.Key;
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            Node prevNode = null;
            for (Node x = first; x != null; x = x.Next)
            {
                if (comparer.Equals(x.Key, key))
                {
                    if (x == first)
                        first = x.Next;
                    else
                        prevNode.Next = x.Next;
                    Count--;
                    return true;
                }
                prevNode = x;
            }
            return false;
        }
    }


    public class BinarySearchSt<TKey, TValue>
    {
        private TKey[] keys;
        private TValue[] values;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        private readonly IComparer<TKey> comparer;

        public int Capacity => keys.Length;
        private const int DefaultCapacity = 4;

        public BinarySearchSt(int capacity, IComparer<TKey> comparer)
        {
            keys = new TKey[Capacity];
            values = new TValue[Capacity];
            comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }
        public BinarySearchSt(int capacity) : this(capacity, Comparer<TKey>.Default) { }
        public BinarySearchSt() : this(DefaultCapacity) { }

        public int Rank(TKey key)
        {
            int low = 0;
            int high = Count - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int cmp = comparer.Compare(key, keys[mid]);
                if (cmp < 0)
                    high = mid - 1;
                else if (cmp > 0)
                    low = mid + 1;
                else
                    return mid;
            }
            return low;
        }

        public TValue GetValueOrDefault(TKey key)
        {
            if (IsEmpty)
                return default(TValue);

            int rank = Rank(key);
            if (rank < Count && comparer.Compare(keys[rank], key) == 0)
            {
                return values[rank];
            }
            return default(TValue);
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int rank = Rank(key);

            // insert of existing key
            if (rank < Count && comparer.Compare(keys[rank], key) == 0)
            {
                values[rank] = value;
                return;
            }

            if (Count == Capacity)
                Resize(Capacity * 2);

            for (int j = Count; j > rank; j--)
            {
                keys[j] = keys[j - 1];
                values[j] = values[j - 1];
            }
            keys[rank] = key;
            values[rank] = value;
            Count++;
        }

        private void Resize(int capacity)
        {
            TKey[] keysTmp = new TKey[capacity];
            TValue[] valuesTmp = new TValue[capacity];

            for (int i = 0; i < Count; i++)
            {
                keysTmp[i] = keys[i];
                valuesTmp[i] = values[i];
            }
            keys = keysTmp;
            values = valuesTmp;
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (IsEmpty)
                return;

            int r = Rank(key);

            // option when element not found
            if (r == Count || comparer.Compare(keys[r], key) != 0)
                return;

            for (int j = r; j < Count - 1; j++)
            {
                keys[j] = keys[j + 1];
                values[j] = values[j + 1];
            }

            Count--;
            keys[Count] = default(TKey);
            values[Count] = default(TValue);
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int r = Rank(key);

            if (r < Count || comparer.Compare(keys[r], key) == 0)
                return true;
            return false;

        }

        public IEnumerable<TKey> Keys()
        {
            foreach (var key in keys)
            {
                yield return key;
            }
        }

        public TKey Min()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty");
            return keys[0];
        }

        public TKey Max()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty");
            return keys[Count-1];
        }

        public void RemoveMin()
        {
            Remove(Min());
        }

        public void RemoveMax()
        {
            Remove(Max());
        }

        public TKey Select(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return keys[index];
        }

        public TKey Ceiling(TKey key)
        {
            if(key == null)
                throw new ArgumentNullException(nameof(key));

            int r = Rank(key);
            if (r == Count) 
                return default(TKey);
            else 
                return keys[r];
        }

        public TKey Floor(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int r = Rank(key);
            if (r == 0)
                return default(TKey);
            else if (r < Count && comparer.Compare(keys[r], key)==0)
                return keys[r];
            return keys[r-1];
        }

        public IEnumerable<TKey> Range(TKey left, TKey right)
        {
            var q = new LinkedQueue<TKey>();
            int low = Rank(left);
            int high = Rank(right);

            for(int i = low; i < high; i++)
            {
                q.Enqueue(keys[i]);
            }

            if (Contains(right))
                q.Enqueue(keys[Rank(right)]);

            return q;
        }
    }
}
