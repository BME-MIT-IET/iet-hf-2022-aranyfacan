using RDFSharp.Model;

//Added resource with URI
var shrek = new RDFResource("https://hu.wikipedia.org/wiki/Shrek");

//Added blank resource 
var donkey = new RDFResource();

//Added plain literal
var fiona = new RDFPlainLiteral("Fiona :')");
Console.WriteLine("Fiona's data: " + fiona.ToString());

//Added plain literal with language tag
var puss = new RDFPlainLiteral(";)   ", "kk-KAZ");

Console.WriteLine("Puss's data: " + puss.ToString());

//Added triple
var farquaad = new RDFTriple(
        new RDFResource("https://i.pinimg.com/736x/c4/4c/32/c44c32c980f82e8fe5d19cb13d415a83.jpg"),
        new RDFResource("https://i.pinimg.com/originals/3c/2d/27/3c2d271e4e6c1971e0d4d19977f88438.jpg"),
        new RDFTypedLiteral("12", RDFModelEnums.RDFDatatypes.XSD_INTEGER)
    );

Console.WriteLine("Farquaad's data: " + farquaad.ToString());

//DirectoryInfo asd = new DirectoryInfo(@"..\..\..\..\xml.txt");
//Console.WriteLine(asd.FullName);

var xmlFormat = RDFModelEnums.RDFFormats.RdfXml;
var turtleFormat = RDFModelEnums.RDFFormats.Turtle;
var ntriplesFormat = RDFModelEnums.RDFFormats.NTriples;
var trixFormat = RDFModelEnums.RDFFormats.TriX;

//READ RDF/XML FILE
//file location needs to be iet-hf-2022-aranyfacan\xml.rdf
File.SetAttributes(@"..\..\..\..\xml.rdf", FileAttributes.Normal);
var graph = RDFGraph.FromFile(xmlFormat, @"..\..\..\..\xml.rdf");
Console.WriteLine("\r\nGraph from xml file: " + graph.ToString());
foreach (var triple in graph.ToList())
{
    Console.WriteLine(triple.ToString());
}

graph.ToFile(turtleFormat, @"..\..\..\..\turtle.ttl");
graph.ToFile(trixFormat, @"..\..\..\..\trix.trix");
graph.ToFile(ntriplesFormat, @"..\..\..\..\ntriples.nt");

//READ TURTLE FILE
File.SetAttributes(@"..\..\..\..\turtle.ttl", FileAttributes.Normal);
var graphFromTurtle = RDFGraph.FromFile(turtleFormat, @"..\..\..\..\turtle.ttl");
Console.WriteLine("\r\nGraph from turtle file: " + graphFromTurtle.ToString());
foreach (var triple in graphFromTurtle.ToList())
{
    Console.WriteLine(triple.ToString());
}

// READ TRIX FILE
File.SetAttributes(@"..\..\..\..\trix.trix", FileAttributes.Normal);
var graphFromTrix = RDFGraph.FromFile(trixFormat, @"..\..\..\..\trix.trix");
Console.WriteLine("\r\nGraph from trix file: " + graphFromTrix.ToString());
foreach (var triple in graphFromTrix.ToList())
{
    Console.WriteLine(triple.ToString());
}

// READ N-TRIPLES FILE
File.SetAttributes(@"..\..\..\..\ntriples.nt", FileAttributes.Normal);
var graphNTrples = RDFGraph.FromFile(ntriplesFormat, @"..\..\..\..\ntriples.nt");
Console.WriteLine("\r\nGraph from ntriples file: " + graphNTrples.ToString());
foreach (var triple in graphNTrples.ToList())
{
    Console.WriteLine(triple.ToString());
}
