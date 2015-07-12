using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceNtoM_Items
{
    public class ReversedLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Last { get; set; }

        public ReversedLinkedList(Node<T> last)
        {
            this.Last = last;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> current = this.Last; current != null; current = current.Previous)
                yield return current.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
