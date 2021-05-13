using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Node
    {
        public dynamic Data { get; set; } = null;
        private Node Next { get; set; } = null;
        private Node Previous { get; set; } = null;


        //Class Constructors for each Node -----------------
        public Node(dynamic _Data)
        {
            Data = _Data;
        }

        public Node(dynamic _Data, Node _Previous)
        {
            Data = _Data;
            Previous = _Previous;
        }

        public Node(dynamic _Data, Node _Previous, Node _Next)
        {
            Data = _Data;
            Previous = _Previous;
            Next = _Next;
        }
        //--------------------------------------------------


        public void setNewPreviousNode(Node _Previous)
        {
            Previous = _Previous;
        }

        public Node getPreviousNode()
        {
            return Previous;
        }

        public void setNewNextNode(Node _Next)
        {
            Next = _Next;
        }

        public Node getNextNode()
        {
            return Next;
        }
    }
}
