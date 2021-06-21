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

        public node GetLeft(){
            return Left;
        }
        public void SetLeft(dynamic _Data, node _Parent){
            Left = new node(_Data, _Parent);
        }



        public node GetRight(){
            return Right;
        }        
        public void SetRight(dynamic _Data, node _Parent){
            Right = new node(_Data, _Parent);
        }


    }
}