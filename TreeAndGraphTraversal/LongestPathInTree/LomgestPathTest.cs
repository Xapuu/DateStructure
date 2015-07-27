using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPathInTree
{
    class LomgestPathTest
    {
        static void Main(string[] args)
        {
            int treeNodes = int.Parse(Console.ReadLine());
            int treeEdges = int.Parse(Console.ReadLine());
            List<TreeNode> tree = new List<TreeNode>();

            for (int edge = 0; edge < treeEdges; edge++)
            {
                int[] edges = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int firstNode = edges[0];
                int secondNode = edges[1];

                var parent = new TreeNode(firstNode);
                var child = new TreeNode(secondNode);

                if (!tree.Contains(parent))
                {
                    tree.Add(parent);
                }
                //if (!tree.Contains(child))
                //{
                //    tree.Add(child);
                //}
                child.ParentNode = parent;                                
                parent.AddChild(child);
                //child.AddChild(parent);
            }
            Console.Clear();
            PrintSet(tree);
        }

        static void PrintSet(List<TreeNode> tree)
        {
            foreach (var node in tree)
            {
                Console.WriteLine(node.Value);
                foreach (var child in node.Childrens)
                {
                    Console.Write(child.Value+ " ");
                }
            }
        }
    }
}
