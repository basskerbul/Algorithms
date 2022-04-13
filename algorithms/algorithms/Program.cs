//Вычислите асимптотическую сложность функции из примера ниже.

static int StrangeSum(int[] inputArray)
{
    int sum = 0;  // О(1) - однократное действие
    for (int i = 0; i < inputArray.Length; i++)  // O(n)
    {
        for (int j = 0; j < inputArray.Length; j++)  // O(n)
        {
            for (int k = 0; k < inputArray.Length; k++) // O(n) везде n т.к. кол-во шагов одинаковое
            {
                int y = 0;  // O(1) - однократное действие
                if (j != 0)
                {
                    y = k / j;
                }
                sum += inputArray[i] + i + k + j + y; // O(1) - однократное действие
            }
        }
    }
    return sum; // O(1) - однократное действие
    //Итого: О(4 + n * n * n) или просто сократить до O(n^3)
}