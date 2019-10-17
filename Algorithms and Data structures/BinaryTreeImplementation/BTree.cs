using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeImplementation
{
    public class BTree
    {
        public BNode root;

        public BTree(int value)
        {
            this.root = new BNode(value);
        }

        private void PrintTree(BNode node)
        {
            if (node == null)
            {
                return;
            }

            //Console.WriteLine(node.Value);
            //PrintTree(node.LeftChild);
            //PrintTree(node.RightChild);
            //POST ORDER
            //PrintTree(node.LeftChild);
            //PrintTree(node.RightChild);
            //Console.WriteLine("Value = " + node.Value);


            PrintTree(node.LeftChild);
            Console.WriteLine(node.Value);
            PrintTree(node.RightChild);
        }

        public void PrintTree()
        {
            PrintTree(root);
        }

        public void AddN(int v, BNode node)
        {
            if (node.Value < v)
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new BNode(v);
                }
                else
                {
                    AddN(v, node.RightChild);
                }

            }
            else
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new BNode(v);
                }
                else
                {
                    AddN(v, node.LeftChild);
                }

            }
        }

        public void Add(int value)
        {
            AddN(value, root);
            /*BNode tmp = this.root;
            while (tmp != null)
            {
                if (tmp.Value < value)
                {
                    if (tmp.RightChild == null)
                    {
                        tmp.RightChild = new BNode(value);
                        break;
                    }
                    else
                    {
                        tmp = tmp.RightChild;
                    }
                }
                else
                {
                    if (tmp.LeftChild == null)
                    {
                        tmp.LeftChild = new BNode(value);
                        break;
                    }
                    else
                    {
                        tmp = tmp.LeftChild;
                    }
                }
            }*/
        }
    }
}
