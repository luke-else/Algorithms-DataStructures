using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            tree tree = new tree();
            tree.Add(5);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(3);
            tree.Add(1);
            tree.Add(4);
            tree.Add(0.5);

            tree.Delete(1);

            Console.ReadLine();

        }
    }
}
