using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExercises
{
    public class ChainHashSet<TKey, TValue>
    {
        private SequentialSearchST<TKey, TValue>[] _chains;

        private const int DefaultCapaticy = 4;
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public ChainHashSet():this(Prime.MinPrime)
        {
                
        }

        public ChainHashSet(int capacity)
        {
            Capacity = capacity;
            _chains = new SequentialSearchST<TKey, TValue>[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                _chains[i] = new SequentialSearchST<TKey, TValue>();
            }                
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity;
        }

        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(paramName: "Key is not allowed to be null...");

            int index = Hash(key);
            if (_chains[index].tryGet(key, out TValue val))
            {
                return val;
            }

            throw new ArgumentException(message: "Key was not found...");
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(paramName: "Key is not allowed to be null...");

            int index = Hash(key);
            return _chains[index].tryGet(key, out TValue _);
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(paramName: "Key is not allowed to be null...");

            int index = Hash(key);
            if (_chains[index].Contains(key))
            {
                Count--;
                _chains[index].Remove(key);

                if (Capacity > DefaultCapaticy && Count <= 2 * Capacity)
                    Resize(Prime.ReducePrime(Capacity));
                return true;
            }
            return false;
        }

        //Add method incurs the recalculation of hashes.
        public void Add(TKey key, TValue val)
        {
            if (key == null)
                throw new ArgumentNullException(paramName: "Key is not allowed to be null...");

            if (val== null)
            {
                Remove(key);
                return;
            }

            if (Count >= 10 * Capacity)
                Resize(Prime.ExpandPrime(Capacity));

            int i = Hash(key);

            if (!_chains[i].Contains(key))
                Count++;

            _chains[i].Add(key, val);
        }

        private void Resize(int chains)
        {
            var temp = new ChainHashSet<TKey, TValue>(chains);

            for (int i = 0; i < Capacity; i++)
            {
                foreach (TKey key in _chains[i].Keys())
                {
                    if (_chains[i].tryGet(key, out TValue val))
                    {
                        temp.Add(key, val);
                    }
                }
            }

            Capacity = temp.Capacity;
            Count = temp.Count;
            _chains = temp._chains;
        }

        //keys function returns all keys as IEnumerable
        public IEnumerable<TKey> Keys()
        {
            //Seems to run better than BLC.NET version...
            var queue = new LinkedQueue<TKey>();
            for (int i = 0; i < Capacity; i++)
            {
                foreach (TKey key in _chains[i].Keys())
                {
                    queue.Enqueue(key);
                }
            }

            return queue;
        }
    }
}
