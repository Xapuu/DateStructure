using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    class LinkedStack<T>
    {       
        private readonly LinkedListStack<T> _list= new LinkedListStack<T>(); 
     
        public void Push(T element)
        {   
            _list.AddFirst(element);       
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new ArgumentNullException("Stack.Pop", "Stack is empty!");
            }
            return _list.RemoveFirst();
        }

        public bool IsEmpty ()
        {
            return _list.IsEmpty();
        }

        public T[] ToArray()
        {
            var array = new T[_list.Count];
            var node = _list.FirstNode;

            for (int i = 0; i < _list.Count; i++)
            {
                array[i] = node.Value;
                node = node.NextNode;
            }
            return array;
        }

        public int Count()
        {
            return _list.Count;
        }
    }
}
