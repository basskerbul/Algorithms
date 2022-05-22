``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
Intel Core i7-3537U CPU 2.00GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
| Method |      Mean |     Error |    StdDev |    Median | Rank | Allocated |
|------- |----------:|----------:|----------:|----------:|-----:|----------:|
|  Test1 | 4.1063 ns | 0.0729 ns | 0.0609 ns | 4.0923 ns |    3 |         - |
|  Test2 | 4.7248 ns | 0.0938 ns | 0.0831 ns | 4.7160 ns |    4 |         - |
|  Test3 | 0.0023 ns | 0.0078 ns | 0.0065 ns | 0.0000 ns |    1 |         - |
|  Test4 | 3.5685 ns | 0.0947 ns | 0.0839 ns | 3.5598 ns |    2 |         - |
