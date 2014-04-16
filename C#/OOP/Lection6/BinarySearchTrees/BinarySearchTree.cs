using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTrees
{
    public struct BinarySearchTree<T> : ICloneable, IEnumerable<TreeNode<T>> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void AddElement(T nodeValue)
        {
            this.root = AddElement(root,nodeValue,null);
        }

        private TreeNode<T> AddElement(TreeNode<T> newChild, T nodeValue, TreeNode<T> parentNode)
        {
            if (newChild == null)
            {
                newChild = new TreeNode<T>(nodeValue);
                newChild.Parent = parentNode;
            }
            else
            {
                int comparedValue = nodeValue.CompareTo(newChild.NodeValue);

                if (comparedValue < 0) newChild.LeftChild = AddElement(newChild.LeftChild, nodeValue, newChild);
                else if (comparedValue > 0) newChild.RightChild = AddElement(newChild.RightChild, nodeValue, newChild);
            }

            return newChild;
        }

        public TreeNode<T> GetElement(T nodeValue)
        {
            return this.GetElement(this.root, nodeValue);
        }

        private TreeNode<T> GetElement(TreeNode<T> node, T nodeValue)
        {
            int comparedValue = nodeValue.CompareTo(node.NodeValue);

            if (comparedValue == 0) return node; // found node

            if (comparedValue < 0) // must search only from the left
            {
                if (node.LeftChild != null) return GetElement(node.LeftChild, nodeValue);
                else return null;
            }
            else //result must be from the right
            {
                if (node.RightChild != null) return GetElement(node.RightChild, nodeValue);
                else return null;
            }
        }

        public void DeleteElement(T nodeValue)
        {
            TreeNode<T> nodeToDelete = GetElement(nodeValue);

            if (nodeToDelete == null) return;
            
            DeleteElement(nodeToDelete);
        }

        private void DeleteElement(TreeNode<T> nodeToDelete)
        {
            if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
            {
                TreeNode<T> replacement = nodeToDelete.RightChild;
                
                while (replacement.LeftChild != null) replacement = replacement.LeftChild;
                
                nodeToDelete.NodeValue = replacement.NodeValue;
                nodeToDelete = replacement;
            }

            TreeNode<T> theChild = (nodeToDelete.LeftChild != null) ? nodeToDelete.LeftChild : nodeToDelete.RightChild;

            if (theChild != null)
            {
                theChild.Parent = nodeToDelete.Parent;

                if (nodeToDelete.Parent == null) root = theChild;
                else
                {
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete) nodeToDelete.Parent.LeftChild = theChild;
                    else nodeToDelete.Parent.RightChild = theChild;
                }
            }
            else
            {
                if (nodeToDelete.Parent == null) root = null;
                else
                {
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete) nodeToDelete.Parent.LeftChild = null;
                    else nodeToDelete.Parent.RightChild = null;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (TreeNode<T> singleNode in this)
                sb.Append(singleNode.NodeValue + " ");

            return sb.ToString();
        }   

        public object Clone()
        {
            BinarySearchTree<T> clonedTree = new BinarySearchTree<T>();
            DeepCopy(this.root, ref clonedTree);

            return clonedTree;
        }

        private void DeepCopy(TreeNode<T> root, ref BinarySearchTree<T> tree)
        {
            if (root == null) return;

            tree.AddElement(root.NodeValue);
            DeepCopy(root.LeftChild, ref tree);
            DeepCopy(root.RightChild, ref tree);
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator() as IEnumerator;
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            List<TreeNode<T>> allNodes = new List<TreeNode<T>>();
            GetNextNode(root, ref allNodes);

            foreach (TreeNode<T> singleNode in allNodes)
                yield return singleNode;
        }

        public void GetNextNode(TreeNode<T> singleNode, ref List<TreeNode<T>> allNodes)  //left to right traverse
        {
            if (singleNode == null) return;
            else
            {
                allNodes.Add(singleNode);
                GetNextNode(singleNode.LeftChild, ref allNodes);
                GetNextNode(singleNode.RightChild, ref allNodes);
            }
        }
        
        public override int GetHashCode()
        {
            return this.root.NodeValue.GetHashCode();
        }                  

        public override bool Equals(object obj)
        {
            bool isEqual = true;

            BranchEquals(this.root, ((BinarySearchTree<T>)obj).root, ref isEqual);

            return isEqual;
        }

        private void BranchEquals(TreeNode<T> firstNode, TreeNode<T> secondNode, ref bool isEqual)
        {
            if (firstNode == null && secondNode == null) return;

            if ((firstNode != null && secondNode == null) || (firstNode == null && secondNode != null) || firstNode.CompareTo(secondNode) != 0)
            {
                isEqual = false;
                return;
            }

            BranchEquals(firstNode.LeftChild, secondNode.LeftChild, ref isEqual);
            BranchEquals(firstNode.RightChild, secondNode.RightChild, ref isEqual);
        }

        public static bool operator ==(BinarySearchTree<T> firstTree, BinarySearchTree<T> secondTree)
        {
            if (firstTree.Equals(secondTree)) return true;
            else return false;
        }

        public static bool operator !=(BinarySearchTree<T> firstTree, BinarySearchTree<T> secondTree)
        {
            if (!firstTree.Equals(secondTree)) return true;
            else return false;
        }
    }
}
