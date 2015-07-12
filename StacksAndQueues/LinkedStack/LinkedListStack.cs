using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    class LinkedListStack<T>
    {
        private int _count = 0;

        public LinkedListStack()
        {
            this.FirstNode = null;
        }

        public Node<T> FirstNode { get; set; }

        public int Count
        {
            get { return this._count; }
            private set { this._count = value; }
        }

        public void AddFirst(T element)
        {
            Node<T> currentNode = this.FirstNode;
            this.FirstNode = new Node<T>(element, this.FirstNode);
            FirstNode.NextNode = currentNode;
            this.Count++;
        }

        public T RemoveFirst()
        {
            T element = FirstNode.Value;
            FirstNode = FirstNode.NextNode;
            this.Count--;
            return element;
        }

        public bool IsEmpty()
        {
            return FirstNode == null;
        }
    }
}
