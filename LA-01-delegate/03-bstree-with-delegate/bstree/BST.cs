using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bstree
{
    enum TraversalTypes
    {
        PreOrder, InOrder, PostOrder
    }

    class BST<T,K> where K : IComparable
    {
        private TreeItem root;
        class TreeItem
        {
            public T content;
            public K key;
            public TreeItem left;
            public TreeItem right;

            public TreeItem(T content, K key)
            {
                this.key = key; this.content = content;
            }

            //public override string ToString()
            //{
            //    return $"{key.ToString()} - {content.ToString()}";
            //}
        }
        public BST()
        {
            this.root = null;
        }

        public delegate void TraversalHandler(T content);

        public void Insert(T content, K key)
        {
            Insert(ref this.root, content, key);
        }
        private void Insert(ref TreeItem p, T content, K key)
        {
            if (p == null)
                p = new TreeItem(content, key);

            else if (p.key.CompareTo(key) < 0)
                Insert(ref p.right, content, key);

            else if (p.key.CompareTo(key) > 0)
                Insert(ref p.left, content, key);

            else
                throw new KeyExistsException("Item with the given key already exists.");
        }

        #region TRAVERSALS

        public void Traverse(TraversalTypes type, TraversalHandler methodToRun)
        {
            TraversalHandler methodX = methodToRun;

            if (type == TraversalTypes.PreOrder)
                PreOrder(this.root, methodX);

            else if (type == TraversalTypes.InOrder)
                InOrder(this.root, methodX);

            else if (type == TraversalTypes.PostOrder)
                PostOrder(this.root, methodX);
        }

        private void PreOrder(TreeItem p, TraversalHandler method)
        {
            if(p != null)
            {
                if (method != null) method(p.content);
                PreOrder(p.left, method);
                PreOrder(p.right, method);
            }
        }

        private void InOrder(TreeItem p, TraversalHandler method)
        {
            if (p != null)
            {
                InOrder(p.left, method);
                if (method != null) method(p.content);
                InOrder(p.right, method);
            }
        }

        private void PostOrder(TreeItem p, TraversalHandler method)
        {
            if (p != null)
            {
                PostOrder(p.left, method);
                PostOrder(p.right, method);
                if (method != null) method(p.content);
            }
        }

        #endregion
    }
}
