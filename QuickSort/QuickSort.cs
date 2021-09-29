using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSort
    {

        public int[] Sort(int[] List){

            Pointer pivot = new Pointer(0, List);

            Pointer left = new Pointer(1, List);

            Pointer right = new Pointer(List.Length-1, List);

            while (right.Index >= left.Index)
            {
                while (left.Index <= right.Index && left.Value <= pivot.Value)
                {
                    left.UpdatePointer(left.Index + 1, List);
                }
                while (right.Index >= left.Index & right.Value >= pivot.Value)
                {
                    right.UpdatePointer(right.Index - 1, List);
                }
                if (right.Index > left.Index)
                {
                    //Swap the values of the pointers as well!!!
                    List = swap(List, right, left);
                }
                //Might be
                List = swap(List, pivot, right);
                
                
                
            }
            int[] leftHalf = new int[right.Index];
            for (var i = 0; i <= right.Index; i++)
            {
                leftHalf[i] = List[i];
            }
            leftHalf = Sort(leftHalf);

            int[] rightHalf = new int[List.Length - right.Index];
            for (var i = 0; i <= right.Index; i++)
            {
                rightHalf[i] = List[i];
            }
            rightHalf = Sort(rightHalf);
            
            int[] newList = new int[leftHalf.Length + rightHalf.Length];
            for (var i = 0; i < leftHalf.Length; i++)
            {
                newList[i] = leftHalf[i];
            }
            for (var i = 0; i < rightHalf.Length; i++)
            {
                newList[i + leftHalf.Length] = rightHalf[i];
            }
            return newList;

        }


        public int[] swap(int[] List, Pointer pointer1, Pointer pointer2){
            Pointer temp = pointer1;
            //Assign both the value and index
            //Pointer1
            List[pointer1.Index] = List[pointer2.Index];
            
            //Pointer2
            List[pointer2.Index] = List[temp.Index];
            return List;
        }
    }

    public class Pointer{
        public int Index { get; set; }
        public int Value { get; set; }
        

        public Pointer(int index, int[] list){
            this.Index = index;
            this.Value = list[index];
        }

        public void UpdatePointer(int index, int[] list){
            this.Index = index;
            this.Value = list[index];
        }
    }
}