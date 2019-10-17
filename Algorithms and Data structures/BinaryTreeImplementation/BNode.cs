using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeImplementation
{
    public class BNode
    {
        public BNode LeftChild { get; set; }
        public BNode RightChild { get; set; }
        public int Value { get; set; }

        public BNode(int value)
        {
            this.Value = value;
        }
    }
}
