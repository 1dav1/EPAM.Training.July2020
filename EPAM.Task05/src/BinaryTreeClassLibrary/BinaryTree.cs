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
