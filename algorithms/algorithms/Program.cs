//Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска
//элемента в нём в соответствии с интерфейсом.

Node item1 = new Node();
Node item2 = new Node();
Node item3 = new Node();

item1.Value = 15;
item1.NextNode = item2;
item1.PrevNode = null;

item2.Value = 87;
item2.NextNode = item3;
item2.PrevNode = item1;

item3.Value = 21;
item3.NextNode = null;
item3.PrevNode = item2;

LinkedList ll = new LinkedList(item3);

int counter = ll.GetCount();
Console.WriteLine(counter); 

ll.AddNode(88);
counter = ll.GetCount();
Console.WriteLine(counter); 

ll.RemoveNode(item1);
counter = ll.GetCount();
Console.WriteLine(counter); 

ll.AddNodeAfter(item2, 336);
counter = ll.GetCount();
Console.WriteLine(counter); 

ll.RemoveNode(4);
counter = ll.GetCount();
Console.WriteLine(counter); 

//Начальную и конечную ноду нужно хранить в самой реализации интерфейса
public interface ILinkedList
{
    /// <summary>
    /// возвращает количество элементов в списке
    /// </summary>
    /// <returns></returns>
    int GetCount();
    /// <summary>
    /// добавляет новый элемент списка
    /// </summary>
    /// <param name="value"></param>
    void AddNode(int value);
    /// <summary>
    /// добавляет новый элемент списка после определённого элемента
    /// </summary>
    /// <param name="node"></param>
    /// <param name="value"></param>
    void AddNodeAfter(Node node, int value);
    /// <summary>
    /// удаляет элемент по порядковому номеру
    /// </summary>
    /// <param name="index"></param>
    void RemoveNode(int index);
    /// <summary>
    /// удаляет указанный элемент
    /// </summary>
    /// <param name="node"></param>
    void RemoveNode(Node node);
    /// <summary>
    /// ищет элемент по его значению
    /// </summary>
    /// <param name="searchValue"></param>
    /// <returns></returns>
    Node FindNode(int searchValue);
}

public class Node
{
    public int Value { get; set; }
    public Node NextNode { get; set; }
    public Node PrevNode { get; set; }
}

public class LinkedList: ILinkedList
{
    public Node? head;
    public Node? tail;

    //Находит первую и последнюю ноду
    public LinkedList(Node node)
    {
        var currentNode = node;
        while (true)
        {
            if (currentNode.NextNode == null)
            {
                tail = currentNode;
                break;
            }
            currentNode = currentNode.NextNode;
        }
        while (true)
        {
            if(currentNode.PrevNode == null)
            {
                head = currentNode;
                break;
            }
            currentNode = currentNode.PrevNode;
        }
    }

    public int GetCount()
    {
        if (head == null)
            return 0;
        else
        {
            int counter = 1;
            Node currentNode = head;
            while (true)
            {
                if (currentNode.NextNode != null)
                {
                    counter++;
                    currentNode = currentNode.NextNode;

                }
                else if(currentNode.NextNode == null)
                    return counter;

            }
        }
    }
    public void AddNode(int value)
    {
        Node node = new Node();
        node.Value = value;
        if (head == null)
            head = node;
        else
        {
            tail.NextNode = node;
            node.PrevNode = tail;
        }
        tail = node;
    }
    public void AddNodeAfter(Node node, int value)
    {
        Node new_node = new Node();
        new_node.Value = value;
        new_node.PrevNode = node;
        new_node.NextNode = node.NextNode;
        node.NextNode = new_node;
    }
    public void RemoveNode(int index)
    {
        //Ведь список начинается с 1. Так ведь?..
        if(index == 0)
            return;
        int counter = 1;
        Node currentNode = head;
        while (true)
          {
            if (counter == index)
            {
                if (currentNode.PrevNode != null & currentNode.NextNode != null)
                {
                    //Простите, выглядит странно
                    Node? NextNode = currentNode.NextNode;
                    Node? PrevNode = currentNode.PrevNode;
                    NextNode.NextNode = PrevNode;
                    PrevNode.PrevNode = NextNode;
                    break;
                }
                else if (currentNode.PrevNode == null)
                {
                    head = currentNode.NextNode;
                    break;
                }
                else if (currentNode.NextNode == null)
                {
                    tail = currentNode.PrevNode;
                    break;
                }
            }
            currentNode = currentNode.NextNode;
            counter++;
        }
    }
    public void RemoveNode(Node node)
    {
        if(node.PrevNode != null & node.NextNode != null)
        {
            //Простите, выглядит странно
            Node? NextNode = node.NextNode;
            Node? PrevNode = node.PrevNode;
            NextNode.NextNode = PrevNode;
            PrevNode.PrevNode = NextNode;
        }
        else if (node.PrevNode == null)
        {
            head = node.NextNode;
        }
        else if (node.NextNode == null)
        {
            tail = node.PrevNode;
        }
    }
    public Node FindNode(int Value)
    {
        Node currentNode = head;
        while (currentNode != null)
        {
            if(currentNode.Value == Value)
                return currentNode;
            currentNode = currentNode.NextNode;
        }
        return null;
    }
}