using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataStructure
{
    internal class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public TNode Value { get; set; }
        public int CompareTo([AllowNull] TNode other)
        {
            return Value.CompareTo(other);
        }
    }
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> Root { get; set; }
        public int Count { get; private set; }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(Root, value);
            }
            Count++;
        }
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }
        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, Root);
        }
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;
            current = FindwithParent(value, out parent);

            if (current == null)
            {
                return false;
            }
            if (current.Right == null)
            {
                if(parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    if(parent.Value.CompareTo(current.Value) < 0)
                    {
                        parent.Right = current.Left;
                    }
                    else if(parent.Value.CompareTo(current.Value) > 0)
                    {
                        parent.Left = current.Left;
                    }
                }
                return true;
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if(parent == null)
                {
                    Root = current;
                }
                else
                {
                    if(parent.Value.CompareTo(current.Value) >0)
                    {
                        parent.Left = current.Right;
                    } 
                    else if(parent.Value.CompareTo(current.Value) < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
                return true;
            }
            else
            {
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }
                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if(parent == null)
                {
                    Root = leftmost;
                }
                else
                {
                    if(parent.Value.CompareTo(current.Value)>0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (parent.Value.CompareTo(current.Value) < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }
            return true;
        }
        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }
        public bool Contain(T value)
        {
            BinaryTreeNode<T> parent;
            return FindwithParent(value, out parent) != null;
        }
        private BinaryTreeNode<T> FindwithParent(T value, out BinaryTreeNode<T> parent)
        {
            var current = Root;
            parent = null;
            while (current != null)
            {
                if (current.Value.CompareTo(value) > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (current.Value.CompareTo(value) < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
