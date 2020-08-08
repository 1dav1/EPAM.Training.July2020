using ResultClassLibrary.Interfaces;
using System;

namespace BinaryTree
{
    public class BinaryTree<T, U> where T : IGrade<U>
    {
        private class Node
        {
            public Node(T grade)
            {

            }
        }
    }
}
