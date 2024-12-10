using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExercises
{
    public class LinkedQueue<T> : IEnumerable<T>
    {
        public int Count => _list.Count;
        public bool IsEmpty => _list.Count == 0;
        private readonly SingleLinkedList<T> _list = new SingleLinkedList<T>();

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public void DeQueue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            _list.removeFirst();
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _list.First.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
