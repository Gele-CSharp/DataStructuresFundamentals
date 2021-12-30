namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            string result = $"{new string(' ', indent)}{this.Value}\r\n";

            if (this.LeftChild != null)
            {
                result += LeftChild.AsIndentedPreOrder(indent + 2);
            }

            if (this.RightChild != null)
            {
                result += RightChild.AsIndentedPreOrder(indent + 2);
            }

            return result;
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> trees = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                trees.AddRange(LeftChild.InOrder());
            }

            trees.Add(this);

            if (this.RightChild != null)
            {
                trees.AddRange(RightChild.InOrder());
            }

            return trees;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> trees = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                trees.AddRange(LeftChild.PostOrder());
            }

            if (this.RightChild != null)
            {
                trees.AddRange(RightChild.PostOrder());
            }

            trees.Add(this);
            return trees;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> trees = new List<IAbstractBinaryTree<T>>();
            trees.Add(this);

            if (this.LeftChild != null)
            {
                trees.AddRange(LeftChild.PreOrder());
            }

            if (this.RightChild != null)
            {
                trees.AddRange(RightChild.PreOrder());
            }

            return trees;
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                LeftChild.ForEachInOrder(action);
            }

            action.Invoke(Value);

            if (this.RightChild != null)
            {
                RightChild.ForEachInOrder(action);
            }
        }
    }
}
