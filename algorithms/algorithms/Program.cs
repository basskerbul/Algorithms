//Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).
//Тест
//0 1 1 2 3 5 8 13 21 34 55
Console.WriteLine(FibonacciM(5)); //5
Console.WriteLine(FibonacciM(7)); //13

//Минус рекурсии здесь в том, что одна из единиц оригинального ряда 
//не учитывается и все смещается на одну позицию
Console.WriteLine(FibonacciR(5)); //5
Console.WriteLine(FibonacciR(10));//55

/// <summary>
/// С рекурсией
/// </summary>
static int FibonacciR(int SerialNumber)
{
    if (SerialNumber == 0)
    {
        return 0;
    }
    if (SerialNumber == 1)
    {
        return 1;
    }
    return (FibonacciR(SerialNumber - 1) + FibonacciR(SerialNumber - 2));
}

/// <summary>
/// Без рекурсии
/// </summary>
static int FibonacciM(int num)
{
    //Без учета первого числа 0
    int[] fibnum = new int[num];
    fibnum[0] = 1; //с учетом будет fibnum[0] = 0;
    fibnum[1] = 1; //просто чтобы с рекурсивным выводом совпадало
    for (int i = 2; i < fibnum.Length; i++)
    {
        fibnum[i] = fibnum[i - 1] + fibnum[i - 2];
    }
    return fibnum[(num - 1)];
}