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
    int counter;

    public int GetCount()
    {
        return 0;
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
        counter++;
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

    }
    public void RemoveNode(Node node)
    {

    }
    public Node FindNode(int Value)
    {
        return null;
    }
}