using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class FuzzyNode<T>
    {
        public T Value { get; set; }
        public FuzzyNode<T> Next {get; set;}

        public FuzzyNode(T value)
        {
            Value = value;
        }
        
    }
}
