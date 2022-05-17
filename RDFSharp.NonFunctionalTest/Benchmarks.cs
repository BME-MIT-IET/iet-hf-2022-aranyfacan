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
            RDFGraph graph1_1 = new RDFGraph();
            RDFGraph graph1_2 = new RDFGraph();
            RDFGraph graph2 = new RDFGraph();
            RDFGraph graph3 = new RDFGraph();

            for (int i = 0; i < 100; i++)
            {
                var resource1_1 = new RDFResource(RDFVocabulary.RDF.BASE_URI + "resource" + i);
                var vocabulary1_1 = RDFVocabulary.RDF.TYPE;
                var typedLiteral = new RDFTypedLiteral("true", RDFModelEnums.RDFDatatypes.XSD_BOOLEAN);
                graph1_1.AddTriple(new RDFTriple(resource1_1, vocabulary1_1, typedLiteral));
            }

            for (int i = 0; i < 100; i++)
            {
                var resource1_2 = new RDFResource(RDFVocabulary.RDFSHARP.BASE_URI + "resource" + i);
                var vocabulary1_2 = RDFVocabulary.RDF.VALUE;
                var plainLiteral = new RDFPlainLiteral("literal");
                graph1_2.AddTriple(new RDFTriple(resource1_2, vocabulary1_2, plainLiteral));
            }

            for (int i = 0; i < 100; i++)
            {
                var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Seq, RDFModelEnums.RDFItemTypes.Resource);
                graph2.AddContainer(container);
            }

            for (int i = 0; i < 100; i++)
            {
                var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
                graph3.AddCollection(collection);
            }
        }
    }
}
