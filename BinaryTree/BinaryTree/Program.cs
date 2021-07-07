using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            tree tree = new tree();

            Random random = new Random();

            for (var i = 0; i < 1000; i++)
            {
                tree.Add(random.Next(0, 10000));
            }
            
            
            

            tree.Delete(tree.Root.Data);

            Console.ReadLine();

        }
    }
}
