using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBasedStack
{
    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] _elements;
        private int _count;

        public ArrayStack()
        {
            this._elements = new T[InitialCapacity];
            this.Count = 0;
        }
        
        public int Count
        {
            get { return this._count; }
            private set { this._count = value; }
        }

        public void Push(T element)
        {
            Grow();
            _elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new ArgumentNullException("Stack.Pop","Stack is empty!");
            }
            T element = _elements[--this.Count];
            _elements[this.Count] = default(T);

            return element;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            Array.Copy(_elements, array, this.Count);

            return array;
        }

        private void Grow()
        {
            if (this.Count == this._elements.Length)
            {
                T[] newElements = new T[2*this._elements.Length];
                Array.Copy(_elements, newElements, this.Count);
                this._elements = newElements;
            }       
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }
    }

}
