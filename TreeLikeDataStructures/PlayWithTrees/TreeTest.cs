using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithTrees
{
    internal class TreeTest
    {
        private static void Main(string[] args)
        {
            Tree<int> testTree = new Tree<int>();

            int nodeCount = int.Parse(Console.ReadLine());

            for (int node = 1; node < nodeCount; node++)
            {
                string[] edge = Console.ReadLine().Split();
                int parentValue = int.Parse(edge[0]);
                int childValue = int.Parse(edge[1]);
                testTree.MakeConnectionNodes(parentValue, childValue);
            }
            int pathSum = int.Parse(Console.ReadLine());

            TreeTraverseUtils.PrintTree(testTree.Nodes);
            TreeTraverseUtils.GetLongestPathInTree(testTree.RoodNode);
            TreeTraverseUtils.GetPathWithGivenSum(testTree.RoodNode, pathSum);
        }           
    }
}
