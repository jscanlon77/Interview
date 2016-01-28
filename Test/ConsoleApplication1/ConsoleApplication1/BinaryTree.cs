using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class BinaryTree<T>
    {
        public BinaryTree()
        {
            root = null;
        }

        public BinaryTreeNode<T> Root
        {
            get
            {
                return root;
            }
            set { root = value; }
        }

        private readonly IComparer<T> _comparer = Comparer<T>.Default;
        private BinaryTreeNode<T> root;

        public virtual void Clear()
        {
            Root = null;
        }

        public bool Contains(T data)
        {
            var current = root;
            while (current != null)
            {
                var result=_comparer.Compare(current.Value, data);
                if (result == 0)
                {
                    return true;
                }
                if (result > 0)
                {
                    current = current.Left;
                }
                else if (result < 0)
                {
                    current = current.Right;
                }
            }

            return false;
        }
    }
}