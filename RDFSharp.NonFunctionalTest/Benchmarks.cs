using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using RDFSharp.Model;
using System;
using System.IO;
using System.Linq;

namespace RDFSharp.NonFunctionalTest
{
    public class Benchmarks
    {
        RDFGraph graph1 = new RDFGraph();
        RDFGraph graph2 = new RDFGraph();

        public void createGraph()
        {

        }

        [Benchmark(Baseline = true)]
        public void Scenario1()
        {

        }

        [Benchmark]
        public void Scenario2()
        {
            var xmlFormat = RDFModelEnums.RDFFormats.RdfXml;
            // READ RDF/XML FILE
            //az xml.txt a C:\\xml.txt

            File.SetAttributes("C:\\xml.txt", FileAttributes.Normal);
            var graph = RDFGraph.FromFile(xmlFormat, "C:\\xml.txt");
            Console.WriteLine("Graph from xml file: " + graph.ToString());

            var turtleFormat = RDFModelEnums.RDFFormats.Turtle;
            File.SetAttributes("C:\\turtle.txt", FileAttributes.Normal);
            var graphFromTurtle = RDFGraph.FromFile(turtleFormat, "C:\\turtle.txt");
            Console.WriteLine("Graph from turtle file: " + graphFromTurtle.ToString());

            File.SetAttributes("C:\\trix.txt", FileAttributes.Normal);
            var trixFormat = RDFModelEnums.RDFFormats.TriX;
            // READ TRIX FILE
            var graphFromTrix = RDFGraph.FromFile(trixFormat, "C:\\trix.txt");
        }

    }
}
