using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{

    class BstEnumerable : IEnumerable<Node>
    {
        public BstEnumerable(Node rootNode, int key)
        {
            _rootNode = rootNode;
            _key = key;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return new BstEnumerator(_rootNode, _key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        private readonly Node _rootNode;
        private readonly int _key;

    }

    class BstEnumerator : IEnumerator<Node>
    {

        public BstEnumerator(Node rootNode, int key)
        {
            _rootNode = rootNode;
            _currentNode = rootNode;
            _key = key;
        }

        public Node Current => _currentNode; 

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if(_currentNode == null)
            {
                return false;
            }

            if (_currentNode.Key == _key)
            {
                return false;
            }

            Node nextNode;

            if (_key > _currentNode.Key)
            {
                nextNode = _currentNode.Right;
            }
            else
            {
                nextNode = _currentNode.Left;
            }

            if(nextNode == null)
            {
                return false;
            }

            _currentNode = nextNode;

            return true;
        }

        public void Reset()
        {
            _currentNode = _rootNode;
        }

        void IDisposable.Dispose()
        {
        }

        private readonly Node _rootNode;
        private readonly int _key;
        private Node _currentNode;

    }

    static class NodeEnumerableExtensions {
        public static BstEnumerable GetEnumerableForKey(this Node node, int key)
        {
            return new BstEnumerable(node, key);
        }
    }

}