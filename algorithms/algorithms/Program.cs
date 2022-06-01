// Реализовать Bucketsort, проверить корректность работы.

int[] values1 = {15, 8, 88, 97, 4, 25, 76, 34, 21, 4, 8, 25};
EditingArray.Print(values1);
values1 = Sort.Busket(values1);
EditingArray.Print(values1);

int[] values2 = {34, 7, 89, 54, 11, 23,  4, 45, 77, 68, 7, 11};
EditingArray.Print(values2);
values2 = Sort.Busket(values2);
EditingArray.Print(values2);

public static class Sort
{
    public static int[] Busket(int[] values)
    {
        //создание контейнеров
        int[][] buskets = new int[5][];         // 0-19 20-39 40-59 60-79 80-99
        
        //раскидать элементы по блокам
        for(int i = 0; i < values.Length; i++)
        {
            if (values[i] > 0 & values[i] < 20)
                buskets[0] = EditingArray.Insert(buskets[0], values[i]);
            else if (values[i] >= 20 & values[i] < 40)
                buskets[1] = EditingArray.Insert(buskets[1], values[i]);
            else if (values[i] >= 40 & values[i] < 60)
                buskets[2] = EditingArray.Insert(buskets[2], values[i]);
            else if (values[i] >= 60 & values[i] < 80)
                buskets[3] = EditingArray.Insert(buskets[3], values[i]);
            else
                buskets[4] = EditingArray.Insert(buskets[4], values[i]);
        }

        //сортировать блоки
        for(int i = 0; i < buskets.Length; i++)
            buskets[i] = Sort.Quick(buskets[i]);

        //собрать блоки в один массив
        int[] sorted_array = { };
        for(int i = 0; i < buskets.Length; i++)
            sorted_array = EditingArray.Gluing(sorted_array, buskets[i]);
        
        return sorted_array;
    }

    private static int[] Quick(int[] array)
    {
        if (array == null)
            return null;
        if (array.Length == 0)
            return null;
        if (array.Length == 1)
            return array;
        Random rnd = new();
        int support_element = rnd.Next(0, array.Length - 1);
        int[] less = { };
        int[] equal = { };
        int[] more = { };
        for(int i = 0; i < array.Length; i++)
        {
            if(array[i] < array[support_element])
                less = EditingArray.Insert(less, array[i]);
            
            else if(array[i] > array[support_element])
                more = EditingArray.Insert(more, array[i]);
            else
                equal = EditingArray.Insert(equal, array[i]);
        }
        less = Sort.Quick(less);
        more = Sort.Quick(more);
        int[] sorted_array = { };
        sorted_array = EditingArray.Gluing(less, equal);
        sorted_array = EditingArray.Gluing(sorted_array, more);
        return sorted_array;
    }
}
public static class EditingArray
{
    /// <summary>
    /// Добавляет элемент в конец
    /// </summary>
    /// <param name="array"></param>
    /// <param name="value"></param>
    public static int[] Insert(int[]? array, int value)
    {
        if(array == null)
            return new int[] {value};
        else
        {
            int[] new_array = new int[array.Length + 1];
            new_array[new_array.Length - 1] = value;
            for (int i = 0; i < new_array.Length - 1; i++)
                new_array[i] = array[i];
            return new_array;
        }
    } 
    /// <summary>
    /// Склеивает два массива
    /// </summary>
    /// <param name="array1"></param>
    /// <param name="array2"></param>
    /// <returns></returns>
    public static int[] Gluing(int[] array1, int[] array2)
    {
        if (array1 == null)
            return array2;
        if (array2 == null)
            return array1;
        int[] new_array = new int[array1.Length + array2.Length];
        for (int i = 0; i < array1.Length; i++)
            new_array[i] = array1[i];
        for (int i = 0; i < array2.Length; i++)
            new_array[i + array1.Length] = array2[i];
        return new_array;
    }
    public static void Print(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
    }
}