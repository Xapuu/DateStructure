using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheRoot
{
    class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
    }
}
