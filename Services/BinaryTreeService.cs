using System;
using test_coding.Models;

namespace test_coding.Services
{
	public class BinaryTreeService
	{
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int leftDepth = MaxDepth(root.Left);
                int rightDepth = MaxDepth(root.Right);
                return Math.Max(leftDepth, rightDepth) + 1;
            }
        }
    }
}

