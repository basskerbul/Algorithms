//1.Протестируйте поиск строки в HashSet и в массиве
//Заполните массив и HashSet случайными строками, не менее 10 000 строк. Строки можно
//сгенерировать. Потом выполните замер производительности проверки наличия строки в массиве и
//HashSet. Выложите код и результат замеров.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(BenchmarkClass).Assembly).Run(args);
Console.ReadKey();

public class ArraySetGenerator
{
    public string[] array_strings;
    public HashSet<string> hashset;

    public ArraySetGenerator(int arrayLength)
    {
        string[] arr = new string[arrayLength];
        HashSet<string> set = new();
        for (int i = 0; i < arrayLength; i++)
        {
            arr[i] = StringGenerator();
            set.Add(StringGenerator());
        }
        array_strings = arr;
        hashset = set;
    }

    public static string StringGenerator()
    {
        Random random = new Random();
        string letters = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string str = "";
        for (int i = 0; i <= 10; i++)
        {
            int index = random.Next(letters.Length);
            str += letters[index];
        }
        return str;
    }
}

public static class TrySearch
{
    public static void TryArraySearch(string[] array, string value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                Console.WriteLine($"Значение {value} найдено по индексу {array[i]}");
            }
        }
    }

    public static void TryHashsetSearsh(HashSet<string>? table, string value)
    {
        if (table.Contains(value))
        {
            Console.WriteLine($"Значение {value} найдено");
        }
    }
}

[MemoryDiagnoser]
[RankColumn]
public class BenchmarkClass
{
    ArraySetGenerator set = new ArraySetGenerator(10000);

    [Benchmark]
    public void TestArraySearch()
    {
        TrySearch.TryArraySearch(set.array_strings, set.array_strings[500]);
    }
    [Benchmark]
    public void TestHashsetSearch()
    {
        TrySearch.TryHashsetSearsh(set.hashset, ArraySetGenerator.StringGenerator());
    }
}