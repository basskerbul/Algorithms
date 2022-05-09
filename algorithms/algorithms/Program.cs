//1.Протестируйте поиск строки в HashSet и в массиве
//Заполните массив и HashSet случайными строками, не менее 10 000 строк. Строки можно
//сгенерировать. Потом выполните замер производительности проверки наличия строки в массиве и
//HashSet. Выложите код и результат замеров.

string StringGenerator()
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

//Генерация массива и таблицы
string[] array_strings = new string[10000];
var hachset = new HashSet<string>();

for (int i = 0; i < array_strings.Length; i++)
{
    array_strings[i] = StringGenerator();
    hachset.Add(StringGenerator());
}

bool TryArraySearch(string[] array, string value)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == value)
        {
            Console.WriteLine($"Значение {value} найдено по индексу {array[i]}");
            return true;
        }
    }
    return false;
}

bool TryHashsetSearsh(HashSet<string>? table, string value)
{
    if (table.Contains(value))
    {
        Console.WriteLine($"Значение {value} найдено");
        return true;
    }
    else
        return false;
}