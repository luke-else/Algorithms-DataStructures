package main

import (
	"fmt"
	"math/rand"
	"strconv"
	"time"
)

func main() {
	//list := []int{1, 2, 3, 4, 5, 6, 7}

	//x := RecursiveBinarySearch(list, getVal(), 0, len(list)-1)

	//fmt.Println(x)

	testTimed(10000000)
}

func RecursiveBinarySearch(list *[]int, value int, start int, end int) int {
	var mid int = (start + end) / 2

	if start == (end - 1) {
		if (*list)[mid] == value {
			return mid
		}
		return -1
	}

	if value < (*list)[mid] {
		return RecursiveBinarySearch(list, value, start, mid)
	}
	return RecursiveBinarySearch(list, value, mid, end)

}

func getVal() (value int) {

	var input string

	fmt.Println("What value would you like to find in the list:")
	fmt.Scan(&input)

	value, err := strconv.Atoi(input)

	if err != nil {
		fmt.Println("Invalid Input")
		return getVal()
	}

	return
}

func generateList(value int) (list []int) {

	for i := 1; i <= value; i++ {
		list = append(list, i)
	}
	return
}

func generateRandomList(value int) (list []int) {
	for i := 1; i <= value; i++ {
		list = append(list, rand.Intn(value))
	}
	return
}

func testTimed(value int) {

	const mult int = 1000000

	for i := 1; i <= value; i++ {

		start := time.Now()

		list := generateRandomList(i * mult)
		list = mergeSort(list, 0, len(list)-1)

		rnd := rand.Intn(i*mult) + 1

		x := RecursiveBinarySearch(&list, rnd, 0, len(list)-1)

		//fmt.Println(time.Now().Sub(start), x, i*1000, "items")
		fmt.Println("found number ", rnd, ":", x, " in a list of ", len(list), " items in ", time.Since(start))
	}
}

func mergeSort(nums []int, start int, end int) []int {
	if start == end {
		return []int{nums[start]}
	}

	var mid int = ((end - start) / 2) + start

	//Assign values back into Left and right
	left := mergeSort(nums, start, mid)
	right := mergeSort(nums, mid+1, end)

	var combined []int

	//Pointers for new array
	leftPointer, rightPointer := 0, 0

	for leftPointer <= len(left)-1 || rightPointer <= len(right)-1 {

		if leftPointer == len(left) {
			addValue(&combined, right[rightPointer], &rightPointer)
		} else if rightPointer == len(right) {
			addValue(&combined, left[leftPointer], &leftPointer)
		} else {
			if left[leftPointer] <= right[rightPointer] {
				addValue(&combined, left[leftPointer], &leftPointer)
			} else {
				addValue(&combined, right[rightPointer], &rightPointer)
			}
		}
	}
	return combined
}

func addValue(nums *[]int, value int, pointer *int) {
	*nums = append(*nums, value)
	*pointer++
}
