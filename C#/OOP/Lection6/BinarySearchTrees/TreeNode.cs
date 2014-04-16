using System;
using System.Linq;

namespace BinarySearchTrees
{
    public class TreeNode<T> : IComparable<TreeNode<T>> where T : IComparable<T>
    {
        private T nodeValue;
        private TreeNode<T> parent;
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        public TreeNode(T newValue):this(newValue,null,null,null)
        {
        }

        public TreeNode(T newValue, TreeNode<T> parentNode, TreeNode<T> leftChildNode, TreeNode<T> rightChildNode)
        {
            if (newValue == null) throw new ArgumentNullException("Can not make a node with Null value");
            else
            {
                this.nodeValue = newValue;
                this.parent = parentNode;
                this.leftChild = leftChildNode;
                this.rightChild = rightChildNode;
            }
        }

        public T NodeValue
        {
            get
            {
                return this.nodeValue;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("Can not set Null Value");
                else this.nodeValue = value;
            }
        }

        public TreeNode<T> Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
            }
        }

        public TreeNode<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }
            set
            {
                this.leftChild = value;
            }
        }

        public TreeNode<T> RightChild
        {
            get 
            { 
                return this.rightChild; 
            }
            set 
            { 
                this.rightChild = value; 
            }
        }

        public override string ToString()
        {
            string nodeLeftChild = (this.leftChild == null) ? "Null" : this.leftChild.nodeValue.ToString();
            string nodeRightChild = (this.rightChild == null) ? "Null" : this.rightChild.nodeValue.ToString();

            return string.Format("Node Value: {0}, LeftChild Value: {1}, RightChild Value: {2}",
                this.nodeValue.ToString(), nodeLeftChild, nodeRightChild);
        }

        public override int GetHashCode()
        {
            return this.nodeValue.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            TreeNode<T> tempNode = obj as TreeNode<T>;

            if (this.CompareTo(tempNode) == 0) return true;
            else return false;
        }

        public int CompareTo(TreeNode<T> other)
        {
            return this.nodeValue.CompareTo(other.nodeValue);
        }
    }

}
