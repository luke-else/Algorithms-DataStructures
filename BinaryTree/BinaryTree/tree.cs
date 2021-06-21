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
                Current.SetLeft(_Data, Current);
            }else{
                Current.SetRight(_Data, Current);
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
        
        
    }
}