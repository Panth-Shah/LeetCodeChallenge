using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day5_AverageofLevelinBT
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> result = new List<double>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int len = q.Count;
                int count = 0;
                double total = 0;

                for (int i = 0; i < len; i++)
                {
                    TreeNode curr = q.Dequeue();

                    if (curr.left != null)
                    {
                        q.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        q.Enqueue(curr.right);
                    }

                    total += curr.val;
                    count += 1;
                }
                result.Add(total / count);
            }
            return result;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
