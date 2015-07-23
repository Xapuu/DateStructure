using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithTrees
{
    class Tree<T>
    {
        private readonly IDictionary<T, TreeNode<T>> _nodes= new Dictionary<T, TreeNode<T>>();

        public TreeNode<T> RooTNode
        {
            get { return this._nodes.Values.FirstOrDefault(node => node.Parent == null); }
        }

        public IReadOnlyCollection<TreeNode<T>> Nodes => new ReadOnlyCollection<TreeNode<T>>(this._nodes.Values.ToList());

        public IReadOnlyCollection<TreeNode<T>> MiddleNode
        {
            get
            {
                var middleNode = this._nodes.Values.Where(node => node.Childrens.Count != 0 && node.Parent != null).ToList();
                return middleNode;
            }
        }

        public IReadOnlyList<TreeNode<T>> LeafNode
        {
            get
            {
                var leafNode = this._nodes.Values.Where(node => node.Childrens == null).ToList();
                return leafNode;
            }
        }

        public void MakeConnectionNodes(T parentNodeValue, T childNodeValue)
        {
            var parentNode = this.GetTreeNodeByValue(parentNodeValue);
            var childNode = this.GetTreeNodeByValue(childNodeValue);
            parentNode.Childrens.Add(childNode);
            childNode.Parent = parentNode;
        }

        private TreeNode<T> GetTreeNodeByValue (T value)
        {
            if (!this._nodes.ContainsKey(value))
            {
                this._nodes[value] = new TreeNode<T>(value);
            }

            return this._nodes[value];
        } 
    }
}
