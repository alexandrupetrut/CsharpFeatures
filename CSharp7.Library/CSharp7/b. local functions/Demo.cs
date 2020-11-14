using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.Library.CSharp7.b._local_functions
{
    class Demo
    {
        public static void Main()
        {
            Console.WriteLine(@"Tree:
            4
          /   \
         2     6
        / \   / \
       1   3 5   7
            ");

            var tree = new Tree(4,
                                new Tree(2, new Tree(1), new Tree(3)),
                                new Tree(6, new Tree(5), new Tree(7))
                                );
            Console.WriteLine("Print in pre order: ");          
        }
    }

    class Tree
    {
        public int Value { get; }
        private Tree Left { get; }
        private Tree Right { get; }

        public Tree (int value, Tree left = null, Tree right = null)
        {
            Value = value;
            Right = right;
            Left = left;
        }

        private static void PrintValue (Tree tree, string format)
        {
            Console.WriteLine($"{format} ", tree.Value);
        }

        // old way
        public void PrintInPreOrder(string format) => PrintInPreOrder(this, format);
        public void PrintInPreOrder(Tree tree, string format)
        {
            if (tree == null) return;
            PrintValue(tree, format);
            PrintInPreOrder(tree.Left, format);
            PrintInPreOrder(tree.Right, format);
        }

        // old way
        public void PrintInOrder(string format)
        { 
            PrintInOrder(this, format); 
        }
        public void PrintInOrder(Tree tree, string format)
        {
            if (tree == null) return;
            PrintInOrder(tree.Left, format);
            PrintValue(tree, format);
            PrintInOrder(tree.Right, format);
        }

        // new way - local functions that capture elements from root down to latest children
        public void PrintInPostOrder(string format)
        {
            PrintInPostOrder(this);

            void PrintInPostOrder(Tree tree)
            {
                if (tree == null) return;
                PrintInPostOrder(tree.Left);
                PrintInPostOrder(tree.Right);
                PrintValue(tree.Right, format);
            }
        }
    }
}
