namespace LeetCode.MediumProblems;
/// <summary>
/// https://leetcode.com/problems/kth-largest-element-in-a-stream/
/// </summary>
public class KthLargest
{
    private readonly PriorityQueue<int, int> priorityQueue = new();
    private readonly int _k = 1;

    public KthLargest(int k, int[] nums) {
        _k = k;
        foreach (var v in nums)
            Add(v);
    }
    
    public int Add(int val) {
        priorityQueue.Enqueue(val, val);
        if (priorityQueue.Count > _k)
            priorityQueue.Dequeue();
        return priorityQueue.Peek();
    }
}