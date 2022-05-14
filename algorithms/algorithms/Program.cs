//2.Реализуйте двоичное дерево и метод вывода его в консоль
//Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска. Дерево должно
//быть сбалансированным (это требование не обязательно). Также напишите метод вывода в консоль
//дерева, чтобы увидеть, насколько корректно работает ваша реализация.

TreeNode head = new() { Value = 20 };
BinaryTree.Insert(head, 15);
BinaryTree.Insert(head, 11);
BinaryTree.Insert(head, 25);
BinaryTree.Insert(head, 36);
BinaryTree.Insert(head, 29);

BreadthFirstSearch.BFS(head, 29);
DeepFirstSearch.DFS(head, 11);

public static class BreadthFirstSearch
{ 
    public static void BFS(TreeNode head, int value)
    {
        Queue<TreeNode> queue = new();
        queue.Enqueue(head);
        Console.WriteLine($"В очередь добавлен корень {head.Value}");

        while(queue.Count > 0)
        {
            Console.WriteLine("В очереди есть элементы");
            Console.WriteLine("Извлекаем значение и сравниваем с искомым");
            TreeNode item = queue.Dequeue();
            if (item.Value == value)
            {
                Console.WriteLine("Значение найдено");
                break;
            }
            if(item.Left != null)
            {
                queue.Enqueue(item.Left);
                Console.WriteLine($"В очередь добавлен элемент {item.Left.Value}");
            }
            if (item.Right != null)
            {
                queue.Enqueue(item.Right);
                Console.WriteLine($"В очередь добавлен элемент {item.Right.Value}");
            }
        }
    }
}
public static class DeepFirstSearch
{
    public static void DFS(TreeNode head, int value)
    {
        Stack<TreeNode> stack = new();
        stack.Push(head);
        Console.WriteLine($"Корень со значением {head.Value} добавлен в стек");
        while(stack.Count > 0)
        {
            Console.WriteLine($"Стек не пуст, продолжаем поиск");
            TreeNode item = stack.Pop();
            if (item.Value == value)
            {
                Console.WriteLine($"Элемент с значением {item.Value} найден");
                break;
            }
            if(item.Left != null)
            {
                stack.Push(item.Left);
                Console.WriteLine($"В стек добавлен дочерний элемент {item.Left.Value}");
            }
            if (item.Right != null)
            {
                stack.Push(item.Right);
                Console.WriteLine($"В стек добавлен дочерний элемент {item.Right.Value}");
            }
        }
    }
}

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
    public static void Delete(TreeNode head,int value)
    {
        TreeNode item = Search(head, value);
        if(item != null)
        {
            TreeNode parent = item.Parent;
            if(item.Left != null)
            {
                TreeNode left = item.Left;
                parent.Left = left;
                left.Parent = parent;
            }
            if(item.Right != null)
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
        while(nodes.Count > 0)
        {
            TreeNode node = nodes.Dequeue();
            if(node.Value == value)
                return node;
               
            if(node.Left != null)
                nodes.Enqueue(node.Left);
            if (node.Right != null)
                nodes.Enqueue(node.Right);
        }
        return null;
    }
}