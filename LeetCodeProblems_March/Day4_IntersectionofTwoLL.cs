using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day4_IntersectionofTwoLL
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode currA = headA;
            ListNode currB = headB;

            while (currA != currB)
            {
                currA = currA != null ? currA.next : headB;
                currB = currB != null ? currB.next : headA;
            }
            return currA;

        }
    }
    //Definition for singly-linked list. 
    public class ListNode
    {
        public int val;     
        public ListNode next;    
        public ListNode(int x) { val = x; }
    }
}
