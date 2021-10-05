using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCodeProblems_January;

namespace LeetCodeProblems_June
{
    public class Day8_ConstructBST
    {
        int preorderIndex;
        Dictionary<int, int> inorderIndexMap;
        public TreeNode buildTree(int[] preorder, int[] inorder)
        {
            preorderIndex = 0;
            // build a hashmap to store value -> its index relations
            inorderIndexMap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderIndexMap.Add(inorder[i], i);
            }

            return arrayToTree(preorder, 0, preorder.Length - 1);
        }

        private TreeNode arrayToTree(int[] preorder, int left, int right)
        {
            // if there are no elements to construct the tree
            if (left > right) return null;

            // select the preorder_index element as the root and increment it
            int rootValue = preorder[preorderIndex++];
            TreeNode root = new TreeNode(rootValue);

            // build left and right subtree
            // excluding inorderIndexMap[rootValue] element because it's the root
            root.left = arrayToTree(preorder, left, inorderIndexMap[rootValue] - 1);
            root.right = arrayToTree(preorder, inorderIndexMap[rootValue] + 1, right);
            return root;
        }
    }
}
