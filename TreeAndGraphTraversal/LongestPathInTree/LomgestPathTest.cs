using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPathInTree
{
    class LomgestPathTest
    {
        static Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
        static Dictionary<int, int?> parents = new Dictionary<int, int?>();

        static void Main(string[] args)
        {
            int treeNodes = int.Parse(Console.ReadLine());
            int treeEdges = int.Parse(Console.ReadLine());

            for (int edge = 0; edge < treeEdges; edge++)
            {
                int[] edges = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int firstNode = edges[0];
                int secondNode = edges[1];

                if (!tree.ContainsKey(firstNode))
                {
                    tree[firstNode] = new List<int>();
                }
                if (!tree.ContainsKey(secondNode))
                {
                    tree[secondNode] = new List<int>();
                }
                if (!parents.ContainsKey(secondNode))
                {
                    parents[secondNode] = firstNode;
                }
                if (!parents.ContainsKey(firstNode))
                {
                    parents[firstNode] = null;
                }

                tree[firstNode].Add(secondNode);
                parents[secondNode] = firstNode;
            }        
        }

        private static List<int> GetTreeLeaves()
        {
            var leaves = tree.Where(node => node.Value.Count == 0).Select(node => node.Key).ToList();
            return leaves;
        }

        private static int GetTreeRoot()
        {
            var root = parents.First(parent => parent.Value == null);
            return root.Key;
        }
    }
}
