using ResultClassLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTree<T, U> where T : IGrade<U>
    {
        private class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }

            // each node stores information about students that have the same grade
            public List<T> Grades { get; set; }
            public Node() { Grades = new List<T>(); }
        }

        private Node Root { get; set; }

        public bool Add(T grade)
        {
            Node beforeNode = null;
            Node afterNode = Root;
            while (afterNode != null)
            {
                beforeNode = afterNode;

                if ((dynamic)grade.Grade < afterNode.Grades[0].Grade)
                {
                    afterNode = afterNode.LeftNode;
                }
                else if ((dynamic)grade.Grade > afterNode.Grades[0].Grade)
                {
                    afterNode = afterNode.RightNode;
                }
                else if ((dynamic)grade.Grade == afterNode.Grades[0].Grade)
                {
                    afterNode.Grades.Add(grade);
                }
                else
                {
                    return false;
                }
            }

            Node node = new Node();
            node.Grades.Add(grade);

            if (Root == null)
                Root = node;
            else
            {
                if ((dynamic)grade.Grade < beforeNode.Grades[0].Grade)
                    beforeNode.LeftNode = node;
                else
                    beforeNode.RightNode = node;
            }
            return true;
        }

        private Node Insert(Node current, Node node)
        {
            if (current == null)
            {
                current = node;
                return current;
            }
            else if ((dynamic)node.Grades[0].Grade < current.Grades[0].Grade)
            {
                current.LeftNode = Insert(current.LeftNode, node);
                current = Balance(current);
            }
            else if ((dynamic)node.Grades[0].Grade > current.Grades[0].Grade)
            {
                current.RightNode = Insert(current.RightNode, node);
                current = Balance(current);
            }
            return current;
        }

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

        private Node RotateLeftLeft(Node node)
        {
            Node pivot = node.LeftNode;
            node.LeftNode = pivot.RightNode;
            pivot.RightNode = node;
            return pivot;
        }

        private Node RotateLeftRight(Node node)
        {
            Node pivot = node.LeftNode;
            node.LeftNode = RotateRightRight(pivot);
            return RotateLeftLeft(node);
        }

        private Node RotateRightRight(Node node)
        {
            Node pivot = node.RightNode;
            node.RightNode = pivot.LeftNode;
            pivot.LeftNode = node;
            return pivot;
        }

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
                    T searchGrade = parent.Grades.Find(g => g.Name == grade.Name);
                    return searchGrade;
                }

                if ((dynamic)grade.Grade < parent.Grades[0].Grade)
                    return Find(grade, parent.LeftNode);
                else
                    return Find(grade, parent.RightNode);
            }
            return default;
        }

        public T Find(T grade)
            => Find(grade, Root);

    }
}
