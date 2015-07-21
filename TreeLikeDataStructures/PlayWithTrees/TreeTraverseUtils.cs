using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithTrees
{
    internal static class TreeTraverseUtils
    {
        public static void GetLongestPathInTree(TreeNode<int> startupNode)
        {
            var allLongestPathsInSubtree = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            var maxLength = 0;
            ConnectLongestPath(startupNode, currentPath, allLongestPathsInSubtree, ref maxLength);

            var longestPaths = allLongestPathsInSubtree.Where(p => p.Count == maxLength).ToList();
            PrintLongestPath(longestPaths);
        }

        public static void GetPathWithGivenSum(TreeNode<int> startupNode, int sum)
        {
            var pathsWithGivenSum = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            ConnectPathsWithGivenSum (startupNode, currentPath, pathsWithGivenSum, sum);
            PrintPathsWithGivenSum(pathsWithGivenSum,sum);
        }

        private static void ConnectLongestPath(TreeNode<int> node, LinkedList<int> currentPath,
            IList<List<int>> allPaths, ref int maxLength)
        {
            currentPath.AddLast(node.Value);

            if (node.Childrens.Count == 0 && currentPath.Count >= maxLength)
            {
                allPaths.Add(currentPath.ToList());

                if (currentPath.Count > maxLength)
                {
                    maxLength = currentPath.Count;
                }

                return;
            }

            foreach (var child in node.Childrens)
            {
                ConnectLongestPath(child, currentPath, allPaths, ref maxLength);
                currentPath.RemoveLast();
            }
        }

        private static void ConnectPathsWithGivenSum(TreeNode<int> node, LinkedList<int> currentPath, IList<List<int>> allPaths, int sum)
        {
            currentPath.AddLast(node.Value);

            if (node.Childrens.Count == 0 && currentPath.Sum() == sum)
            {
                allPaths.Add(currentPath.ToList());
                return;
            }

            foreach (var child in node.Childrens)
            {
                ConnectPathsWithGivenSum(child, currentPath, allPaths, sum);
                currentPath.RemoveLast();
            }
        }

        private static void PrintLongestPath(List<List<int>> path)
        {
            var longest = path.OrderBy(p => p.Count).First();

            Console.WriteLine("Depth: {0}", longest.Count);
            Console.Write("Longest path:  ");
            Console.Write(String.Join(", ", longest));
            Console.WriteLine();
        }

        private static void PrintPathsWithGivenSum (List<List<int>> paths, int sum)
        {
            Console.WriteLine("Paths with given sum: {0} ",sum);
            foreach (var path in paths.OrderBy(p => p.Count))
            {
                Console.WriteLine("{0}", string.Join(", ", path));
            }
        }

        public static void PrintTree(IReadOnlyCollection<TreeNode<int>> nodes)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine();
        }
    }
}
