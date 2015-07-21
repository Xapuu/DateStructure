using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithTrees
{
    class TreeNode<T>
    {
        private IList<TreeNode<T>> _childrens;

        public TreeNode(T value)
        {
            this.Value = value;
            this.Childrens = new List<TreeNode<T>>();
        }

        public TreeNode(T value, IList<TreeNode<T>> childrens)
            : this(value)
        {
            this.Childrens = childrens;
        }

        public T Value { get; private set; }

        public TreeNode<T> Parent { get; set; }

        public IList<TreeNode<T>> Childrens
        {
            get { return this._childrens; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Childrens collection can not be null!");
                }
                this._childrens = value;
            }
        }

        public override string ToString()
        {
            StringBuilder treeBuilder = new StringBuilder();

            if (this.Parent == null)
            {
                treeBuilder.Append("Root: ");
            }

            if (!this.Childrens.Any())
            {
                treeBuilder.Append("Leaf: ");
            }

            treeBuilder.Append(string.Format("{0}", this.Value));

            if (this.Childrens.Any())
            {
                treeBuilder.AppendLine();
                treeBuilder.AppendLine(" |_");
                var childrenValues = this.Childrens.Select(child => child.Value);
                var valuesToString = string.Join(", ", childrenValues);
                treeBuilder.AppendFormat("   |-childrens-> {{ {0} }}", valuesToString);
            }

            return treeBuilder.ToString();
        }
    }
}
