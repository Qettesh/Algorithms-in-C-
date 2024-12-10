using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExercises
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 4;
        private T[] _heap;

        //define counter
        public int Count { get; private set; }

        private bool IsFull => Count == _heap.Length;
        private bool IsEmpty => Count == 0;

        public void Insert(T value)
        {
            if (IsFull)
            {
                var newHeap = new T[_heap.Length * 2];                
                Array.Copy(sourceArray:_heap, sourceIndex:0, destinationArray:newHeap, destinationIndex:0, _heap.Length);
                _heap = newHeap;
            }

            _heap[Count] = value;
            
            
            //heapify
            Climb(Count);

            Count++;
        }

        private void Climb(int indexOfClimbItem)
        {
            //shift items and place new value to the right.
            T newValue = _heap[indexOfClimbItem];
            while(indexOfClimbItem > 0 && IsParentLess(indexOfClimbItem))
            {
                //shift parents down by rewriting.
                _heap[indexOfClimbItem] = GetParent(indexOfClimbItem);
                indexOfClimbItem = ParentIndex(indexOfClimbItem);
            }

            _heap[indexOfClimbItem] = newValue;

            //internal funciton for IsParentless()
            bool IsParentLess(int climbItemIndex)
            {
                return newValue.CompareTo(GetParent(climbItemIndex)) > 0;
            }
        }

        public IEnumerable<T> Values()
        {
            for (int i = 0; i < Count; i++)
            {
                var item = _heap[i];
                yield return item;
            }
        }

        private T GetParent(int index)
        {
            return _heap[ParentIndex(index)];
        }

        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public T Peek()
        {
            //Guard clause
            if (IsEmpty)
                throw new InvalidOperationException(message:"Node can not be null...");
            return _heap[0];
        }

        public T Remove()
        {
            //overload that returns the index
            return Remove(0);
        }

        public T Remove(int index)
        {
            //Guard clause
            if (IsEmpty)
                throw new InvalidOperationException(message:"Node can not be null...");

            T removedValue = _heap[index];
            _heap[index] = _heap[Count -1];

            if(index==0 || _heap[index].CompareTo(GetParent(index)) < 0)
            {
                Sink(index, Count - 1);
            }

            else
            {
                Climb(index);
            }

            Count--;
            
            return removedValue;
        }

        //part of remove method...
        private void Sink(int indexOfSinkingItem, int lastheapIndex)
        {
            int lastHeapIndex = Count - 1;

            while(indexOfSinkingItem <= lastheapIndex)
            {
                //compare replacement item against child nodes left and right.
                int leftChildIndex = LeftChildIndex(indexOfSinkingItem);

                int rightChildIndex = RightChildIndex(indexOfSinkingItem);

                if (leftChildIndex > rightChildIndex)
                    break;

                int childIndexToSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex);

                if (SinkingIsLessThan(childIndexToSwap))
                {
                    Exchange(indexOfSinkingItem, childIndexToSwap);
                }

                else
                    break;

                indexOfSinkingItem = childIndexToSwap;

            }

            bool SinkingIsLessThan(int childToSwap)
            {
                return _heap[indexOfSinkingItem].CompareTo(_heap[childToSwap]) < 0;
            }

            int GetChildIndexToSwap(int leftChildIndex, int rightChildIndex)
            {
                int childToSwap;

                if(rightChildIndex > lastheapIndex)
                {
                    childToSwap = leftChildIndex;
                }

                else
                {
                    int compareTo = _heap[leftChildIndex].CompareTo(_heap[rightChildIndex]);

                    childToSwap = compareTo > 0 ? leftChildIndex : rightChildIndex;
                }

                return childToSwap;
            }
        }

        private int LeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int RightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        public MaxHeap() :this(DefaultCapacity) 
        { 

        }

        public MaxHeap(int capacity)
        {
            _heap = new T[capacity];
        }

        public void Sort()
        {
            int lastHeapIndex = Count - 1;
            for (int i = 0; i < lastHeapIndex; i++)
            {
                // lst item taken from the index -1, -2 etc...
                Exchange(0, lastHeapIndex - i);
                Sink(0, lastHeapIndex - i - 1);
            }
        }

        private void Exchange(int leftIndex, int rightIndex)
        {
            T tmp = _heap[leftIndex];
            _heap[leftIndex] = _heap[rightIndex];
            _heap[rightIndex] = tmp;
        }
    }
}
