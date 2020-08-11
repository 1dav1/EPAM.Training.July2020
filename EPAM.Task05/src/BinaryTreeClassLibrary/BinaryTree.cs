using ResultClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BinaryTreeClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="binarytree"]/BinaryTree/*'/>
    [Serializable]
    public class BinaryTree<T, U> where T : IGrade<U>
    {
        /// <include file='docs.xml' path='docs/members[@name="node"]/Node/*'/>
        [Serializable]
        public class Node
        {
            /// <include file='docs.xml' path='docs/members[@name="node"]/LeftNode/*'/>
            public Node LeftNode { get; set; }

            /// <include file='docs.xml' path='docs/members[@name="node"]/RightNode/*'/>
            public Node RightNode { get; set; }

            // each node stores collection of grades of the same value
            /// <include file='docs.xml' path='docs/members[@name="node"]/Grades/*'/>
            public List<T> Grades { get; set; }

            /// <include file='docs.xml' path='docs/members[@name="node"]/Constructor/*'/>
            public Node() { Grades = new List<T>(); }
        }

        /// <include file='docs.xml' path='docs/members[@name="binarytree"]/Root/*'/>
        public Node Root { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="binarytree"]/Add/*'/>
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
        /// <include file='docs.xml' path='docs/members[@name="binarytree"]/Find/*'/>
        public T Find(T grade)
            => Find(grade, Root);

        /// <include file='docs.xml' path='docs/members[@name="binarytree"]/DisplayTree/*'/>
        public void DisplayTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Empty");
                return;
            }
            InOrderDisplay(Root);
            Console.WriteLine();
        }

        private void InOrderDisplay(Node node)
        {
            if (node != null)
            {
                InOrderDisplay(node.LeftNode);
                Console.WriteLine("{0}:", node.Grades[0].Grade);
                foreach (var grade in node.Grades)
                {
                    Console.Write("{0}, ", grade.Name);
                }
                Console.WriteLine();
                InOrderDisplay(node.RightNode);
            }
        }

        /// <include file='docs.xml' path='docs/members[@name="binarytree"]/Serialize/*'/>
        public void Serialize(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BinaryTree<T, U>));
            using FileStream stream = File.Open(file, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            serializer.Serialize(stream, this);
        }

        /// <include file='docs.xml' path='docs/members[@name="binarytree"]/Deserialize/*'/>
        public static BinaryTree<T, U> Deserialize(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BinaryTree<T, U>));
            using FileStream stream = File.OpenRead(file);
            BinaryTree<T, U> tree = (BinaryTree<T, U>)serializer.Deserialize(stream);
            return tree;
        }
    }
}
