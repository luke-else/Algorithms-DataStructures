using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSort
    {
        public int[] List { get; set; }
        
        public QuickSort(int[] List){
            
        }

        public int[] Sort(){

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
                    //Swap the values of both 
                    swap();
                }
            }

            return new int[1]{1};
        }


        public void swap(){
            
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