using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day5_RemoveDuplicateFromSortedList
    {
        public ListNode DeleteDuplicateNode(ListNode head)
        {
            //sentinel
            ListNode sentinel = new ListNode(0, head);
            ListNode pred = sentinel;
            while (head != null)
            {
                if (head.next != null && head.val == head.next.val)
                {
                    //move till the end of duplicate sublist
                    while (head.next != null && head.val == head.next.val)
                    {
                        head = head.next;
                    }
                    //skip all the duplicate nodes
                    pred.next = head.next;
                }
                else
                {
                    //keep pred moving forward
                    pred = pred.next;
                }
                head = head.next;
            }

            return sentinel.next;
        }
    }
}
