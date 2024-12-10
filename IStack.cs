using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExercises
{
    public class IStack<T> : IEnumerable<T>
    {
        bool IsEmpty => true;
        private sealed class EmptyStack : IStack<T>
        {
            public T Peek()
            {
                throw new Exception("EmptyStack stack");
            }

            public IStack<T> Push(T value)
            {
                return new Stack<T>(value, this);
            }

            public IStack<T> Pop()
            {
                throw new Exception("Empty stack");
            }

            public IEnumerator<T> GetEnumerator()
            {
                yield break;
            }

            
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
        
        

        
    }
}
