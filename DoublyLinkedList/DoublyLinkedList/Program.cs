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
            LinkedList list = new LinkedList(50);

            list.AddItemInOrder(2);
            list.AddItemInOrder(3);
            list.AddItemInOrder(0);
            list.AddItemInOrder(20);
            list.AddItemInOrder(2.56);
            list.AddItemInOrder(-5);

            list.printList();
            list.printListReverse();
            Console.WriteLine(list.getItemData(0));
            Console.WriteLine(list.getItemData(1));
            Console.WriteLine(list.getItemData(3));
            Console.WriteLine(list.getItemData(7));

            list.removeItem(2);
            list.printList();

            list.removeItem(0);
            list.printList();

            list.removeItem(4);
            list.printList();

            Console.ReadLine();
        }
    }
}
