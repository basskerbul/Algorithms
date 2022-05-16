//2.Реализуйте двоичное дерево и метод вывода его в консоль
//Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска. Дерево должно
//быть сбалансированным (это требование не обязательно). Также напишите метод вывода в консоль
//дерева, чтобы увидеть, насколько корректно работает ваша реализация.


TreeNode head = new() { Value = 8 };
BinaryTree.Insert(head, 5);
BinaryTree.Insert(head, 3);
BinaryTree.Insert(head, 6);
BinaryTree.Insert(head, 10);
BinaryTree.Insert(head, 9);
BinaryTree.Insert(head, 11);

BinaryTree.Print(head);

public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
    public TreeNode Parent { get; set; }
}

public static class BinaryTree
{
    public static void Insert(TreeNode head, int value)
    {
        if (head.Value > value)
        {
            if (head.Left == null)
            {
                TreeNode item = new() { Value = value };
                item.Parent = head;
                head.Left = item;
            }
            else
                Insert(head.Left, value);
        }
        if (head.Value < value)
        {
            if (head.Right == null)
            {
                TreeNode item = new() { Value = value };
                item.Parent = head;
                head.Right = item;
            }
            else
                Insert(head.Right, value);
        }
    }
    public static void Delete(TreeNode head, int value)
    {
        TreeNode item = Search(head, value);
        if (item != null)
        {
            TreeNode parent = item.Parent;
            if (item.Left != null)
            {
                TreeNode left = item.Left;
                parent.Left = left;
                left.Parent = parent;
            }
            if (item.Right != null)
            {
                TreeNode right = item.Right;
                parent.Right = right;
                right.Parent = parent;
            }
        }
    }
    public static TreeNode Search(TreeNode head, int value)
    {
        Queue<TreeNode> nodes = new();
        nodes.Enqueue(head);
        while (nodes.Count > 0)
        {
            TreeNode node = nodes.Dequeue();
            if (node.Value == value)
                return node;

            if (node.Left != null)
                nodes.Enqueue(node.Left);
            if (node.Right != null)
                nodes.Enqueue(node.Right);
        }
        return null;
    }
    public static void Print(TreeNode head)
    {
        string interval = "  /    \\";

        Console.WriteLine($"   __({head.Value})__");
        Console.WriteLine(interval);

        Queue<TreeNode> queue1 = new();
        Queue<TreeNode> queue2 = new();

        queue1.Enqueue(head);

        while(true)
        {
            if(queue1.Count == 0 & queue2.Count == 0)
                break;
            string level = "";
            if (queue1.Count != 0)
            {
                for (int x = 0; x <= queue1.Count; x++)
                {
                    TreeNode item = queue1.Dequeue();
                    if (item.Left != null)
                    {
                        queue2.Enqueue(item.Left);
                        level = $"({item.Left.Value})" + level;
                    }
                    else
                        level = "(null)" + level;
                    if (item.Right != null)
                    {
                        queue2.Enqueue(item.Right);
                        level = level + $"({item.Right.Value})";
                    }
                    else
                        level = level + "(null)";
                }
            }
            if(queue2.Count != 0)
            {
                for (int x = 0; x <= queue2.Count; x++)
                {
                    TreeNode item = queue2.Dequeue();
                    if (item.Left != null)
                    {
                        queue1.Enqueue(item.Left);
                        level = $"({item.Left.Value})" + level;
                    }
                    else
                        level = "(null)" + level;
                    if (item.Right != null)
                    {
                        queue1.Enqueue(item.Right);
                        level = level + $"({item.Right.Value})";
                    }
                    else
                        level = level + "(null)";
                    
                }
            }
            Console.WriteLine(level);
        }
    }
}