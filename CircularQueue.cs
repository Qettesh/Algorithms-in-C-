using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] _circularQueue;
        private int _head;
        private int _tail;
        public int Count => _head <= _tail? _tail - _head : _tail - _head + _circularQueue.Length;
        public bool IsEmpty => Count == 0;

        public int Capacity => _circularQueue.Length;

        public CircularQueue()
        {
            const int defaultCapacity = 8;
            _circularQueue = new T[defaultCapacity];
        }

        public CircularQueue(int capacity)
        {
            _circularQueue = new T[capacity];
        }           

        public void Enqueue(T item)
        {
            //Unwraps the queue when it doubles in size
            if (Count == _circularQueue.Length - 1)
            {
                int countPriorResize = Count;
                T[] newArray = new T[2 *_circularQueue.Length];

                Array.Copy(_circularQueue, _head, newArray, 0, _circularQueue.Length - _head);
                Array.Copy(_circularQueue, 0, newArray, _circularQueue.Length - _head, _tail);

                _circularQueue = newArray;

                _head = 0;
                _tail = countPriorResize;
            }

            _circularQueue[_tail] = item;
            if (_tail < _circularQueue.Length - 1)
            {
                _tail++;
            }
            else
            {
                _tail = 0;
            }
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            _circularQueue[_head++] = default(T);

            if (IsEmpty)
                _head = _tail = 0;
            else if(_head == _circularQueue.Length)
            {
                _head = 0;
            }
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _circularQueue[_head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            if(_head <= _tail)
            {
                for (int i = _head; i < _tail; i++)
                {
                    yield return _circularQueue[i];
                }
                    
            }
            else
            {
                for (int i = _head; i < _tail; i++)
                {
                    yield return _circularQueue[i];
                }

                for (int i = 0; i < _tail; i++)
                {
                    yield return _circularQueue[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
