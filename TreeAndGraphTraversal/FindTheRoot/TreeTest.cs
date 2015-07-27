using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheRoot
{
    class TreeTest
    {
        static void Main(string[] args)
        {           
            int edges = int.Parse(Console.ReadLine());
            var treeNodes = new Dictionary<int, TreeNode<int>> ();

            for (int edge = 0; edge < edges; edge++)
            {
                int [] nodes = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var parent = new TreeNode<int>(nodes[0]);
                var child = new TreeNode<int>(nodes[1]);

                if (!treeNodes.ContainsKey(nodes[0]))
                {                   
                    treeNodes.Add(nodes[0], parent);
                }
                if (!treeNodes.ContainsKey(nodes[1]))
                {
                    treeNodes.Add(nodes[1], child);
                }
               treeNodes[nodes[1]].Parent = parent;
            }

            FindNodeWithoutParent(treeNodes);
        }

        private static void FindNodeWithoutParent(Dictionary<int, TreeNode<int>> treeNodes )
        {
            var treeRoots = treeNodes.Where(node => node.Value.Parent == null).Select(node => node.Value).ToList();
            PrintRootResult(treeRoots);
        }

        private static void PrintRootResult(List<TreeNode<int>> treeRoots)
        {
            if (treeRoots.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (treeRoots.Count > 1)
            {
                Console.WriteLine("Forest is not a tree!");
            }
            else
            {
                Console.WriteLine("The root is {0}", treeRoots.First().Value);
            }
        }
    }
}
