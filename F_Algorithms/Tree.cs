using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode(T value)
        {
            Value = value;
        }
        
        public void Insert(T newValue)
        {
            int compare = newValue.CompareTo(Value);
            if (compare == 0)
                return;
            else if (compare < 0)
            {
                if (Left == null)
                    Left = new TreeNode<T>(newValue);
                else
                    Left.Insert(newValue);
            }
            else
            {
                if (Right == null)
                    Right = new TreeNode<T>(newValue);
                else
                    Right.Insert(newValue);
            }
        }

        public TreeNode<T> Get(T newValue)
        {
            int compare = newValue.CompareTo(Value);
            if (compare == 0)
                return this;
            if (compare < 0)
            {
                if (Left == null)
                    return null;
                else
                    return Left.Get(newValue);
            }
            if (Right == null)
                return null;
            return Right.Get(newValue);
            
        }

        public IEnumerable<T> TraverseInOrder()
        {
            var list = new List<T>();
            InnerTraverse(list);
            return list;
        }

        private void InnerTraverse(List<T> list)
        {
            if (Left != null)
                Left.InnerTraverse(list);

            list.Add(Value);

            if(Right != null)
                Right.InnerTraverse(list);
        }

        public T Min()
        {
            if (Left != null)
                return Left.Min();
            return Value;
        }

        public T Max()
        {
            if (Right != null)
                return Right.Max();
            return Value;
        }
    }

    public class Bst<T> where T : IComparable<T>
    {
        private TreeNode<T> root;
        public TreeNode<T> Get(T value)
        {
            return root?.Get(value);
        }

        public T Min()
        {
            if (root == null)
                throw new InvalidOperationException("Empty tree");
            return root.Min();
        }

        public T Max()
        {
            if (root == null)
                throw new InvalidOperationException("Empty tree");
            return root.Max();
        }

        public void Insert(T value)
        {
            if (root == null)
                root = new TreeNode<T>(value);
            root.Insert(value);
        }

        public IEnumerable<T> TraverseInOrder()
        {
            if(root == null)
                return Enumerable.Empty<T>();
            return root.TraverseInOrder();
        }

        public void Remove(T value)
        {
            root = Remove(root, value);
        }

        public TreeNode<T> Remove(TreeNode<T> subtreeRoot, T value)
        {
            if (subtreeRoot == null)
                return null;
            int compareTo = value.CompareTo(subtreeRoot.Value);
            if (compareTo < 0)
            {
                subtreeRoot.Left = Remove(subtreeRoot.Left, value);
            }
            else if (compareTo > 0)
            {
                subtreeRoot.Right = Remove(subtreeRoot.Right, value);
            }
            else  // compare == 0
            {
                if (subtreeRoot.Left == null)
                {
                    return subtreeRoot.Right;
                }
                if (subtreeRoot.Right == null)
                {
                    return subtreeRoot.Left;
                }
                subtreeRoot.Value = subtreeRoot.Right.Min();
                subtreeRoot.Right = Remove(subtreeRoot.Right, subtreeRoot.Value);
            }
            return subtreeRoot;
        }
    }
}
