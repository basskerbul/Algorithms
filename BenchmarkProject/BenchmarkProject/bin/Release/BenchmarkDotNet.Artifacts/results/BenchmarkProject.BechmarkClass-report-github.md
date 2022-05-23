``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1645 (21H2)
Intel Core i7-3537U CPU 2.00GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4470.0), X86 LegacyJIT  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4470.0), X86 LegacyJIT


```
|        Method |      Mean |     Error |    StdDev | Rank |
|-------------- |----------:|----------:|----------:|-----:|
|       TestSum | 0.0000 ns | 0.0000 ns | 0.0000 ns |    1 |
| TestSumBoxing | 3.7179 ns | 0.1072 ns | 0.1002 ns |    2 |
