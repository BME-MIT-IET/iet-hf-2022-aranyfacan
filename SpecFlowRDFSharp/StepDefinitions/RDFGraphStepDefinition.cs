using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDFSharp.Model;


namespace SpecFlowRDFSharp.StepDefinitions
{
    [Binding]
    public class RDFGraphStepDefinition
    {
        private RDFGraph? graph;

        private string testURI = @"https://www.reddit.com/";

        /// <summary>
        /// RDFGraph Test 1
        /// Create an RDFGraph instance with the default contstructor. Testing if graph.Context is set.
        /// </summary>
        [Given("Create RDFGraph")]
        public void GivenCreateGraph()
        {
            graph = new RDFGraph();

            Assert.NotNull(graph);
            Assert.Equal(graph.Context, RDFNamespaceRegister.DefaultNamespace.NamespaceUri);
        }

        /// <summary>
        /// Adds x new RDFTriple to the List.
        /// </summary>
        /// <param name="x">The number of Triples to add.</param>
        [Given("Add RDFTriples (.*)")]
        public void GivenXRDFTripleToTheGraph(int x)
        {
            Assert.NotNull(graph);

            for (int i = 0; i < x; i++)
            {
                RDFTriple rdft = new RDFTriple(new RDFResource(), new RDFResource(testURI), new RDFResource());
                graph?.AddTriple(rdft);
            }
            Assert.Equal(graph?.TriplesCount.ToString(), x.ToString());
        }

        /// <summary>
        /// Checks if the given index is a valid index in the TriplesList, and after checks it's Predicate URI.
        /// </summary>
        /// <param name="index">The number of Triples we want to get.</param>
        [Then("Get RDFTriple (.*)")]
        public void ThenGetRDFTripleFromGraph(int index)
        {
            if (index >= graph?.TriplesCount)
                return;

            var data = graph?.ElementAt(index);

            Assert.NotNull(data);

            Assert.Equal(data?.Predicate.ToString(), testURI);
        }

        /// <summary>
        /// Checks if the Union of 2 RDFGraph works by comparing the 2 graph's triplescount and the new graph's triplescount.
        /// </summary>
        [Then("Union of graphs")]
        public void ThenCreateUnionWithGraph()
        {
            var graph2 = new RDFGraph();

            for (int i = 0; i < 100; i++)
            {
                graph2?.AddTriple(new RDFTriple(new RDFResource(), new RDFResource(testURI), new RDFResource()));
            }

            var unionGraph = graph?.UnionWith(graph2);

            Assert.NotNull(unionGraph);

            Assert.Equal(unionGraph?.TriplesCount.ToString(), (graph?.TriplesCount + graph2?.TriplesCount).ToString());
        }
    }
}
