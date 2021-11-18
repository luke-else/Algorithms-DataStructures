namespace BinaryTree
{
    public class node
    {
        public dynamic Data { get; set; }
        private node Parent { get; set; }
        private node Left { get; set; }
        private node Right { get; set; }


        //Print Method Data
        public int StartPos;
        public int Size { get { return Data.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }


        public node(dynamic data = null,
                    node parent = null, 
                    node left = null, 
                    node right = null){

            //New node for a Binary Tree. Values can be set to null if they are not present
            Data = data;
            Parent = parent;
            Left = left;
            Right = right;

        }

        public node GetParent(){
            return Parent;
        }
        public void SetParent(node parent){
            Parent = parent;
        }

        public node GetLeft(){
            return Left;
        }
        public void SetLeft(node left){
            Left = left;
        }

        public node GetRight(){
            return Right;
        }        
        public void SetRight(node right){
            Right = right;
        }

    }
}