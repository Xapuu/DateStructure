using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem6.ImplementtheDataStructureReversedList
{
    public class ReverseList<T> : IEnumerable<T>
    {
        private const int defaultCapacity = 4;
        private int capacity;
        private int count;
        private T[] array;
        
        public ReverseList()
        {
            this.array = new T[defaultCapacity];
            this.capacity = defaultCapacity;
        }

        public ReverseList(int capacity)
        {
            this.array = new T[capacity];
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int Count
        {
            get { return this.count; }
        }

        public T this[int index]
        {
            get
            {
                if (index > count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                return this.array[count - index-1];
            }

            set
            {
                if (index > count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                this.array[count - index-1] = value;
            }
        }

        public void Add(T item)
        {
            if(count >= capacity)
            {
                this.Expand();
            }
            array[count] = item;
            count++;
        }

        public void Remove(int index)
        {
            index = count - index-1;
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }
            T[] newArray = new T[capacity];
            Array.Copy(this.array,0, newArray, 0,index);
            Array.Copy(this.array, index+1 , newArray, index, this.array.Length - (index+1));
            count--;
            this.array = newArray;
        }

        private void Expand()
        {
            T[] newarray = new T[capacity * 2];
            this.capacity += capacity;
            Array.Copy(this.array,newarray,count);
            this.array = newarray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
