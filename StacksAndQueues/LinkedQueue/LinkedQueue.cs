using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedQueue
{
    public class LinkedQueue<T>
    {
        private int _count;
        private QueueNode<T> _headNode;
        private QueueNode<T> _tailNode;

        public LinkedQueue()
        {
            this._headNode = null;
            this._tailNode = null;
            this.Count = 0;
        }


        public int Count
        {
            get { return this._count; }
            private set { this._count = value; }
        }

        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element); 
            if (IsEmpty())
            {
                _headNode = _tailNode = newNode;
            }
            else
            {
                newNode.PrevNode = this._tailNode;
                this._tailNode.NextNode = newNode;
                this._tailNode = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new ArgumentNullException("Dequeue", "Queue is empty!");
            }
            T element = _headNode.Value;
            _headNode = _headNode.NextNode;
            this.Count--;
            return element;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            var node = this._headNode;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = node.Value;
                node = node.NextNode;
            }
            return array;
        }

        public bool IsEmpty()
        {
            return this._headNode == null 
                && this._tailNode == null;
        }
    }
}
