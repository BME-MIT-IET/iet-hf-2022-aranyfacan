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
            //DirectoryInfo asd = new DirectoryInfo(@"..\..\..\..\xml.txt");
            //Console.WriteLine(asd.FullName);

            var xmlFormat = RDFModelEnums.RDFFormats.RdfXml;
            var turtleFormat = RDFModelEnums.RDFFormats.Turtle;
            var ntriplesFormat = RDFModelEnums.RDFFormats.NTriples;
            var trixFormat = RDFModelEnums.RDFFormats.TriX;

            //READ RDF/XML FILE
            //file location needs to be iet-hf-2022-aranyfacan\xml.rdf
            File.SetAttributes(@"..\..\..\..\..\..\..\..\xml.rdf", FileAttributes.Normal);
            var graph = RDFGraph.FromFile(xmlFormat, @"..\..\..\..\..\..\..\..\xml.rdf");

            graph.ToFile(turtleFormat, @"..\..\..\..\..\..\..\..\turtle.ttl");
            graph.ToFile(trixFormat, @"..\..\..\..\..\..\..\..\trix.trix");
            graph.ToFile(ntriplesFormat, @"..\..\..\..\..\..\..\..\ntriples.nt");

            //READ TURTLE FILE
            File.SetAttributes(@"..\..\..\..\..\..\..\..\turtle.ttl", FileAttributes.Normal);
            var graphFromTurtle = RDFGraph.FromFile(turtleFormat, @"..\..\..\..\..\..\..\..\turtle.ttl");

            // READ TRIX FILE
            File.SetAttributes(@"..\..\..\..\..\..\..\..\trix.trix", FileAttributes.Normal);
            var graphFromTrix = RDFGraph.FromFile(trixFormat, @"..\..\..\..\..\..\..\..\trix.trix");

            // READ N-TRIPLES FILE
            File.SetAttributes(@"..\..\..\..\..\..\..\..\ntriples.nt", FileAttributes.Normal);
            var graphNTrples = RDFGraph.FromFile(ntriplesFormat, @"..\..\..\..\..\..\..\..\ntriples.nt");
        }

        [Benchmark]
        public void Scenario2()
        {
            //var xmlFormat = RDFModelEnums.RDFFormats.RdfXml;
            //// READ RDF/XML FILE
            ////az xml.txt a C:\\xml.txt

            //File.SetAttributes("C:\\xml.txt", FileAttributes.Normal);
            //var graph = RDFGraph.FromFile(xmlFormat, "C:\\xml.txt");
            //Console.WriteLine("Graph from xml file: " + graph.ToString());

            //var turtleFormat = RDFModelEnums.RDFFormats.Turtle;
            //File.SetAttributes("C:\\turtle.txt", FileAttributes.Normal);
            //var graphFromTurtle = RDFGraph.FromFile(turtleFormat, "C:\\turtle.txt");
            //Console.WriteLine("Graph from turtle file: " + graphFromTurtle.ToString());

            //File.SetAttributes("C:\\trix.txt", FileAttributes.Normal);
            //var trixFormat = RDFModelEnums.RDFFormats.TriX;
            //// READ TRIX FILE
            //var graphFromTrix = RDFGraph.FromFile(trixFormat, "C:\\trix.txt");
        }

    }
}
