
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace AlgorithmsExercises
{
    public class SingleLinkedList<T>
    {
        public Node<T>? First { get; private set; }
        public Node<T>? Last { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        private void AddFirst(Node<T> node)
        {
            //save current head
            Node<T>? tmp = First;

            First = node;

            //Shift the former first
            First.Next = tmp;

            Count++;                                            //Increment counter

            //Special case
            if (Count == 1)
            {
                Last = First;
            }            
        }

        //Implementation of add last method
        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
            
                
        }

        private void AddLast(Node<T> node)                      //If the list is empty, assign the node being added to first and last, since list has only one node.
        {
            if (IsEmpty)
            
                First = node;    
            else                                                //IF the list is not empty, the node pointing to the tail, should point to the new node.
            
                Last.Next = node;                               

            Last = node;                                        //Adds a new node


            Count++;
        }

        //Implement remove first method
        public void removeFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            First = First.Next;                                 //Ensures nothing references the former first node. The former first is garbage collected and the first points to the node which follows the former first.
            if (Count == 1)
                Last = null;

            Count--;
        }

        //Implement remove last method
        public void removeLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            //When there are no nodes, First and Last are null    
            if (Count == 1)
                First = Last = null;

            else
            {
                // find penultimate node
                var current = First;
                while (current.Next != Last)
                {
                    current = current.Next;
                }

                current.Next = null;
                Last = current;
            }

            Count--;
        }

        internal IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsEmpty => Count == 0;
        
    }
}
