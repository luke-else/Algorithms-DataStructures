namespace BinaryTree
{
    public class node
    {
        public dynamic Data { get; set; }
        private node Parent { get; set; }
        private node Left { get; set; }
        private node Right { get; set; }

        public node(dynamic _Data = null,
                    node _Parent = null, 
                    node _Left = null, 
                    node _Right = null){

            //New node for a Binary Tree. Values can be set to null if they are not present
            Data = _Data;
            Parent = _Parent;
            Left = _Left;
            Right = _Right;

        }

        public node GetParent(){
            return Parent;
        }
        public void SetParent(node _Parent){
            Parent = _Parent;
        }

        public node GetLeft(){
            return Left;
        }
        public void SetLeft(node _Left){
            Left = _Left;
        }



        public node GetRight(){
            return Right;
        }        
        public void SetRight(node _Right){
            Right = _Right;
        }


    }
}