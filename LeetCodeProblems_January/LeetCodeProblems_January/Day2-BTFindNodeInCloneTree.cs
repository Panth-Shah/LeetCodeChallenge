using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    class Day2_BTFindNodeInCloneTree
    {
        TreeNode target, result;

        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            this.target = target;
            inorder(original, cloned);
            return result;
        }

        public void inorder(TreeNode travOriginal, TreeNode travCloned)
        {
            if (travOriginal != null)
            {
                //Inorder Traversal : L Root Right
                inorder(travOriginal.left, travCloned.left);
                if (travOriginal == target)
                {
                    result = travCloned;
                }
                else
                {
                    inorder(travOriginal.right, travCloned.right);
                }
            }
        }
    }


    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
