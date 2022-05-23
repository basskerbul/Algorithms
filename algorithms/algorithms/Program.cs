using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(BenchmarkClass).Assembly).Run(args);
Console.ReadKey();


[MemoryDiagnoser]
[RankColumn]
public class BenchmarkClass
{
    PointClass pointClass1 = new PointClass(8, 15);
    PointClass pointClass2 = new PointClass(1, 22);
    PointStruct pointStruct1 = new PointStruct(1, 9);
    PointStruct pointStruct2 = new PointStruct(32, 4);

    [Benchmark]
    public void Test1()
    {
        DistanceCalculation.DistancePointClassFloat(pointClass1, pointClass2);
    }

    [Benchmark]
    public void Test2()
    {
        DistanceCalculation.DistancePointStructFloat(pointStruct1, pointStruct2);
    }

    [Benchmark]
    public void Test3()
    {
        DistanceCalculation.DistancePointStructDouble(pointStruct1, pointStruct2);
    }

    [Benchmark]
    public void Test4()
    {
        DistanceCalculation.DistancePointStructFloatWithoutSquareRoot(pointStruct1, pointStruct2);
    }
}

public static class DistanceCalculation
{
    /// <summary>
    /// 1) Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float)
    /// </summary>
    public static float DistancePointClassFloat(PointClass point1, PointClass point2)
    {
        float x = point1.x - point2.x;
        float y = point1.y - point2.y;
        return (float)Math.Sqrt((x * x) + (y * y));
    }

    /// <summary>
    /// 2) Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
    /// </summary>
    public static float DistancePointStructFloat(PointStruct point1, PointStruct point2)
    {
        float x = point1.x - point2.x;
        float y = point1.y - point2.y;
        return (float)Math.Sqrt((x * x) + (y * y));
    }

    /// <summary>
    /// 3) Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
    /// </summary>
    public static double DistancePointStructDouble(PointStruct point1, PointStruct point2)
    {
        double x = point1.x - point2.x;
        double y = point1.y - point2.y;
        return Math.Sqrt((x * x) + (y * y));
    }

    /// <summary>
    /// Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
    /// </summary>
    public static float DistancePointStructFloatWithoutSquareRoot(PointStruct point1, PointStruct point2)
    {
        float x = point1.x - point2.x;
        float y = point1.y - point2.y;
        return (x * x + y * y);
    }
}

public struct PointStruct
{
    public int x;
    public int y;
    public PointStruct(int value1, int value2)
    {
        x = value1;
        y = value2;
    }
}
public class PointClass
{
    public int x;
    public int y;
    public PointClass(int value1, int value2)
    {
        x = value1;
        y = value2;
    }
}