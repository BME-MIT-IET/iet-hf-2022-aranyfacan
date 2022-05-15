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


    }
}
