using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgorithmsExercises
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        public bool IsEmpty => Count == 0;
        public int Capacity => _queue.Length;
        private T[] _queue;
        private int _head;
        private int _tail;

        //If the queue is unwrapped so the head is less or equal than tail, then we can calculate the count as tail minus head.
        //If the queue is unwrapped, then we can count the number of elements by subtracting head from tail.
        //If it is wrapped, we subtract head from tail and add queue length tail minus head plus q dot length.
        public int Count => _head <= _tail ? _tail - _head : _tail - _head + _queue.Length;

        public CircularQueue()
        {
            const int defaultCapacity = 8;
                
            _queue = new T[defaultCapacity];
        }

        public CircularQueue(int capacity)
        {
            _queue = new T[Capacity];
        }

        public void Enqueue(T item)
        {
            //using here the length minus one boundary since it simplifies  wrapping and unwrapping the queue.
            //Now, before creating the array of a larger size, we need to save off the current size for assigning this number to tail.
            //After copying all the elements over to a new array.
            //Let's import the array type copy from queue to not two, but the source index is going to be head to new array and the destination index from zero.
            //From queue starting from zero to a new array and we copy to a new array starting at the following destination index that we're going
            //to calculate as this queue dot length minus.

            if (Count == _queue.Length - 1)                                     
            {
                

                int CountPriorResize = Count;
                T[] newArray = new T[2*_queue.Length];

                
                Array.Copy(_queue, _head, newArray, 0, _queue.Length - _head);                
                Array.Copy(_queue, 0, newArray, _queue.Length - _head, _tail);

                _queue = newArray;

                //And after unwrapping the Q, 
                _head = 0;

                //we reset the head index and assign the previous number of elements to tail.
                _tail = CountPriorResize;
            }

            //So if there is enough space for enqueuing an element, we should add it at the tail counter.
            _queue[_tail] = item;

            //And if the queue should not be wrapped yet, then we need to increment tail.
            if (_tail < _queue.Length - 1)
            {
                _tail++;
            }

            //Otherwise, if we wrap the queue we need to set zero to tail.
            else
            {
                _tail = 0;
            }
        }

        public void DeQueue()
        {
            if (IsEmpty)
            
                throw new InvalidOperationException();
                
            _queue[_head++] = default(T);                       //Assign a default value here to the item at index head and increment head

            //If after removing the element, the queue is empty, we set zero to head and tail.
            if (IsEmpty)
                _head = _tail = 0;

            //If the queue is not empty but head equals length of queue, we need to write here the else if statement. If head counter is equal to q dot length we need to set zero to the head
            else if (_head == _queue.Length)
                _head = 0;

        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _queue[_head];
        }


        public IEnumerator<T> GetEnumerator()
        {
            //Check if queue is unwrapped if head is less than or equal to tail, it means that the queue is unwrapped.
            if (_head <= _tail)
            {
                //Iterate from head to tail amd increment I and return otherwise yield return items at I.
                for (int i = _head; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            }
            else
            {
                for(int i = _head; i < _queue.Length; i++)
                {
                    //If the queue is wrapped, we need to at first we need to iterate from head to the end of the array.
                    yield return _queue[i];
                }
                //Run another loop iterating from zero to tail because our queue is wrapped from zero to tail

                for(int i = 0; i < _tail; ++i)
                {
                    yield return _queue[i];
                }


            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
