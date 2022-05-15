Feature: RDFQuery

Testing the RDFQuery class by creating a simple query on a graph

@rdfQueryProductNamePriceLowest
Scenario: Create query on Graph with Products for lowest Price
	Given Create Graph For Query
	And Fill Graph with 10 Products
	And Create Query
	Given Query Order is asc
	Then Run the Query
	Then Get the min product

@rdfQueryProductNamePriceHighest
Scenario: Create query on Graph with Products for highest Price
	Given Create Graph For Query
	And Fill Graph with 10 Products
	And Create Query
	Given Query Order is desc
	Then Run the Query
	Then Get the max product