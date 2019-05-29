using System;
using BinarySearchTree.RecursiveBst;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            var rootNode = new Node(rand.Next(101));

            Console.WriteLine("Inserting 100 random integers into BST.");

            for (int i = 0; i < 100; ++i)
            {
                rootNode.Insert(rand.Next(101));
            }

            for (int i = 0; i < 5; ++i)
            {
                var key = rand.Next(101);
                SearchRecursively(key, rootNode);
                SearchEnumerating(key, rootNode);
            }
        }

        static void SearchRecursively(int key, Node rootNode)
        {
            Console.WriteLine($"Search for {key} recursively...");
            var founded = rootNode.Find(key)?.Key;
            Console.WriteLine($"Found: {founded}");
        }

        static void SearchEnumerating(int key, Node rootNode)
        {
            Console.WriteLine($"Search for {key} enumerating through the tree...");

            foreach (var node in rootNode.GetEnumerableForKey(key))
            {
                Console.WriteLine($"Node key: {node?.Key}");
                Console.WriteLine($"Node right: {node.Right?.Key}");
                Console.WriteLine($"Node left: {node.Left?.Key}");
                if (key == node.Key)
                {
                    Console.WriteLine("Found!");
                }
            }
        }

    }
}
