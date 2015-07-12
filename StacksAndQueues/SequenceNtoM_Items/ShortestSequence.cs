using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceNtoM_Items
{
    public static class ShortestSequence
    {
        public static IList<IEnumerable<T>> GetShortestSequences<T>(T start, T end, IList<Func<T, T>> functions)
            where T : IComparable<T>
        {
            var results = new List<IEnumerable<T>>();
            var visited = new HashSet<T>();
            var currentNodes = new Queue<Node<T>>();

            visited.Add(start);
            currentNodes.Enqueue(new Node<T>(start));

            while (currentNodes.Count > 0)
            {
                var nextNodes = new Queue<Node<T>>();

                var nextVisited = new HashSet<T>();

                while (currentNodes.Count > 0)
                {
                    var currentNode = currentNodes.Dequeue();

                    foreach (var function in functions)
                    {
                        T nextElement = function(currentNode.Value);

                        if (nextElement.CompareTo(end) > 0)
                            continue;

                        if (visited.Contains(nextElement))
                            continue;

                        var nextNode = new Node<T>(nextElement);
                        nextNode.Previous = currentNode;

                        nextVisited.Add(nextElement);
                        nextNodes.Enqueue(nextNode);

                        if (nextElement.Equals(end))
                        {
                            var sequence = new ReversedLinkedList<T>(nextNode);
                            results.Add(sequence.Reverse());
                        }
                    }
                }
                visited.UnionWith(nextVisited);

                if (results.Count != 0)
                {
                    nextNodes.Clear();
                }                    
                currentNodes = nextNodes;
            }
            return results;
        }
    }
}
