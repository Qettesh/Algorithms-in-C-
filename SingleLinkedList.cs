using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class SingleLinkedList<T>
    {
        public FuzzyNode<T> Head { get; private set; }
        public FuzzyNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new FuzzyNode<T>(value));
        }

        private void AddFirst(FuzzyNode<T> node)
        {
            //save the current head
            FuzzyNode<T> tmp = Head;

            Head = node;

            //shift the former head
            Head.Next = tmp;


            //increment counter
            Count++;

            if(Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new FuzzyNode<T>(value));
        }

        public void AddLast(FuzzyNode<T> node)
        {
            if (IsEmpty)
           
                Head = node;               
            else              
                Tail.Next = node;                          //Adds new node
              
            Tail = node;

            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Head = Head.Next;
            if (Count == 1)
                Tail = null;

            Count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            if (Count == 1)
            {
                Head = Tail = null;
            }

            else
            {
                //find the penultimate node
                var current = Head;
                while(current.Next != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                Tail = current;
            }
            Count--;
        }

        public bool IsEmpty => Count == 0;
    }
}
