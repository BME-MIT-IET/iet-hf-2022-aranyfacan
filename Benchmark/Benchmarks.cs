using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using System;

namespace Benchmark
{
    public class Benchmarks
    {

        RDFGraph graph1 = new RDFGraph();
        RDFGraph graph2 = new RDFGraph();

        [Benchmark(Baseline = true)]
        public void Scenario1()
        {
            
        }

        [Benchmark]
        public void Scenario2()
        {
            // Implement your benchmark here
        }
    }
}
