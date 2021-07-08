using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class tree
    {
        public node Root { get; set; }
        private node Current { get; set; }
        
        public tree(dynamic _Data = null){
            //New tree - Sets the Root of the tree to a new node
            Root = new node(_Data);
        }

        public void Add(dynamic _Data){
            //If the Root of the List is not set.
            if (Root.Data == null)
            {
                Root.Data = _Data;
                return;
            }else{
                Current = Root;
            }

            //traverse through the tree to the relevant point at which the item should be added
            while(true){
                var temp = Traverse(_Data, Current);

                //If it is null, we are at a leaf node and we can stop traversing the tree 
                if (temp == null)
                {
                    break;
                }
                Current = temp;
            }

            //Check whether we need to add the node to the left or right of 
            if (_Data < Current.Data)
            {
                Current.SetLeft(new node(_Data, Current));
            }else{
                Current.SetRight(new node(_Data, Current));
            }
              
            
        }
        
        private node Traverse(dynamic _Data, node _Current){
            //Check whether to branch to the right or the left in the tree.
            if (_Data < _Current.Data)
            {
                return _Current.GetLeft();
            }
            return _Current.GetRight();
        }

        public bool Delete(dynamic _Data){
            //Traverse to the node we are trying to delete
            Current = Root;
            //try statement will run unless the node does not exitst, in which case it will throw an exception and return false.
            try
            {
                while(true){

                    if (_Data != Current.Data)
                    {

                        Current = Traverse(_Data, Current);

                    }else{

                        break;

                    }
                    
                }
            }
            catch (System.Exception)
            {
                //If it can't be found, return false
                 return false;
            }

            if (Current.GetLeft() != null && Current.GetRight() != null)
            {
                //If it has 2 children
                node temp = Current.GetLeft();

                //Traverse to node that will replace Current
                while(true){
                    if (temp.GetRight() != null)
                    {
                        temp = temp.GetRight();
                    }else{
                        break;
                    }
                }

                Current.Data = temp.Data;
                
                //Find if the temp node is a left or a right now before deleting. 


                if(temp.GetParent() == Current){
                    //If the current node is parent to our replacing node. (Only 1 level down)
                    Current.SetLeft(temp.GetLeft());
                }else{
                    //If we could traverse down the left hand side
                    if (temp.GetLeft() != null)
                    {
                        temp.GetParent().SetRight(temp.GetLeft());
                    }else{
                        temp.GetParent().SetRight(null);
                    }
                }
                //*Code not currently working - Doesn't confidently replace the root or parent nodes of each item that is deleted
                // temp.SetParent(Current.GetParent());
                // if (Current.GetParent() == null)
                // {
                //     Root = Current;
                // }
                return true;


            }else if(Current.GetLeft() != null || Current.GetRight() != null)
            {

                bool LeftFlag = false;

                if (Current == Root)
                {
                    if (Current.GetLeft() != null)
                    {
                        Root = Current.GetLeft();
                    }else{
                        Root = Current.GetRight();
                    }
                }

                if (Current == Root || Current.Data < Current.GetParent().Data)
                {
                    LeftFlag = true;
                }

                if (Current.GetLeft() != null)
                {//If it has a left child
                    if (LeftFlag == true)
                    {
                        Current.GetParent().SetLeft(Current.GetLeft());
                    }else{
                        Current.GetParent().SetRight(Current.GetLeft());
                    }
                }else{//If it has a right child
                    if (LeftFlag == true)
                    {
                        Current.GetParent().SetLeft(Current.GetRight());
                    }else{
                        Current.GetParent().SetRight(Current.GetRight());
                    } 
                }

                return true;


            }else{

                //If it has no children
                if (Current.Data <= Current.GetParent().Data)
                {
                    Current.GetParent().SetLeft(null);
                    return true;
                }else{
                    Current.GetParent().SetRight(null);
                    return true;
                }

            }
            
        }












        
        //print Method functions
		public void Print(node root, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<node>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new node { Data = next.Data.ToString(" 0 ") };
                item.SetLeft(next.GetLeft());
                item.SetRight(next.GetRight());
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.SetParent(last[level - 1]);
                    if (next == item.GetParent().GetLeft())
                    {
                        item.GetParent().SetLeft(item);
                        item.EndPos = Math.Max(item.EndPos, item.GetParent().StartPos);
                    }
                    else
                    {
                        item.GetParent().SetRight(item);
                        item.StartPos = Math.Max(item.StartPos, item.GetParent().EndPos);
                    }
                }
                next = next.GetLeft() ?? next.GetRight();
                for (; next == null; item = item.GetParent())
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.GetParent().GetLeft())
                    {
                        item.GetParent().StartPos = item.EndPos;
                        next = item.GetParent().GetRight();
                    }
                    else
                    {
                        if (item.GetParent().GetLeft() == null)
                            item.GetParent().EndPos = item.StartPos;
                        else
                            item.GetParent().StartPos += (item.StartPos - item.GetParent().EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private void Print(node item, int top)
        {
            SwapColors();
            Print(item.Data, top, item.StartPos);
            SwapColors();
            if (item.GetLeft() != null)
                PrintLink(top + 1, "┌", "┘", item.GetLeft().StartPos + item.GetLeft().Size / 2, item.StartPos);
            if (item.GetRight() != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.GetRight().StartPos + item.GetRight().Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
        
    }
}