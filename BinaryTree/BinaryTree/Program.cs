using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            tree tree = new tree();

            Random random = new Random();

            for (var i = 0; i < 10; i++)
            {
                tree.Add(random.Next(0, 100));
            }

            tree.Print(tree.Root);

            while (true)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Delete node: ");

                tree.Delete(Convert.ToInt32(Console.ReadLine()));

                tree.Print(tree.Root);
            }

        }
    }
}
