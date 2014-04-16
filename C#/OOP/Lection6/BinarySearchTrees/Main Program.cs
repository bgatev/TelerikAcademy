using System;
using System.Linq;

namespace BinarySearchTrees
{
    class Program
    {
        static void Main()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.AddElement(120);
            tree.AddElement(12);
            tree.AddElement(20);
            tree.AddElement(10);
            tree.AddElement(30);
            tree.AddElement(42);
            tree.AddElement(160);

            TreeNode<int> myNode = tree.GetElement(120);
            Console.WriteLine(myNode);
 
            Console.Write("Traverse tree with foreach: ");
            foreach (TreeNode<int> singleNode in tree)
                Console.Write(singleNode.NodeValue + " ");
            Console.WriteLine();

            BinarySearchTree<int> secondTree = (BinarySearchTree<int>)tree.Clone();
            secondTree.AddElement(28);
            secondTree.DeleteElement(124);

            Console.Write("Traverse Second Tree with foreach: ");
            foreach (TreeNode<int> singleNode in secondTree)
                Console.Write(singleNode.NodeValue + " ");
            Console.WriteLine();

            Console.WriteLine("Tree Equals to Second Tree: {0}",tree.Equals(secondTree));
            Console.WriteLine("Tree Equals to Second Tree: {0}", tree == secondTree);
            Console.WriteLine("Tree Differ to Second Tree: {0}", tree != secondTree);
            Console.WriteLine("My tree is: {0}",tree);
        }
    }
}
