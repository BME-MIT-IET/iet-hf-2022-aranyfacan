using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDFSharp.Model;
using RDFSharp.Query;

namespace SpecFlowRDFSharp.StepDefinitions
{
    [Binding]
    internal class RDFQueryProductPriceStepDefinitions
    {
        /// <summary>
        /// Stores the graph for the query
        /// </summary>
        private RDFGraph? graph;
        /// <summary>
        /// Stores the query itself.
        /// </summary>
        private RDFSelectQuery? query;
        /// <summary>
        /// Stores the result of the query.
        /// </summary>
        private RDFSelectQueryResult? result;
        /// <summary>
        /// Contains the test URI for testing.
        /// </summary>
        private string testURI = @"http://test.hu/";
        /// <summary>
        /// Minimum price for testing the query.
        /// </summary>
        private int minimumPrice = 10;
        /// <summary>
        /// Maximum price for testing the query.
        /// </summary>
        private int maximumPrice = 0;
        /// <summary>
        /// Prive of the variable.
        /// </summary>
        RDFVariable? priceVAR = null;
        /// <summary>
        /// Creates an empty graph.
        /// </summary>
        [Given("Create Graph For Query")]
        public void GivenCreateGraph()
        {
            graph = new RDFGraph();

            Assert.NotNull(graph);
        }

        /// <summary>
        /// Fills the empty graph with X products.
        /// </summary>
        /// <param name="p">Number of products to insert.</param>
        [Given("Fill Graph with (.*) Products")]
        public void GivenFillGraph(int p)
        {
            Random random = new Random();
            for(int i = 0; i < p; i++)
            {
                var product = new RDFResource(testURI + "product" + random.Next(0,100).ToString());

                var meaning = new RDFResource(testURI + "PriceOfProduct");

                var price = new RDFTypedLiteral(random.Next(100, 200).ToString(), RDFModelEnums.RDFDatatypes.XSD_INTEGER);

                if (i == 0)
                    price = new RDFTypedLiteral(minimumPrice.ToString(), RDFModelEnums.RDFDatatypes.XSD_INTEGER);
                else
                {
                    if(int.Parse(price.Value) > maximumPrice)
                        maximumPrice = int.Parse(price.Value);
                }
                
                var triple = new RDFTriple(product, meaning, price);

                graph?.AddTriple(triple);
            }

            Assert.Equal(p, graph?.TriplesCount);
        }

        /// <summary>
        /// Creates and run a query to get the cheapest product from the graph.
        /// </summary>
        [Given("Create Query")]
        public void GivenCreateQuery()
        {
            query = new RDFSelectQuery();

            Assert.NotNull(query);

            var patternGroupName = "MinimumPriced";

            var product = new RDFVariable("product");

            var meaning = new RDFResource(testURI + "PriceOfProduct");

            priceVAR = new RDFVariable("price");

            var patterns = new List<RDFPattern>();
            patterns.Add(new RDFPattern(product, meaning, priceVAR));

            var patternGroup = new RDFPatternGroup(patternGroupName, patterns);

            query.AddPatternGroup(patternGroup);

            query.AddProjectionVariable(product);
            query.AddProjectionVariable(priceVAR);

            query.AddModifier(new RDFLimitModifier(1));
        }

        /// <summary>
        /// Depending on the input, add's an Order Modifier to the Query.
        /// </summary>
        /// <param name="order">Must be "asc" or "desc"</param>
        [Given("Query Order is (.*)")]
        public void GivenOrderQuery(string order = "asc")
        {
            Assert.NotNull(priceVAR);

            if(order == "asc")
                query?.AddModifier(new RDFOrderByModifier(priceVAR, RDFQueryEnums.RDFOrderByFlavors.ASC));
            else
                query?.AddModifier(new RDFOrderByModifier(priceVAR, RDFQueryEnums.RDFOrderByFlavors.DESC));
        }

        /// <summary>
        /// Runs the query on a graph.
        /// </summary>
        [Then("Run the Query")]
        public void ThenRunQuery()
        {
            result = query?.ApplyToGraph(graph);
        }

        /// <summary>
        /// Depending on the input, checks the lowest and the highest price.
        /// </summary>
        /// <param name="minOrMax">Must be "min" for lowest and "max" for highest.</param>
        [Then("Get the (.*) product")]
        public void ThenGetMinOrMaxProduct(string minOrMax = "min")
        {
            Assert.NotNull(result);

            //Result has only 1 element
            Assert.Equal(1.ToString(), result?.SelectResultsCount.ToString());

            //Checking if the found min or max value is really the min or max.
            if(minOrMax == "min")
                Assert.Equal(minimumPrice.ToString(), result?.SelectResults?.Rows[0]?.ItemArray[1]?.ToString()?.Split("^")[0]);
            else
                Assert.Equal(maximumPrice.ToString(), result?.SelectResults?.Rows[0]?.ItemArray[1]?.ToString()?.Split("^")[0]);
        }
    }
}
