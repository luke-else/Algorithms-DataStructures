using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.AddItemInOrder(2);
            list.AddItemInOrder(5);
            list.AddItemInOrder("Test");
            list.AddItemInOrder("5");

            list.printList();

            Console.ReadLine();
        }
    }
}
