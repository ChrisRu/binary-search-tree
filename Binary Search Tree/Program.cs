
namespace Binary_Search_Tree
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Initialize the application
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Insert(new List<int> { 5, 8, 2, 10, 1, 40, 7, 6, 3, 4, 69 });
            tree.Insert(9);
            tree.Print();

            const int FindValue = 6;
            int treeDepth = tree.GetTreeDepth();
            Node findNode = tree.Search(FindValue);
            string correctSearch = (findNode != null && findNode.Value == FindValue) ? "yes!" : "no :(";

            Console.WriteLine();
            Console.WriteLine($"Tree depth: {treeDepth}");
            Console.WriteLine();
            Console.WriteLine($"Searched for value: {FindValue}. Found value: {correctSearch}");
            Console.WriteLine();
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
