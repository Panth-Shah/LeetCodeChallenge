using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day11_MergeSortedList
    {
        public void MergeWithNewList(int[] nums1, int m, int[] nums2, int n)
        {
            int[] result = new int[m + n];
            int index = 0;
            int i1 = 0;
            int i2 = 0;
            while (index < m + n && m > 0)
            {
                while (i2 < n)
                {
                    while (nums1[i1] <= nums2[i2] && m > 0)
                    {
                        i1++;
                        index++;
                        m--;
                    }
                    result[index] = nums2[i2];
                    index++;
                    i2++;
                }
                while (m > 0)
                {
                    result[index] = nums1[i1];
                    i1++;
                    index++;
                    m--;
                }
            }
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int l1 = 0;
            int l2 = 0;
            int L = m + n;
            while (l2 < n)
            {
                while (l1 < L && m > 0)
                {
                    if (nums1[l1] <= nums2[l2] && m > 0)
                    {
                        l1++;
                        m--;
                    }
                    else
                    {
                        int i = 0;
                        int p = 0;
                        //Swap
                        swap(nums1, l1, nums2, i);
                        //Ordere nums2
                        if (nums2.Length > 1)
                        {
                            while (nums2[p] > nums2[p + 1])
                            {
                                swap(nums2, p, nums2, p + 1);
                                p++;
                                if (p + 1 == n)
                                {
                                    break;
                                }
                            }
                        }
                        l1++;
                        m--;
                    }
                }

                nums1[l1] = nums2[l2];
                l1++;
                l2++;
            }
        }

        public void swap(int[] arr1, int ind1, int[] arr2, int ind2)
        {
            int _dummy = 0;
            _dummy = arr1[ind1];
            arr1[ind1] = arr2[ind2];
            arr2[ind2] = _dummy;
        }
    }
}
