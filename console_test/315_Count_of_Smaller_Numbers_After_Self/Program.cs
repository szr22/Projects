using System;
using System.Collections.Generic;
using System.Linq;

namespace _315_Count_of_Smaller_Numbers_After_Self
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = { 5, 2, 6, 1 };
            List<int> res = sol.CountSmaller(nums).ToList();
            foreach (int num in res)
            {
                Console.WriteLine(num);
            }
        }
    }

    public class Solution
    {
        public IList<int> CountSmaller(int[] nums)
        {
            List<int> res = new List<int>();
            if (nums == null || nums.Length == 0)
            {
                return res;
            }
            int n = nums.Length;
            BinaryIndexedTree bitTree = new BinaryIndexedTree(new int[n]);
            List<int> copyNums = new List<int>(nums);
            copyNums.Sort();
            for (int i = n - 1; i >= 0; i--)
            {
                int num = nums[i];
                int idx = copyNums.BinarySearch(num);
                res.Insert(0, bitTree.Sum(idx));
                bitTree.Add(idx + 1, 1);
            }

            return res;
        }
    }

    public class BinaryIndexedTree
    {
        int[] bit;
        public BinaryIndexedTree(int[] arr)
        {
            int n = arr.Length;
            bit = new int[n + 1];
            for(int i=0; i< arr.Length; i++)
            {
                Add(i, arr[i]);
            }
        }

        public void Update(int index, int val)
        {
            int num = index == 0 ? Sum(index) : Sum(index) - Sum(index - 1);
            Add(index, val - num);
        }

        public int Sum(int index)
        {
            int i = index + 1, sum = 0;
            while (i > 0)
            {
                sum += bit[i];
                i -= LBS(i);
            }

            return sum;
        }

        public void Add(int index, int val)
        {
            var i = index + 1;
            while (i < bit.Length)
            {
                bit[i] += val;
                i += LBS(i);
            }
        }

        public int LBS(int n)
        {
            return (n & -n);
        }
    }
}