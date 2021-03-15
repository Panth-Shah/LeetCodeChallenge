using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day14_ExchangeLinkedListNodes
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            ListNode p2 = head;

            ListNode result = head;
            while (--k > 0)
            {
                //Move head to k steps
                head = head.next;
            }
            //Assign head to p1
            ListNode p1 = head;
            //Move to the end of the list from k
            while (head.next != null)
            {
                //p2 is at the beginning of the list and so it will move exactly 
                p2 = p2.next;
                head = head.next;
            }
            //Swap nodes
            int temp = p2.val;
            p2.val = p1.val;
            p1.val = temp;

            return result;
        }
    }
}
