using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowRDFSharp.StepDefinitions
{
    [Binding]
    public class RDFGraphStepDefinition
    {
        private RDFSharp.Model.RDFGraph? graph;

        [Given("Create RDFGraph")]
        public void GivenCreateGraph()
        {
            
            graph = new RDFSharp.Model.RDFGraph();

            Assert.NotNull(graph);
            Assert.Equal(graph.Context, RDFSharp.Model.RDFNamespaceRegister.DefaultNamespace.NamespaceUri);
        }
    }
}
