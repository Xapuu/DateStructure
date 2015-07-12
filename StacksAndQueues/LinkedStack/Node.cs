using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{

    class Node<T>
    {
        public Node(T value, Node<T> nextNode)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public T Value { get; set; }

        public Node<T> NextNode { get; set; }
    }
}
