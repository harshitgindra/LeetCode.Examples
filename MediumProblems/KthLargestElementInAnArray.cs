namespace LeetCode.MediumProblems;

/// <summary>
/// https://leetcode.com/problems/kth-largest-element-in-an-array/
/// </summary>
public class KthLargestElementInAnArray
{
    public int FindKthLargest(int[] nums, int k) {
        var heap = new PriorityQueue<int, int>();
        foreach (int num in nums) {
            heap.Enqueue(num, num);
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }
        return heap.Peek();
    }
}