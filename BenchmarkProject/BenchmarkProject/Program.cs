using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    //[MemoryDiagnoser]
    [RankColumn]
    public class BechmarkClass
    {
        public int SumValueType(int value)
        {
            return 9 + value;
        }
        public int SumRefType(object value)
        {
            return 9 + (int)value;
        }
        [Benchmark]
        public void TestSum()
        {
            SumValueType(99);
        }
        [Benchmark]
        public void TestSumBoxing()
        {
            object x = 99;
            SumRefType(x);
        }
    }

}
