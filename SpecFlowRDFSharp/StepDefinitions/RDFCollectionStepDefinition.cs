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
        private RDFCollection? collection;

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

            collection?.AddItem(new RDFResource(testURI));

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

    }
}
