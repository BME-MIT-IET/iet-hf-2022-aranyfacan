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