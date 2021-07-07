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
                //Adopt subtree Nodes// -- Subtrees are lost (If temp node is only 1 level down, data is lost)
                // if (temp.GetLeft() != null)
                // {
                //     temp.GetParent().SetRight(temp.GetLeft());
                // }else{
                //     temp.GetParent().SetRight(null);
                // }


                if(temp.GetParent() == Current){
                    Current.SetLeft(null);
                }else{
                    Current.SetLeft(temp.GetLeft());
                }
                return true;


            }else if(Current.GetLeft() != null)
            {
                //If it has a left child
                Current.Data = Current.GetLeft().Data;
                Current.SetLeft(null);
                return true;


            }else if(Current.GetRight() != null){

                //If it has a right child
                Current.Data = Current.GetRight().Data;
                Current.SetRight(null);
                return true;

            }else{

                //If it has no children
                if (Current.Data < Current.GetParent().Data)
                {
                    Current.GetParent().SetLeft(null);
                    return true;
                }else{
                    Current.GetParent().SetRight(null);
                    return true;
                }

            }
            
        }
        
    }
}