``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
Intel Core i7-3537U CPU 2.00GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|            Method |         Mean |        Error |       StdDev | Rank |  Gen 0 | Allocated |
|------------------ |-------------:|-------------:|-------------:|-----:|-------:|----------:|
|   TestArraySearch | 368,813.8 ns | 10,196.90 ns | 28,255.55 ns |    2 |      - |     129 B |
| TestHashsetSearch |     619.2 ns |     10.46 ns |      8.73 ns |    1 | 0.3443 |     720 B |
