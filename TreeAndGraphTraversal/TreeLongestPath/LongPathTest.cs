using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLongestPath
{
    internal class LongPathTest
    {
        private static void Main(string[] args)
        {
            Tree tree = new Tree();
            int treeNodes = int.Parse(Console.ReadLine());
            int treeEdges = int.Parse(Console.ReadLine());

            for (int edge = 0; edge < treeEdges; edge++)
            {
                int[] edges = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int parent = edges[0];
                int child = edges[1];

                tree.MakeConnectionNodes(parent, child);
            }

            var rootNode = tree.RoodNode;
            var leaves = tree.LeafNodes;
            Console.WriteLine("The sum of all leaves is {0}", leaves.Sum(leaf=>leaf.Value));     
        }
    }
}