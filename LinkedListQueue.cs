using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class LinkedListQueue<T> : IEnumerable<T>
    {
        public int Count => _list.Count;
        public bool IsEmpty => Count == 0;

        public object? Capacity { get; set; }

        private readonly SingleLinkedList<T> _list = new SingleLinkedList<T>();

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public void Dequeue()
        {
            _list.RemoveFirst();
        }

        public T Peek()
        {
            return _list.Head.Value;
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
