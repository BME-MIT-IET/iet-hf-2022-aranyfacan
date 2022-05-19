using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using RDFSharp.Model;
using System;
using System.IO;
using System.Linq;

namespace RDFSharp.NonFunctionalTest
{
    [SimpleJob(launchCount: 1, warmupCount: 5, targetCount: 20)]
    public class Benchmarks
    {
        RDFModelEnums.RDFFormats xmlFormat = RDFModelEnums.RDFFormats.RdfXml;
        RDFModelEnums.RDFFormats turtleFormat = RDFModelEnums.RDFFormats.Turtle;
        RDFModelEnums.RDFFormats ntriplesFormat = RDFModelEnums.RDFFormats.NTriples;
        RDFModelEnums.RDFFormats trixFormat = RDFModelEnums.RDFFormats.TriX;

        [GlobalSetup]
        public void GlobalSetup()
        {
            //file location needs to be iet-hf-2022-aranyfacan\xml.rdf
            File.SetAttributes(@"..\..\..\..\..\..\..\..\xml.rdf", FileAttributes.Normal);
            File.SetAttributes(@"..\..\..\..\..\..\..\..\turtle.ttl", FileAttributes.Normal);
            File.SetAttributes(@"..\..\..\..\..\..\..\..\trix.trix", FileAttributes.Normal);
            File.SetAttributes(@"..\..\..\..\..\..\..\..\ntriples.nt", FileAttributes.Normal);
        }

        [Benchmark]
        public void Scenario1()
        {
            //READ RDF/XML FILE
            //file location needs to be iet-hf-2022-aranyfacan\xml.rdf
            var graph = RDFGraph.FromFile(xmlFormat, @"..\..\..\..\..\..\..\..\xml.rdf");

            //graph.ToFile(turtleFormat, @"..\..\..\..\..\..\..\..\turtle.ttl");
            //graph.ToFile(trixFormat, @"..\..\..\..\..\..\..\..\trix.trix");
            //graph.ToFile(ntriplesFormat, @"..\..\..\..\..\..\..\..\ntriples.nt");
        }

        [Benchmark]
        public void Scenario2()
        {
            //READ TURTLE FILE
            var graphFromTurtle = RDFGraph.FromFile(turtleFormat, @"..\..\..\..\..\..\..\..\turtle.ttl");
        }
        [Benchmark]
        public void Scenario3()
        {
            // READ TRIX FILE
            var graphFromTrix = RDFGraph.FromFile(trixFormat, @"..\..\..\..\..\..\..\..\trix.trix");
        }

        [Benchmark]
        public void Scenario4()
        {
            // READ N-TRIPLES FILE
            var graphNTrples = RDFGraph.FromFile(ntriplesFormat, @"..\..\..\..\..\..\..\..\ntriples.nt");
        }

        // Create triple with resource, vocabulary, typedliteral
        [Benchmark]
        public void Scenario5()
        {
            RDFGraph graph = new RDFGraph();

            for (int i = 0; i < 100; i++)
            {
                var resource = new RDFResource(RDFVocabulary.RDF.BASE_URI + "resource" + i);
                var vocabulary = RDFVocabulary.RDF.TYPE;
                var typedLiteral = new RDFTypedLiteral("true", RDFModelEnums.RDFDatatypes.XSD_BOOLEAN);
                graph.AddTriple(new RDFTriple(resource, vocabulary, typedLiteral));
            }
        }

        // Create triple with resource, vocabulary, plainliteral
        [Benchmark]
        public void Scenario6()
        {
            RDFGraph graph = new RDFGraph();

            for (int i = 0; i < 100; i++)
            {
                var resource = new RDFResource(RDFVocabulary.RDFSHARP.BASE_URI + "resource" + i);
                var vocabulary = RDFVocabulary.RDF.VALUE;
                var plainLiteral = new RDFPlainLiteral("literal");
                graph.AddTriple(new RDFTriple(resource, vocabulary, plainLiteral));
            }
        }

        // Create container with containertypes, itemtypes
        [Benchmark]
        public void Scenario7()
        {
            RDFGraph graph = new RDFGraph();

            for (int i = 0; i < 100; i++)
            {
                var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Seq, RDFModelEnums.RDFItemTypes.Resource);
                graph.AddContainer(container);
            }
        }

        // Create collection with itemtypes
        [Benchmark]
        public void Scenario8()
        {
            RDFGraph graph = new RDFGraph();

            for (int i = 0; i < 100; i++)
            {
                var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
                graph.AddCollection(collection);
            }
        }
    }
}
