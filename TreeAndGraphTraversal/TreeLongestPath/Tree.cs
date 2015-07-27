using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLongestPath
{
    class Tree
    {
        internal class TreeNode
        {
            private IList<TreeNode> _childrens;

            public TreeNode(int value)
            {
                this.Value = value;
                this.Childrens = new List<TreeNode>();
            }

            public TreeNode Parent { get; set; }
            public int Value { get; set; }

            public IList<TreeNode> Childrens
            {
                get { return _childrens; }
                set { _childrens = value; }
            }
        }
        private readonly Dictionary<int, TreeNode> _tree = new Dictionary<int, TreeNode>();

        public TreeNode RoodNode
        {
            get { return this._tree.Values.First(node => node.Parent == null); }
        }

        public IList<TreeNode> LeafNodes
        {
            get
            {
                var leafNode = this._tree.Values.Where(node => node.Childrens.Count == 0).ToList();
                return leafNode;
            }
        }

        public void MakeConnectionNodes(int parentNodeValue, int childNodeValue)
        {
            var parentNode = this.GetTreeNodeByValue(parentNodeValue);
            var childNode = this.GetTreeNodeByValue(childNodeValue);
            parentNode.Childrens.Add(childNode);            
            childNode.Parent = parentNode;
        }

        private TreeNode GetTreeNodeByValue(int value)
        {
            if (!this._tree.ContainsKey(value))
            {
                this._tree[value] = new TreeNode(value);
            }

            return this._tree[value];
        }
    }
}
