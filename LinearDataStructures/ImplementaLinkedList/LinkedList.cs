using System.Collections;
using System.Collections.Generic;

namespace Problem7.ImplementaLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> first;
        private ListNode<T> current;  
        private int count;

        public LinkedList()
        {
        }
        
        public void Add(T item)
        {
            if (current == null)
            {
                first = new ListNode<T>(this, item);
                current = first;
                return;
            }
            current.Next = new ListNode<T>(this,item);
            current = current.Next;
            count++;
        }

        public int FirstIndexOf(T item)
        {
            ListNode<T> newNode = first;
            int index = 0;
            while (true)
            {
                if (newNode.Value.Equals(item))
                {
                    break;
                }
                index++;
                newNode = newNode.Next;
                if (newNode == null)
                {
                    index = -1;
                    break;
                }
            }
            return index;
        }

        public int LastIndexOf(T item)
        {
            ListNode<T> newNode = first;
            int lastIndex = -1;
            int index = 0;
            while (true)
            {
                if (newNode.Value.Equals(item))
                {
                    lastIndex = index;
                }
                index++;
                newNode = newNode.Next;
                if (newNode == null)
                {
                    break;
                }
            }
            return lastIndex;
        }

        public void Remove(int index)
        {
            ListNode<T> temp = first;
            for (int i = 0; i < index-1; i++)
            {
                temp = temp.Next;
            }
            temp.Next = temp.Next.Next;
            count--;
        }

        public int Count
        {
            get { return this.count; }
        }
        public T GetCurrent
        {
            get { return this.current.Value; }
        }

        public T First
        {
            get { return this.first.Value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> item = first;
            for (int i = 0; i <= count; i++)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
