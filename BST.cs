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
        Console.WriteLine(node.val);
        InOrder(node.right);
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


    }
}
