using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree tree = new BTree(9);
            //tree.root.LeftChild = new BNode(7);
            //tree.root.RightChild = new BNode(11);
            //tree.root.LeftChild.LeftChild = new BNode(5);
            //tree.root.RightChild.RightChild = new BNode(15);
            tree.Add(11);
            tree.Add(13);
            tree.Add(5);
            tree.Add(7);
            tree.PrintTree();
            Console.ReadLine();
        }
    }
}
