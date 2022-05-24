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
BinaryTree.Insert(head, 22);

BinaryTree.Delete(head, 22);

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
        //Короче, с помощью поиска в ширину пройтись по всему дереву и создать массив
        //со всеми нодами а потом распределить все по уровням
        Queue<TreeNode> queue = new();
        Queue<TreeNode>? items = new();
        queue.Enqueue(head);
        items.Enqueue(head);

        while (true)
        {
            if (queue.Count == 0)
                break;
            TreeNode item = queue.Dequeue();
            if (item.Left != null)
            {
                queue.Enqueue(item.Left);
                items.Enqueue(item.Left);
            }
            else
                items.Enqueue(null);
            if (item.Right != null)
            {
                queue.Enqueue(item.Right);
                items.Enqueue(item.Right);
            }
            else
                items.Enqueue(item.Right);
        }

        int[] allItems = TakeQueueReturnArray(items);

        int degree = 1;
        int min = 0;
        int max = 1;
        int Tab = 3;
        while (degree <= 3)
        {
            string str = "";
            for (int i = min; i < max; i++)
            {
                str += $"┌({allItems[i]})┐";
            }
            //Красота в глазах смотрящего.............................
            int centerX = (Console.WindowWidth / 2) - (str.Length / 2);
            Console.SetCursorPosition(centerX, degree);
            Console.WriteLine(str);

            min = max;
            max += Convert.ToInt32(Math.Pow(2, degree));
            degree++;
            Tab--;
        }
    }
    private static int[] TakeQueueReturnArray(Queue<TreeNode> queue)
    {
        int leng = queue.Count - 1;
        int[] array = new int[leng];

        for(int i = 0; i < queue.Count; i++)
        {
            TreeNode item = queue.Dequeue();
            if (item == null)
                array[i] = 0;
            else
                array[i] = item.Value;
        }

        return array;
    }

}