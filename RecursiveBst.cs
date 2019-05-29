using System;

namespace BinarySearchTree.RecursiveBst
{
    static class NodeExtensions
    {
        public static bool Insert(this Node node, int key)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Key == key)
            {
                return true;
            }

            if (key > node.Key)
            {
                if (!node.Right.Insert(key))
                {
                    node.Right = new Node(key);
                    return true;
                }
            }
            else
            {
                if (!node.Left.Insert(key))
                {
                    node.Left = new Node(key);
                    return true;
                }
            }

            return true;
        }

        public static Node Find(this Node node, int key)
        {
            Console.WriteLine($"> key: {node.Key}");
            if (node.Key == key)
            {
                Console.WriteLine("> found");
                return node;
            }

            Console.WriteLine($"> left key: {node.Left?.Key}");
            Console.WriteLine($"> right key: {node.Right?.Key}");

            return key > node.Key ? node.Right?.Find(key) :
                    node.Left?.Find(key);
        }
    }
}
