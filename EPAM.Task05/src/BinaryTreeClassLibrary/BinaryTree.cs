using ResultClassLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace BinaryTreeClassLibrary
{
    [Serializable]
    public class BinaryTree<T, U> where T : IGrade<U>
    {
        [Serializable]
        public class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }

            // each node stores collection of grades of the same value
            public List<T> Grades { get; set; }
            public Node() { Grades = new List<T>(); }
        }

        public Node Root { get; set; }

        public void Add(T grade)
        {
            if (grade is null)
                throw new ArgumentNullException();

            Node node = new Node();
            node.Grades.Add(grade);
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Root = Insert(Root, node);
            }
        }

        private Node Insert(Node current, Node node)
        {
            if (current == null)
            {
                current = node;
                return current;
            }

            if ((dynamic)node.Grades[0].Grade is char)
            {
                if ((dynamic)node.Grades[0].Grade > current.Grades[0].Grade)
                {
                    current.LeftNode = Insert(current.LeftNode, node);
                    current = Balance(current);
                }
                else if ((dynamic)node.Grades[0].Grade < current.Grades[0].Grade)
                {
                    current.RightNode = Insert(current.RightNode, node);
                    current = Balance(current);
                }
                else if ((dynamic)node.Grades[0].Grade == current.Grades[0].Grade)
                {
                    current.Grades.Add(node.Grades[0]);
                }
            }
            else
            {
                if ((dynamic)node.Grades[0].Grade < current.Grades[0].Grade)
                {
                    current.LeftNode = Insert(current.LeftNode, node);
                    current = Balance(current);
                }
                else if ((dynamic)node.Grades[0].Grade > current.Grades[0].Grade)
                {
                    current.RightNode = Insert(current.RightNode, node);
                    current = Balance(current);
                }
                else if ((dynamic)node.Grades[0].Grade == current.Grades[0].Grade)
                {
                    current.Grades.Add(node.Grades[0]);
                }

            }
            return current;
        }

        // balancing the tree
        private Node Balance(Node node)
        {
            int balanceFactor = GetBalanceFactor(node);
            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(node.LeftNode) > 0)
                {
                    node = RotateLeftLeft(node);
                }
                else
                {
                    node = RotateLeftRight(node);
                }
            }
            else if (balanceFactor < -1)
            {
                if (GetBalanceFactor(node.RightNode) > 0)
                {
                    node = RotateRightLeft(node);
                }
                else
                {
                    node = RotateRightRight(node);
                }
            }
            return node;
        }

        private int GetBalanceFactor(Node node)
        {
            int leftHeight = GetHeight(node.LeftNode);
            int rightHeight = GetHeight(node.RightNode);
            return leftHeight - rightHeight;
        }

        // getting the height of the node
        private int GetHeight(Node node)
        {
            int height = 0;
            if (node != null)
            {
                int leftHeight = GetHeight(node.LeftNode);
                int rightHeight = GetHeight(node.RightNode);
                int maxHeight = Math.Max(leftHeight, rightHeight);
                height = maxHeight + 1;
            }
            return height;
        }

        // rotating the tree relative the left node
        private Node RotateLeftLeft(Node node)
        {
            Node pivot = node.LeftNode;
            node.LeftNode = pivot.RightNode;
            pivot.RightNode = node;
            return pivot;
        }

        // rotating the tree relative the left node and shifting to the right
        private Node RotateLeftRight(Node node)
        {
            Node pivot = node.LeftNode;
            node.LeftNode = RotateRightRight(pivot);
            return RotateLeftLeft(node);
        }

        // rotating the tree relative the right node
        private Node RotateRightRight(Node node)
        {
            Node pivot = node.RightNode;
            node.RightNode = pivot.LeftNode;
            pivot.LeftNode = node;
            return pivot;
        }

        // rotating the tree relative to the right node and shifting to the left
        private Node RotateRightLeft(Node node)
        {
            Node pivot = node.RightNode;
            node.RightNode = RotateLeftLeft(pivot);
            return RotateRightRight(node);
        }

        private T Find(T grade, Node parent)
        {
            if (parent != null)
            {
                if ((dynamic)grade.Grade == parent.Grades[0].Grade)
                {
                    return parent.Grades.Find(g => g.Name == grade.Name);
                }

                if ((dynamic)grade.Grade < parent.Grades[0].Grade)
                    return Find(grade, parent.LeftNode);
                else
                    return Find(grade, parent.RightNode);
            }
            return default;
        }

        // searching for the specified grade
        public T Find(T grade)
            => Find(grade, Root);
    }
}
