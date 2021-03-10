using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    //Approach: BFS
    public class Day9_AddOneRowToTree
    {
        //Idea here is to treverse through all the nodes of the given tree in the order of branches.
        //We go for BFS, along with keeping track of the depth of the nodes being considered at any momeny during the BFS.
        //We can stop the search process as soon as we reach to the depthj of d - 1
        //Steps:
        //1. Remove an element from the front of the queue and add all its children to the back of another temp queue
        //2. Keep on adding the elements to the back of the temp till queue becomes empty.
        //3. 
        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (d == 1)
            {
                TreeNode n = new TreeNode(v);
                n.left = root;
                return n;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            int depth = 1;
            //
            while (depth < d-1)
            {
                Queue<TreeNode> temp = new Queue<TreeNode>();
                while (q.Count > 0)
                {
                    TreeNode node = q.Dequeue();
                    if (node.left != null) temp.Enqueue(node.left);
                    if (node.right != null) temp.Enqueue(node.right);
                }
                q = temp;
                depth++;
            }

            while (q.Count != 0)
            {
                TreeNode node = q.Dequeue();
                TreeNode temp = node.left;
                node.left = new TreeNode(v);
                node.left.left = temp;
                temp = node.right;
                node.right = new TreeNode(v);
                node.right.right = temp;
            }
            return root;

        }
    }
}
