
namespace Binary_Search_Tree
{
    /// <summary>
    /// Node on the Binary Search Tree
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Integer Value of the Node
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Left Child Node
        /// </summary>
        public Node LeftNode { get; set; }

        /// <summary>
        /// Right Child Node
        /// </summary>
        public Node RightNode { get; set; }

        public Node(int value)
        {
            this.Value = value;
        }
    }
}
