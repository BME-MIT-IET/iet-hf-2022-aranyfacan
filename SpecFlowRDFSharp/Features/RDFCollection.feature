Feature: RDFCollection

Tests the RDFCollection class and a subset of it's methods

@collection
Scenario: Testing Collection class
	Given Create Collection
	And Add Resource To Collection
	And Add Literal To Collection
	Then Remove the Added Resource from Collection
	Then Create Graph from Collection