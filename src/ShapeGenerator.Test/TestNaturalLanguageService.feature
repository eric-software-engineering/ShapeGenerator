Feature: TestNaturalLanguageService
	Testing the natural language parser

Scenario: Invalid inputs
	Given the input is the following
		| Input                                               |
		| wrong input                                         |
		| Draw an hexagon                                     |
		| Draw a circle with a radius of abc                  |
		| Draw a square with a side length                    |
		| a rectangle with a width of 250 and a height of 400 |
	Then the parser should return an error

Scenario: Square
	Given the input is 'Draw an square with a side length of 100'
	When the input is compiled
	Then the parser should return a square with 4 vertices

Scenario: Pentagon
	Given the input is 'Draw an hexagon with a side length of 100'
	When the input is compiled
	Then the parser should return a regular polygon with 6 vertices
	And a side length of 100

Scenario: Octagon
	Given the input is 'Draw an octagon with a side length of 200'
	When the input is compiled
	Then the parser should return a regular polygon with 8 vertices
	And a side length of 200