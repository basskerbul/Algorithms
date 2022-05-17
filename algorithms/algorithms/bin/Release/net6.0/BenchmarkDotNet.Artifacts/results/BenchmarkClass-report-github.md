``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
Intel Core i7-3537U CPU 2.00GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
| Method |      Mean |     Error |    StdDev |    Median | Rank | Allocated |
|------- |----------:|----------:|----------:|----------:|-----:|----------:|
|  Test1 | 4.6546 ns | 0.1295 ns | 0.1211 ns | 4.6499 ns |    3 |         - |
|  Test2 | 4.9956 ns | 0.0848 ns | 0.0751 ns | 4.9791 ns |    4 |         - |
|  Test3 | 0.0024 ns | 0.0083 ns | 0.0069 ns | 0.0000 ns |    1 |         - |
|  Test4 | 3.6501 ns | 0.0796 ns | 0.0706 ns | 3.6352 ns |    2 |         - |
