using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSort
    {

        public int[] Sort(int[] List){

            if(List.Length <= 1) return List;

            int pivot = 0;

            int left = 1;

            int right = List.Length - 1;

            while (right >= left)
            {
                while (left <= right && List[left] <= pivot)
                {
                    left++;
                }
                while (right >= left && List[right] >= List[pivot])
                {
                    right--;
                }
                if (right > left)
                {
                    //Swap the values of the pointers as well!!!
                    swap(ref List, ref right, ref left);
                }
                //Might be
                swap(ref List, ref pivot, ref right);
                
                
                
            }
            int[] leftHalf = new int[right + 1];
            for (var i = 0; i <= right; i++)
            {
                leftHalf[i] = List[i];
            }
            leftHalf = Sort(leftHalf);

            int[] rightHalf = new int[List.Length - right - 1];
            for (var i = 0; i <= right; i++)
            {
                rightHalf[i] = List[i];
            }
            rightHalf = Sort(rightHalf);
            
            int[] newList = new int[/*leftHalf.Length + rightHalf.Length*/ List.Length];
            for (var i = 0; i < leftHalf.Length; i++)
            {
                newList[i] = leftHalf[i];
            }
            
            newList[leftHalf.Length + 1] = List[right];

            for (var i = 0; i < rightHalf.Length; i++)
            {
                newList[i + leftHalf.Length] = rightHalf[i];
            }
            return newList;

        }


        public void swap(ref int[] List, ref int pointer1, ref int pointer2){
            int temp = List[pointer1];
            //Assign both the value and index
            //Pointer1
            List[pointer1] = List[pointer2];
            //pointer1 = pointer2;
            //Pointer2
            List[pointer2] = temp;
            //pointer2 = temp;
        }
    }

    public class Pointer{
        public int Index { get; set; }
        public int Value { get; set; }
        

        public Pointer(int index, int value){
            this.Index = index;
            this.Value = value;
        }

        public void UpdatePointer(int index, int value){
            this.Index = index;
            this.Value = value;
        }
    }
}