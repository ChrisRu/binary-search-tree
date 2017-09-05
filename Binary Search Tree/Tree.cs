
namespace Binary_Search_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Binary Search Tree
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// Spaces of indentation in the console between children
        /// </summary>
        public const int IndentationSize = 5;

        /// <summary>
        /// Root Node of the Binary Search Tree
        /// </summary>
        public Node RootNode { get; set; }

        /// <summary>
        /// Add a value to the Tree in the right place
        /// </summary>
        /// <param name="value">Value of the new Node</param>
        public void Insert(int value)
        {
            this.Insert(value, this.RootNode);
        }

        /// <summary>
        /// Add multiple values to the Tree in the right place
        /// </summary>
        /// <param name="values">Values of the new Nodes</param>
        public void Insert(List<int> values)
        {
            values.ForEach(this.Insert);
        }

        /// <summary>
        /// Find Node by value
        /// </summary>
        /// <param name="value">Value to find</param>
        /// <returns>Found node</returns>
        public Node Search(int value)
        {
            return this.Search(value, this.RootNode);
        }

        /// <summary>
        /// Traverse the Tree and print its values to the Console
        /// </summary>
        public void Print()
        {
            this.Print(this.RootNode);
        }

        /// <summary>
        /// Get maximum Treed depth
        /// </summary>
        /// <returns>Maximum Tree depth</returns>
        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.RootNode);
        }

        /// <summary>
        /// Add a value to the Tree in the right place
        /// </summary>
        /// <param name="value">Value of the new Node</param>
        /// <param name="startNode">Current Node to go left or right on</param>
        /// <returns>Value of the new Node</returns>
        private int Insert(int value, Node startNode)
        {
            if (this.RootNode == null)
            {
                this.RootNode = new Node(value);
                return value;
            }

            bool isLeftNode = startNode.Value >= value;
            Node node = isLeftNode ? startNode.LeftNode : startNode.RightNode;

            if (node != null)
            {
                return this.Insert(value, node);
            }
            else
            {
                if (isLeftNode)
                {
                    startNode.LeftNode = new Node(value);
                }
                else
                {
                    startNode.RightNode = new Node(value);
                }

                return value;
            }
        }

        /// <summary>
        /// Find Value in Tree
        /// </summary>
        /// <param name="value">Value to find</param>
        /// <param name="startNode">Node to go left or right on</param>
        /// <returns>Found node</returns>
        private Node Search(int value, Node startNode)
        {
            if (startNode.Value == value)
            {
                return startNode;
            }

            Node node = startNode.Value > value ? startNode.LeftNode : startNode.RightNode;

            if (node != null)
            {
                return this.Search(value, node);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Find maximum Tree depth
        /// </summary>
        /// <param name="startNode">Node to go left and right on</param>
        /// <param name="depth">Current depth</param>
        /// <returns>Maximum Tree depth</returns>
        private int GetTreeDepth(Node startNode, int depth = 0)
        {
            int newDepth = depth;

            if (startNode != null)
            {
                int leftDepth = this.GetTreeDepth(startNode.LeftNode, depth + 1);
                int rightDepth = this.GetTreeDepth(startNode.RightNode, depth + 1);

                newDepth = Math.Max(leftDepth, rightDepth);
            }

            return newDepth;
        }

        /// <summary>
        /// Traverse all values in the tree and print them to the console
        /// </summary>
        /// <param name="startNode">Node to go left and right on</param>
        /// <param name="smaller">Is the value smaller or bigger than its ParentNode</param>
        /// <param name="indent">Indentation Size</param>
        private void Print(Node startNode, bool smaller = false, int indent = 0)
        {
            if (startNode != null)
            {
                this.PrintValue(startNode.Value, smaller, indent);

                this.Print(startNode.LeftNode, true, indent + IndentationSize);
                this.Print(startNode.RightNode, false, indent + IndentationSize);
            }
        }

        /// <summary>
        /// Print a value of the tree to the Console
        /// </summary>
        /// <param name="value">Value to print</param>
        /// <param name="smaller">Is the value smaller or bigger than its ParentNode</param>
        /// <param name="indent">Indentation Size</param>
        private void PrintValue(int value, bool smaller, int indent)
        {
            string indentString = string.Empty;
            for (int i = 0; i < indent; i += IndentationSize)
            {
                indentString += string.Concat(Enumerable.Repeat(" ", IndentationSize)) + "|";
            }

            Console.WriteLine(indentString + (smaller ? "> " : "< ") + value);
        }
    }
}
