using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class QueueArray<T> : IEnumerable<T>
    {
        private T[] _queueArray;
        private int _head;
        private int _tail;
        public int Count => _tail - _head;
        public bool IsEmpty => Count == 0;

        public int Capacity => _queueArray.Length;

        public QueueArray()                       //Constructor
        {
            const int defaultCapacity = 8;
            _queueArray = new T[defaultCapacity];
        }

        public QueueArray(int capacity)
        {
            _queueArray = new T[capacity];            //Constructor
        }

        

        public void Enqueue(T item)
        {
            if(_queueArray.Length == _tail)
            {
                T[] largerArray = new T[Count * 4];
                Array.Copy(_queueArray, largerArray, Count);
                _queueArray = largerArray;
            }
            _queueArray[_tail++] = item;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            _queueArray[_head++] = default(T);

            if (IsEmpty)
                _head = _tail = 0;
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException();
            return _queueArray[_head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = _head; i < _tail; i++)
            {
                yield return _queueArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
