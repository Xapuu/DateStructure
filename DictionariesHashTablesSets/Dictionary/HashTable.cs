using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    using System.Collections;

    public class HashTable<TKey, TValue> : IEnumerable<Dictionary<TKey, TValue>>
    {
        public const int InitialCapacity = 16;

        public const float LoadFactor = 0.75f;

        private LinkedList<Dictionary<TKey, TValue>>[] slots;

        public HashTable(int capacity = InitialCapacity)
        {
            this.slots = new LinkedList<Dictionary<TKey, TValue>>[capacity];
            this.Count = 0;
        }

        public int Capacity
        {
            get
            {
                return this.slots.Length;
            }
        }

        public int Count { get; private set; }

        public void Add(TKey key, TValue value)
        {
            GrowIfNeeded();
            int slotNumber = this.FindSlotNumber(key);
            if (slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<Dictionary<TKey, TValue>>();
            }
            foreach (var element in this.slots[slotNumber])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists: " + key);
                }
            }
            var newElement = new Dictionary<TKey, TValue>(key, value);
            this.slots[slotNumber].AddLast(newElement);
            this.Count++;
        }

        private int FindSlotNumber(TKey key)
        {
            int slotNumber = Math.Abs(key.GetHashCode()) % this.slots.Length;
            return slotNumber;
        }

        private void GrowIfNeeded()
        {
            if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
            {
                this.Grow();
            }
        }

        private void Grow()
        {
            var newHashTable = new HashTable<TKey, TValue>(2 * this.Capacity);
            foreach (var element in this)
            {
                newHashTable.Add(element.Key, element.Value);
            }
            this.slots = newHashTable.slots;
            this.Count = newHashTable.Count;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            GrowIfNeeded();
            int slotNumber = this.FindSlotNumber(key);
            if (slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<Dictionary<TKey, TValue>>();
            }
            foreach (var element in this.slots[slotNumber])
            {
                if (element.Key.Equals(key))
                {
                    element.Value = value;
                    return false;
                }
            }
            var newElement = new Dictionary<TKey, TValue>(key, value);
            this.slots[slotNumber].AddLast(newElement);
            this.Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            var element = this.Find(key);
            if (element == null)
            {
                throw new KeyNotFoundException("The key does not exist.");
            }

            return element.Value;
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);
            if (element != null)
            {
                value = element.Value;
                return true;
            }
            value = default(TValue);
            return false;
        }

        public Dictionary<TKey, TValue> Find(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    if (element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            var element = this.Find(key);
            return element != null;
        }

        public bool Remove(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];
            if (elements != null)
            {
                var currentElement = elements.First;
                while (currentElement != null)
                {
                    if (currentElement.Value.Key.Equals(key))
                    {
                        elements.Remove(currentElement);
                        this.Count--;
                        return true;
                    }
                    currentElement = currentElement.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<Dictionary<TKey, TValue>>[InitialCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.Select(element => element.Key);
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.Select(element => element.Value);
            }
        }

        public IEnumerator<Dictionary<TKey, TValue>> GetEnumerator()
        {
            foreach (var elements in this.slots)
            {
                if (elements != null)
                {
                    foreach (var element in elements)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
