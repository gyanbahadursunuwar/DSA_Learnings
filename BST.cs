using System.Globalization;
using System.Runtime.CompilerServices;

public class TreeNode
{
    public int val { get; set; }
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Program
{
    public static TreeNode InsertBinary(TreeNode root, int value = 0)
    {
        if (root == null)
        {
            root = new TreeNode(value);
            return root;
        }
        if (root.val > value)
        {
            root.left = InsertBinary(root.left, value);
        }
        else if (root.val < value)
        {
            root.right = InsertBinary(root.right, value);
        }
        return root;
    }
    public static void PostOrder(TreeNode node)
    {
        if (node == null)
            return;
        Console.WriteLine(node.val + ",");
        if (node.left != null)
            PostOrder(node.left);
        if (node.right != null)
            PostOrder(node.right);
    }
    public static void InOrder(TreeNode node)
    {
        if (node == null)
        {
            return;
        }
        InOrder(node.left);
        Console.Write(node.val + " ");
        InOrder(node.right);
    }
    public static TreeNode DeleteBST(TreeNode node, int val)
    {
        if (node == null)
            return null;
        else if (node.val > val)
            node.left = DeleteBST(node.left, val);
        else if (node.val < val)
            node.right = DeleteBST(node.right, val);
        else
        {
            // Leaf node case
            if (node.left == null && node.right == null)
                return null;

            // Right exists use in-order successor (min of right)

            if (node.right != null)
            {
                TreeNode lastnode = node.right;
                while (lastnode.left != null)
                {
                    lastnode = lastnode.left;
                }
                node.val = lastnode.val;
                node.right = DeleteBST(node.right, node.val);
            }
            // Only left exists(left skew) use in-order predecessor (max of left)
            else
            {
                TreeNode lastnode = node.left;
                lastnode = node.left;
                while (lastnode.right != null)
                {
                    lastnode = lastnode.right;
                }
                node.val = lastnode.val;
                node.left = DeleteBST(node.left, node.val);
            }
        }
        return node;
    }
    public static TreeNode FindSuccessor(TreeNode node)
    {
        while (node.left != null)
        {
            node = node.left;
        }
        return node;
    }
    public static void Main()
    {
        TreeNode n = new TreeNode(10);
        InsertBinary(n, 5);
        InsertBinary(n, 12);
        InsertBinary(n, 40);
        InsertBinary(n, 11);
        InsertBinary(n, 34);
        InsertBinary(n, 53);
        InsertBinary(n, 67);
        InsertBinary(n, 43);
        //PostOrder(n);
        InOrder(n);
        DeleteBST(n, 10);
        Console.WriteLine();
        InOrder(n);

    }
}

/*
BST DELETION - 3 CASES

Case 1: Leaf node (no children)
  - Simply remove and return null

Case 2: Node has RIGHT child only (right-skew)
  - Find in-order successor (smallest in right subtree)
  - Copy successor's value to current node
  - Recursively delete successor from right subtree

Case 3: Node has LEFT child only (left-skew)
  - Find in-order predecessor (largest in left subtree)
  - Copy predecessor's value to current node
  - Recursively delete predecessor from left subtree

Note: If both children exist, prioritize right child and use successor approach
*/
