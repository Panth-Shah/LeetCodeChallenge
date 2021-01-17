using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day16_KthLargestElement
    {
        public int FindKthLargest(int[] nums, int k)
        {
            int start = 0;
            int end = nums.Length - 1;
            int index = nums.Length - k;
            while (start <= end)
            {
                int partitionIndex = parition(nums, start, end);
                if (partitionIndex == index)
                {
                    return nums[index];
                }
                else if (partitionIndex > index)
                {
                    end = partitionIndex - 1;
                }
                else if (partitionIndex < index)
                {
                    start = partitionIndex + 1;
                }
            }
            return nums[start];
        }

        private int parition(int[] nums, int low, int high)
        {
            int pivot = high;
            int i = low;
            int j = high;
            while (i < j)
            {
                while (i < j && nums[i] <= nums[pivot])
                {
                    i++;
                }

                while (i < j && nums[j] >= nums[pivot])
                {
                    j--;
                }

                swap(nums, i, j);
            }
            swap(nums, i, pivot);
            return i;
        }

        private void swap(int[] nums, int i, int j)
        {
            if (i != j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
}
