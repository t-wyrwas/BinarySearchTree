using System;

namespace BinarySearchTree
{
    class Node
    {
        public Node(int key)
        {
            Key = key;
        }
        public int Key { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}