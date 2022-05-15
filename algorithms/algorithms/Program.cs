GraphNode item1 = new() { Value = 15 };
GraphNode item2 = new() { Value = 10 };
GraphNode item3 = new() { Value = 21 };
GraphNode item4 = new() { Value = 30 };
GraphNode item5 = new() { Value = 11 };
GraphNode item6 = new() { Value = 4 };

GraphNode[] edgesItem1 = { item2, item5 };
item1.Edges = edgesItem1;
GraphNode[] edgesItem2 = { item1, item3, item6 };
item2.Edges = edgesItem2;
GraphNode[] edgesItem3 = { item2, item6, item4 };
item3.Edges = edgesItem3;
GraphNode[] edgesItem4 = { item3, item5 };
item4.Edges = edgesItem4;
GraphNode[] edgesItem5 = { item1, item6, item4 };
item5.Edges = edgesItem5;
GraphNode[] edgesItem6 = { item2, item3, item5 };
item6.Edges = edgesItem6;

BFS.Search(item1, 4);
BFS.Search(item1, 8);

DFS.Search(item1, 30);
DFS.Search(item1, 37);

public static class DFS
{
    public static void Search(GraphNode start, int value)
    {
        Console.WriteLine("В стек кладём вершину, с которой начнем поиск");
        Console.WriteLine("И ее кладем в список уже проверенных вершин");
        Stack<GraphNode> nodes = new();
        Queue<GraphNode> verifiedNodes = new();
        nodes.Push(start);
        verifiedNodes.Enqueue(start);
        while(nodes.Count > 0)
        {
            GraphNode item = nodes.Pop();
            Console.WriteLine($"Сравниваем значение {item.Value} с верхушки стека с искомым {value}");
            if (item.Value == value)
            {
                Console.WriteLine("Элемент найден");
                break;
            }
            else
            {
                Console.WriteLine("Это не тот элемент");
                Console.WriteLine("Кладем в стек вершины, в которые можно попасть из той ноды");
                for (int i = 0; i < item.Edges.Length; i++)
                {
                    if (nodes.Contains(item.Edges[i]) & verifiedNodes.Contains(item.Edges[i]))
                    {
                        Console.WriteLine("Этот элемент уже есть в списках");
                        continue;
                    }
                    else if (!verifiedNodes.Contains(item.Edges[i]))
                    {
                        Console.WriteLine($"Элемент {item.Edges[i].Value} добавлен в списки");
                        nodes.Push(item.Edges[i]);
                        verifiedNodes.Enqueue(item.Edges[i]);
                        continue;
                    }
                }
            }
        }
    }
}
public static class BFS
{
    public static void Search(GraphNode start, int value)
    {
        Console.WriteLine($"Добавляем в очередь первый элемент со значением {start.Value}");
        Console.WriteLine("И его же в очередь уже проверенных вершин");
        Queue<GraphNode> nodes = new();
        Queue<GraphNode> verifiedNodes = new();
        nodes.Enqueue(start);
        verifiedNodes.Enqueue(start);
        while(nodes.Count > 0)
        {
            GraphNode item = nodes.Dequeue();
            Console.WriteLine($"Извлекаем первый элемент из очереди {item.Value} и сравниваем с {value}");
            if (item.Value == value)
            {
                Console.WriteLine($"Значение найдено");
                break;
            }
            Console.WriteLine("Значение не найдено. Добавляем следующие вершины в очередь");
            for(int i = 0; i < item.Edges.Length; i++)
            {
                if (nodes.Contains(item.Edges[i]) & verifiedNodes.Contains(item.Edges[i]))
                {
                    Console.WriteLine("Этот элемент уже есть в списках");
                    continue;
                }
                else if(!verifiedNodes.Contains(item.Edges[i]))
                {
                    Console.WriteLine("Этого элемента в списках еще нет");
                    Console.WriteLine($"В очередь добавлен {item.Value}");
                    nodes.Enqueue(item.Edges[i]);
                    verifiedNodes.Enqueue(item.Edges[i]);
                }
            }
        }
    }
}

public class GraphNode
{
    public int Value { get; set; }
    public GraphNode[]? Edges { get; set; }
}