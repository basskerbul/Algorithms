using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


//BenchmarkRunner.Run<Program>();

//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

BenchmarkSwitcher.FromAssembly(typeof(BenchmarkSwitcher).Assembly).Run(args);

[MemoryDiagnoser]
[RankColumn]
public class BenchmarkClass
{
    PointClass pointClass1 = new PointClass(8, 15);
    PointClass pointClass2 = new PointClass(1, 22);
    PointStruct pointStruct1 = new PointStruct(1, 9);
    PointStruct pointStruct2 = new PointStruct(32, 4);

    [Benchmark]
    void Test1()
    {
        DistanceCalculation.DistancePointClassFloat(pointClass1, pointClass2);
    }

    [Benchmark]
    void Test2()
    {
        DistanceCalculation.DistancePointStructFloat(pointStruct1, pointStruct2);
    }

    [Benchmark]
    void Test3()
    {
        DistanceCalculation.DistancePointStructDouble(pointStruct1, pointStruct2);
    }

    [Benchmark]
    void Test4()
    {
        DistanceCalculation.DistancePointStructFloatWithoutSquareRoot(pointStruct1, pointStruct2);
    }
}