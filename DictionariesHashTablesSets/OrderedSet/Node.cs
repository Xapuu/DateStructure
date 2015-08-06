using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedSet
{
    class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
        }

        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
