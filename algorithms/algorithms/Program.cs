//2.Реализуйте двоичное дерево и метод вывода его в консоль
//Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска. Дерево должно
//быть сбалансированным (это требование не обязательно). Также напишите метод вывода в консоль
//дерева, чтобы увидеть, насколько корректно работает ваша реализация.

var head = new TreeNode { Value = 10 };
//Добавленые элементы невозможно сохранить, потому что существуют они только
//в пределах метода, который их создает. И когда метод завершается т.к.
//из метода void к переменной вне это не присвоить, то элемент стирается
head.AddItem(2);
head.AddItem(18);
head.PrintTree();


public class TreeNode: ITree
{
    public int Value { get; set; }
    public TreeNode LeftChild { get; set; }
    public TreeNode RightChild { get; set; }

    public override bool Equals(object obj)
    {
        var node = obj as TreeNode;
        if (node == null)
            return false;
        return node.Value == Value;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    /// <summary>
    /// Возвращает корень?
    /// </summary>
    /// <returns></returns>
    public TreeNode GetRoot()
    {
        TreeNode head = new() { Value = this.Value };
        head.LeftChild = this.LeftChild;
        head.RightChild = this.RightChild;



        return null;
    }
    public void AddItem(int value)
    {
        TreeNode new_item = new TreeNode { Value = value };
        new_item.LeftChild = null;
        new_item.RightChild = null;
        TreeNode head = new TreeNode { Value = this.Value };
        head.LeftChild = this.LeftChild;
        head.RightChild = this.RightChild;

        while (true)
        {
            if (head.Value > new_item.Value)
            {
                if(head.LeftChild != null)
                {
                    head = head.LeftChild;     //если левый лист не равен нулю
                    continue;               //то присвоить head будет левый лист
                }
                else if(head.LeftChild == null)
                {
                    head.LeftChild = new_item;
                    break;
                }
            }
            else if(head.Value < new_item.Value)
            {
                if(head.RightChild != null)
                {
                    head = head.RightChild;
                    continue;
                }
                else if(head.RightChild == null)
                {
                    head.RightChild = new_item;
                }
            }
        }
    }
    public void RemoveItem(int value)
    {
        TreeNode head = new() { Value = this.Value };
        head.LeftChild = this.LeftChild;
        head.RightChild = this.RightChild;

        TreeNode item = new() { Value = value };

        while (true)
        {
            if (head.Value < value)
            {
                item = head.RightChild;
                if (item.Value == value)
                {
                    if (head.RightChild != null)
                        head.RightChild = head.RightChild.RightChild;
                    else
                        head.RightChild = null;
                    break;
                }
            }
            else if(head.Value > value)
            {
                item = head.LeftChild;
                if(item.Value == value)
                {
                    if (head.LeftChild != null)
                        head.LeftChild = head.LeftChild.LeftChild;
                    else
                        head.LeftChild = null;
                    break;
                }
            }
        }
    }
    public TreeNode GetNodeByValue(int value)
    {
        TreeNode head = new() { Value = this.Value };
        head.RightChild = this.RightChild;
        head.LeftChild = this.LeftChild;

        TreeNode item = Search(head, value);

        return item;
    }
    public void PrintTree()
    {
        TreeNode head = new() { Value = this.Value };
        head.LeftChild = this.LeftChild;
        head.RightChild = this.RightChild;
        string format = "";
        string result = "";

        Console.Write($"__({head.Value})__");
        
        Queue<TreeNode> queue1 = new();
        queue1.Enqueue(head);
        Queue<TreeNode> queue2 = new();
        while (true)
        {
            if (queue1.Count == 0 & queue2.Count == 0)
                break;
            if(queue2.Count == 0)
            {
                result += "\n";
                TreeNode item = queue1.Dequeue();
                queue2.Enqueue(item.LeftChild);
                queue2.Enqueue(item.RightChild);
                result += $"({item.Value})";
            }
            else if(queue1.Count == 0)
            {
                result += "\n";
                TreeNode item = queue2.Dequeue();
                queue1.Enqueue(item.LeftChild);
                queue1.Enqueue(item.RightChild);
                result += $"{item.Value}";
            }
        }
        Console.WriteLine(result);
    }
    /// <summary>
    /// Поиск
    /// </summary>
    /// <param name="head"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TreeNode Search(TreeNode head, int value)
    {
        TreeNode result = head;
        while (result.Value == value)
        {
            if (result.LeftChild.Value < value)
            {
                result = result.LeftChild;
                continue;
            }
            else if (result.LeftChild.Value > value)
            {
                result = result.RightChild;
                continue;
            }
            else if (result.RightChild.Value < value)
            {
                result = result.LeftChild;
                continue;
            }
            else if (result.RightChild.Value > value)
            {
                result = result.RightChild;
                continue;
            }
        }
        return result;
    }
}
public interface ITree
{
    TreeNode GetRoot();
    void AddItem(int value); // добавить узел
    void RemoveItem(int value); // удалить узел по значению
    TreeNode GetNodeByValue(int value); //получить узел дерева по значению
    void PrintTree(); //вывести дерево в консоль
}

/// <summary>
/// помощник
/// </summary>
public static class TreeHelper
{
    public static NodeInfo[] GetTreeInLine(ITree tree)
    {
        var bufer = new Queue<NodeInfo>();
        var returnArray = new List<NodeInfo>();
        var root = new NodeInfo() { Node = tree.GetRoot() };
        bufer.Enqueue(root);
        while (bufer.Count != 0)
        {
            var element = bufer.Dequeue();
            returnArray.Add(element);
            var depth = element.Depth + 1;
            if (element.Node.LeftChild != null)
            {
                var left = new NodeInfo()
                {
                    Node = element.Node.LeftChild,
                    Depth = depth,
                };
                bufer.Enqueue(left);
            }
            if (element.Node.RightChild != null)
            {
                var right = new NodeInfo()
                {
                    Node = element.Node.RightChild,
                    Depth = depth,
                };
                bufer.Enqueue(right);
            }
        }
        return returnArray.ToArray();
    }
}
public class NodeInfo
{
    public int Depth { get; set; } //глубина
    public TreeNode Node { get; set; }
}
