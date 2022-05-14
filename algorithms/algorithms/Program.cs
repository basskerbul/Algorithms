//2.Реализуйте двоичное дерево и метод вывода его в консоль
//Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска. Дерево должно
//быть сбалансированным (это требование не обязательно). Также напишите метод вывода в консоль
//дерева, чтобы увидеть, насколько корректно работает ваша реализация.

var head = new Node { Data = 10 };
var item1 = head.Insert(15);
var item2 = head.Insert(8);
PrintTree.Print(head);

public interface ITreeFunctions
{
    public Node Search(Node head, int value);
    public void Delete(int value);
    public Node? Insert(int value);
}

public static class PrintTree
{
    public static void Print(Node head)
    {
        string format = "";
        string result = "";

        Console.Write($"__({head.Data})__");

        Queue<Node> queue1 = new();
        queue1.Enqueue(head);
        Queue<Node> queue2 = new();
        while (true)
        {
            if (queue1.Count == 0 & queue2.Count == 0)
                break;
            if (queue2.Count == 0)
            {
                result += "\n";
                Node item = queue1.Dequeue();
                queue2.Enqueue(item.Left);
                queue2.Enqueue(item.Right);
                result += $"({item.Data})";
            }
            else if (queue1.Count == 0)
            {
                result += "\n";
                Node item = queue2.Dequeue();
                queue1.Enqueue(item.Left);
                queue1.Enqueue(item.Right);
                result += $"{item.Data}";
            }
        }
        Console.WriteLine(result);
    }
}

public class Node: ITreeFunctions
{
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    /// <summary>
    /// Поиск по значению
    /// </summary>
    /// <param name="node"></param>
    public Node Search(Node head, int value)
    {
        Node result = head;
        while (result.Data == value)
        {
            if (result.Left.Data < value)
            {
                result = result.Left;
                continue;
            }
            else if (result.Left.Data > value)
            {
                result = result.Right;
                continue;
            }
            else if (result.Right.Data < value)
            {
                result = result.Left;
                continue;
            }
            else if (result.Right.Data > value)
            {
                result = result.Right;
                continue;
            }
        }
        return result;
    }
    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="node"></param>
    public void Delete(int value)
    {
        Node head = new() { Data = this.Data };
        head.Left = this.Left;
        head.Right = this.Right;

        Node item = new() { Data = value };

        while (true)
        {
            if (head.Data < value)
            {
                item = head.Right;
                if (item.Data == value)
                {
                    if (head.Right != null)
                        head.Right = head.Right.Right;
                    else
                        head.Right = null;
                    break;
                }
            }
            else if (head.Data > value)
            {
                item = head.Left;
                if (item.Data == value)
                {
                    if (head.Left != null)
                        head.Left = head.Left.Left;
                    else
                        head.Left = null;
                    break;
                }
            }
        }
    }
    /// <summary>
    /// Вставка
    /// </summary>
    /// <param name="head"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public Node? Insert(int value)
    {
        Node head = new() { Data = this.Data };
        head.Left = this.Left;
        head.Right = this.Right;

        if (head == null)
        {
            head.Data = value;
            head.Left = null;
            head.Right = null;
            return head;
        }
        Node unit = head;
        while (unit != null)
        {
            if (unit.Data > value)
            {
                if (unit.Left != null)
                {
                    unit = unit.Left;
                    continue;
                }
                else
                {
                    Node new_unit = new Node { Data = value };
                    new_unit.Left = null;
                    new_unit.Right = null;
                    return new_unit;
                }
            }
            else if (unit.Data < value)
            {
                if (unit.Right != null)
                {
                    unit = unit.Right;
                    continue;
                }
                else
                {
                    Node new_unit = new Node { Data = value };
                    new_unit.Right = null;
                    new_unit.Left = null;
                    return new_unit;
                }
            }
            else
            {
                Console.WriteLine("Что-то пошло не так");
                return null;
            }
        }
        return unit;
    }
    /// <summary>
    /// Вывод на консоль
    /// </summary>
    /// <param name="head"></param>
    public void OutputToConsole()
    {
        Node head = new() { Data = this.Data };
        head.Left = this.Left;
        head.Right = this.Right;
        string format = "";
        string result = "";

        Console.Write($"__({head.Data})__");

        Queue<Node> queue1 = new();
        queue1.Enqueue(head);
        Queue<Node> queue2 = new();
        while (true)
        {
            if (queue1.Count == 0 & queue2.Count == 0)
                break;
            if (queue2.Count == 0)
            {
                result += "\n";
                Node item = queue1.Dequeue();
                queue2.Enqueue(item.Left);
                queue2.Enqueue(item.Right);
                result += $"({item.Data})";
            }
            else if (queue1.Count == 0)
            {
                result += "\n";
                Node item = queue2.Dequeue();
                queue1.Enqueue(item.Left);
                queue1.Enqueue(item.Right);
                result += $"{item.Data}";
            }
        }
        Console.WriteLine(result);
    }
}