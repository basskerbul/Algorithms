//Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и
//проверить работоспособность функции.

static int BinarySearch(int[] arr, int value)
{
    Array.Sort(arr);
    int min = 0;
    int max = arr.Length - 1;
    while(min <= max)
    {
        //За каждый шаг цикла ареал поиска сокращается в два раза
        //Исключается половина чисел
        int mid = (min + max) / 2;
        if(value == arr[mid])
        {
            return arr[mid];
        }
        else if(value > arr[mid])
        {
            min = mid;
        }
        else if(value < arr[mid])
        {
            max = mid;
        }
    }
    return -1;
}

int[] array1 = { 1, 2, 3, 4, 5, 6 };
int[] array2 = { 0, 7, 15, 15, 2, 8, 9, 4, 89, 1 };

Console.WriteLine(BinarySearch(array1 , 5)); //5
//В случае с этим массивом нужное число будет найдено с 3-й попытки
//Вместо 6 попыток при прямом переборе
Console.WriteLine(BinarySearch(array2, 8));  //8
//Здесь нашел тоже с третьей попытки, хотя массив больше
//Т.е. скорость алгоритма растет логарифмически
//Значит сложность бинарного алгоритма будет О(log n)