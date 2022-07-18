using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class ChainHashSet<TKey, TValue>
    {
        private SequantialSearchSt<TKey, TValue>[] chains;
        private const int DefaultCapacity = 4;
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public ChainHashSet(int capacity)
        {
            Capacity = capacity;
            this.chains = new SequantialSearchSt<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                chains[i] = new SequantialSearchSt<TKey, TValue>();
            }
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity;  // mask for hash > 0
        }

        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            int index = Hash(key);
            if (chains[index].TryGet(key, out TValue val))
            {
                return val;
            }

            throw new ArgumentException("Key was not found");
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            int index = Hash(key);
            return chains[index].TryGet(key, out TValue _);
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            int index = Hash(key);
            if (chains[index].Contains(key))
            {
                Count--;
                chains[index].Remove(key);

                return true;
            }

            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            if (val == null)
            {
                Remove(key);
                return;
            }

            if (Count >= 10 * Capacity)
                Resize(2 * Capacity);

            int i = Hash(key);
            if (!chains[i].Contains(key))
                Count++;

            chains[i].Add(key, val);
        }

        private void Resize(int chains)
        {
            var temp = new ChainHashSet<TKey, TValue>(chains);
            for (int i = 0; i < Capacity; i++)
            {
                foreach (TKey key in this.chains[i].Keys())
                {
                    if (this.chains[i].TryGet(key, out TValue val))
                    {
                        temp.Add(key, val);
                    }
                }
            }

            Capacity = temp.Capacity;
            Count = temp.Count;
            this.chains = temp.chains;
        }

        public IEnumerable<TKey> Keys()
        {
            var queue = new LinkedQueue<TKey>();
            for (int i = 0; i < Capacity; i++)
            {
                foreach (var key in this.chains[i].Keys())
                {
                    queue.Enqueue(key);
                }
            }
            return queue;
        }
    }
    public class LinearProbingHashSet<TKey, TValue>
    {
        private const int DefaultCapacity = 4;

        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private TKey[] keys;
        private TValue[] values;

        public LinearProbingHashSet():this(DefaultCapacity)
        {

        }

        public LinearProbingHashSet(int capacity)
        {
            Capacity = capacity;
            keys = new TKey[Capacity];
            values = new TValue[Capacity];
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity;  // mask for hash > 0
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            for(int i = Hash(key); keys[i] != null; i = (i + 1) % Capacity)
            {
                if (keys[i].Equals(key))
                    return true;
            };
            return false;
        }

        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            for (int i = Hash(key); keys[i] != null; i = (i + 1) % Capacity)
            {
                if (keys[i].Equals(key))
                    return values[i];
            };
            throw new ArgumentException("Not found");
        }

        public bool TryGet(TKey key, out int index)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            for (int i = Hash(key); keys[i] != null; i = (i + 1) % Capacity)
            {
                if (keys[i].Equals(key))
                {
                    index = i;
                    return true;
                }
            };
            index = -1;
            return false;
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            if (!TryGet(key, out int index))
                return;

            keys[index] = default(TKey);
            values[index] = default(TValue);

            index = (index + 1) % Capacity;

            while(keys[index] != null)
            {
                TKey keyToRehash = keys[index];
                TValue valToRehash = values[index];

                keys[index] = default(TKey);
                values[index] = default(TValue);

                Count--;

                Add(keyToRehash, valToRehash);

                index = (index + 1) % Capacity;
            }

            Count--;

            if (Count > 0 && Count <= Capacity / 8)
                Resize(Capacity / 2);
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("Null key is not allowed");

            if(value == null)
            {
                Remove(key);
                return;
            }

            if (Count >= Capacity / 2)
                Resize(Capacity * 2);

            int i;
            for (i = Hash(key); keys[i] != null; i = (i + 1) % Capacity)
            {
                if (keys[i].Equals(key))
                {
                    values[i] = value;
                    return;
                }
            };
            keys[i] = key;
            values[i] = value;

            Count++;
        }

        private void Resize(int capacity)
        {
            var temp = new LinearProbingHashSet<TKey, TValue>(capacity);

            for(int i = 0; i < Capacity; i++)
            {
                if (keys[i] != null)
                {
                    temp.Add(keys[i], values[i]);
                }
            }

            keys = temp.keys;
            values = temp.values;
            Capacity = capacity;
        }

        public IEnumerable<TKey> Keys()
        {
            var q = new Queue<TKey>();
            for(int i = 0; i < Capacity; i++)
            {
                if (keys[i] != null)
                    q.Enqueue(keys[i]);
            }
            return q;
        }
    }
}
