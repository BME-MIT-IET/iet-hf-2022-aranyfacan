using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDFSharp.Model;

namespace SpecFlowRDFSharp.StepDefinitions
{
    [Binding]
    internal class RDFCollectionStepDefinition
    {
        /// <summary>
        /// Contains the collection we are trying to test.
        /// </summary>
        private RDFCollection? collection;

        /// <summary>
        /// Contains a testresource.
        /// </summary>
        private RDFResource? resource;

        /// <summary>
        /// TestURI for creating Resources.
        /// </summary>
        private string testURI = @"https://www.reddit.com/";

        /// <summary>
        /// Tests the default constructor of the RDFCollection class.
        /// </summary>
        [Given("Create Collection")]
        public void GivenCreateRDFCollection()
        {
            collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);

            Assert.NotNull(collection);

            Assert.Equal(collection.ItemType.ToString(), RDFModelEnums.RDFItemTypes.Resource.ToString());
        }

        /// <summary>
        /// Tests the collection's Add method with RDFResource of the RDFCollection class.
        /// Should increment the Items list's count!
        /// </summary>
        [Given("Add Resource To Collection")]
        public void GivenAddResourceToCollection()
        {
            Assert.NotNull(collection);

            int prevSize = collection?.ItemsCount ?? 0;

            resource = new RDFResource(testURI);

            collection?.AddItem(resource);

            Assert.NotEqual(prevSize, collection?.ItemsCount);
        }

        /// <summary>
        /// Tests the collection's Add method with RDFLiteral of the RDFCollection class.
        /// Should NOT(!) increment the Items list's count!
        /// </summary>
        [Given("Add Literal To Collection")]
        public void GivenAddLiteralToCollection()
        {
            Assert.NotNull(collection);

            int prevSize = collection?.ItemsCount ?? 0;

            collection?.AddItem(new RDFPlainLiteral("hello", "en"));

            Assert.Equal(prevSize, collection?.ItemsCount);
        }

        /// <summary>
        /// Tests the Collection's remove function with trying to remove the added resource element.
        /// </summary>
        [Then("Remove the Added Resource from Collection")]
        public void ThenRemoveIndexFromCollection()
        {
            Assert.NotNull(collection);

            int prevSize = collection?.ItemsCount ?? 0;

            collection?.RemoveItem(resource);

            Assert.NotEqual(prevSize, collection?.ItemsCount);
        }

        /// <summary>
        /// Tests the collection's ReifyCollection function.
        /// It creates a (NOT NULL) reified graph from the collection.
        /// The collection's items should be the new graph's triples.
        /// </summary>
        [Then("Create Graph from Collection")]
        public void ThenCreateGraphFromCollection()
        {
            Assert.NotNull(collection);

            Assert.Equal(0, collection?.ItemsCount ?? 0);

            int size = 12;

            for (int i = 0; i < size; i++)
            {
                //testURI + i: because the collection doesn't contain duplicated data, uri must be uniqe
                collection?.AddItem(new RDFResource(testURI + i.ToString()));
            }

            var graph = collection?.ReifyCollection();

            Assert.NotNull(graph);

            Assert.Equal(size, collection?.ItemsCount);

            //For every item in this collection, the graph will contain 3 item (triples)
            //That's why the graph's triplescount must be 3x bigger then collection's itemscount
            Assert.Equal((graph?.TriplesCount).ToString(), (collection?.ItemsCount * 3).ToString());
        }
    }
}
