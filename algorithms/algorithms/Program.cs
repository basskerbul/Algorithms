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

string[] array_strings = new string[10000];
for(int i = 0; i < array_strings.Length; i++)
{
    array_strings[i] = StringGenerator();
}
Console.WriteLine(array_strings[45]);
Console.WriteLine(array_strings[12]);
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");