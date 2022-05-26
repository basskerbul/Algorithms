// Для прямоугольного поля размера M на N клеток, подсчитать количество путей из верхней левой
// клетки в правую нижнюю. Известно что ходить можно только на одну клетку вправо или вниз.

int[][] field1 = Creator.FieldCreator(3, 3);
int result = Helper.ReturnNumberOfPaths(field1);
Console.WriteLine(result);  //6

int[][] field2 = Creator.FieldCreator(4, 4);
result = Helper.ReturnNumberOfPaths(field2);
Console.WriteLine(result);  //20

int[][] field3 = Creator.FieldCreator(10, 100);
result = Helper.ReturnNumberOfPaths(field3);
Console.WriteLine(result);  //48620

public static class Creator
{
    public static int[][] FieldCreator(int M, int N)
    {
        int[][] field = new int[M][];

        for(int i = 0; i < field.Length; i++)
            field[i] = new int[N];
        
        return field;
    }
}

public static class Helper
{
    public static int ReturnNumberOfPaths(int[][] field)
    {
        for (int i = 1; i < field.Length; i++)
            field[i][0] = 1;
        for (int i = 1; i < field[0].Length; i ++)
            field[0][i] = 1;

        for (int i = 1; i < field.Length; i++)
        {
            for (int j = 1; j < field[i].Length; j++)
                field[i][j] = field[i - 1][j] + field[i][j - 1];
        }

        int[] last_line= new int[field.Length];
        
        for (int i = 0; i < last_line.Length; i++)
            last_line[i] = field[field.Length - 1][i];
        
        return last_line[last_line.Length - 1];
    }
}