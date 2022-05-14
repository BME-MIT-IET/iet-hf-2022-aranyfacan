Feature: RDFGraph
	Testing RDFGraph creation and it's methods

@rdfgraph
Scenario: Create RDFGraph
	Given Create RDFGraph
	Given Add RDFTriples 100
	Then Get RDFTriple 1
	Then Union of graphs
