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
            for(int i =0; i < Capacity; i++)
            {
                foreach (TKey key in this.chains[i].Keys())
                {
                    if(this.chains[i].TryGet(key, out TValue val))
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
                foreach(var key in this.chains[i].Keys())
                {
                    queue.Enqueue(key);
                }
            }
            return queue;
        }
    }
}
