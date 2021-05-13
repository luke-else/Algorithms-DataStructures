using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class LinkedList
    {

        public Node Head { get; set; }
        public Node Current { get; set; }
        public Node Tail { get; set; }


        //Class Constructors -----------------------------------------------

        public LinkedList()
        {
            Head = new Node(null);
            Tail = Head;
        }

        public LinkedList(dynamic data)
        {
            Head = new Node(data);
            Tail = Head;
        }
        //-----------------------------------------------------------------


        public void AddItem(dynamic data)
        {
            //Creates a new object and attatches it as the tail of the list. 
            Node newNode = new Node(data, Tail);
            Tail.setNewNextNode(newNode);
            Tail = newNode;

        }


        public void AddItemInOrder(dynamic data)
        {

            Node newItem;


            //I have added this try statement so that if the user enters a value that is not comparable, then it goes straight to the tail
            //As well as this, if any of the items in the list are not comparable, the value we are trying to add will also go to the tail
            try
            {

                //Check if the data is smaller than the Head
                if (data <= Head.Data)
                {

                    newItem = new Node(data, null, Head);
                    Head.setNewPreviousNode(newItem);
                    Head = newItem;

                    return;

                }
                else
                {

                    Current = Head;
                    //checks to ensure the head isn't the only item in the list
                    if (Current.getNextNode() != null)
                    {

                        //Itterate throught the list to see if the new node belongs in any of the positions
                        do
                        {
                            Current = Current.getNextNode();

                            if (data <= Current.Data)
                            {
                                newItem = new Node(data, Current.getPreviousNode(), Current);
                                Current.getPreviousNode().setNewNextNode(newItem);
                                Current.setNewPreviousNode(newItem);

                                return;
                            }



                        } while (Current.getNextNode() != null);
                    }

                    //Append the new node onto the end of the list
                    AddItem(data);


                }

            }
            catch (Exception)
            {
                //If the data is not sortable, then it will just be appended to the end of the list.
                AddItem(data);

            }


        }


        public dynamic getItemData(int index)
        {

            Current = getItem(index);

            //Checks to see if there was actally a value placed into the list
            if (Current == null)
            {
                return "Index out of Bounds";
            }
            else
            {
                if (Current.Data == null)
                {
                    return "null";
                }
                else
                {
                    return Current.Data;
                }
            }
        }

        public Node getItem(int index)
        {
            Current = Head;

            //Itterate through the loop until we can set the current item to nth item in the list
            for (var i = 0; i < index; i++)
            {
                //If we have reached the end and can't go further...
                if (Current.getNextNode() != null)
                {
                    Current = Current.getNextNode();
                }
                else
                {
                    return null;
                }

            }

            return Current;
        }

        public void removeItem(int index)
        {
            Current = getItem(index);

            //only execute it if the item is actuall valid;
            if (Current != null)
            {

                

                

                //If the item is at the end of the list
                if (Current.getNextNode() == null)
                {
                    //set the previous node as tail.
                    Tail = Current.getPreviousNode();
                    Tail.setNewNextNode(null);
                }
                else
                {
                    //Set the next nodes previous pointer to the previous item.
                    Current.getNextNode().setNewPreviousNode(Current.getPreviousNode());
                }

                //If the item is at the start of the list
                if (Current.getPreviousNode() == null)
                {
                    Head = Current.getNextNode();
                    Head.setNewPreviousNode(null);
                }
                else
                {
                    //Set the previous items pointer to the next item.
                    Current.getPreviousNode().setNewNextNode(Current.getNextNode());
                }

            }

            
        }


        public void printList()
        {
            Current = Head;

            do
            {
                //check to see if the data is null
                if (Current.Data == null)
                {
                    Console.Write("null" + "-->");
                }
                else
                {
                    Console.Write(Current.Data + "-->");
                }

                Current = Current.getNextNode();

                //In this piece of code, we iterate onto the next item at the end of the loop in order to allow the head to be the first item.
                //This means that we have to check for the current item being the end of the list as opposed to the next item being the end.

            } while (Current != null);

            Console.Write("null \n");
        }



        public void printListReverse()
        {
            //Start from the tail and itterate backwards
            Current = Tail;

            do
            {
                //check to see if the data is null
                if (Current.Data == null)
                {
                    Console.Write("null" + "-->");
                }
                else
                {
                    Console.Write(Current.Data + "-->");
                }

                Current = Current.getPreviousNode();

                //In this piece of code, we iterate onto the previous item at the end of the loop in order to allow the tail to be the first item.
                //This means that we have to check for the current item being the start of the list as opposed to the next item being the start.

            } while (Current != null);

            Console.Write("null \n");
        }


        

    }
}
