using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class Stack_Array<T> : IEnumerable<T>
    {
        public T[] _items;
        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }

        public Stack_Array()
        {
            const int defaultCapacity = 8;
            _items = new T[defaultCapacity];
        }

        public Stack_Array(int capacity)
        {
            _items = new T[capacity];
        }         

        public T Peek()
        {
            return _items[Count - 1];
        }

        public void Pop() 
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            _items[--Count] = default(T);               //A reset value at count minus one, then decrement the counter,
                                                        //returning the default value of T.
            
        }

        public void Push(T item)
        {
            if (_items.Length == Count)
            {
                T[] largerArray = new T[Count * 4];      //if the internal array is full, create a new one which is
                                                         //4 times larger than the old array
                Array.Copy(_items, largerArray, Count);  // copy over all of the older elements from items to the larger array

                _items = largerArray;                    //reassign the items from the older array to the larger array.
            }

            _items[Count++] = item;                      //Assign item to the slot at index count and only after the counter will be incremented.
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
