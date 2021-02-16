# Shape Generator #

## Introduction ##

This project draws a shape in SVG using a semi-natural language interface.  
Accepted input format:  
Draw a(n) <shape> with a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>)  

Example inputs:  
Draw a circle with a radius of 100  
Draw a square with a side length of 200  
Draw a rectangle with a width of 250 and a height of 400  
Draw an octagon with a side length of 200  
Draw an isosceles triangle with a height of 200 and a width of 100  

## Implementation ##

### Workflow ###

The service NaturalLanguageService converts the input to a 'Shape' object using the following Regex:

- "Draw \b(a|an)\b (?<shape>[a-zA-Z\s]*) with"

This regex identifies the shape

- "\b(and|with)\b a (?<key>[a-zA-Z\s]*) of (?<value>\d*)"

This regex identifies the attributes of the shape: 'side length', 'width', 'height'.  
The attributes are then allocated to the Shape using reflection and a custom attribute 'ParserAttribute'.  
This makes the function more flexible as it can now take an unlimited number of arguments 'with/and a(n) <measurement> of <amount>'.

### Validation ###

Validation is key here as the solution can take any input, so a number of checks have to be implemented to prevent errors.  
The error message needs to be clear so the user knows why a shape has not been generated.

- Sentence structure

The Regex above ensure that the input is formatted correctly

- Shape name

A 'switch' statement ensure that only the authorised shapes are accepted by the Language parser

- Invalid arguments

Using reflection, we ensure that only existing attributes are authorised.  
For instance, 'Draw an octagon with a height of 100' returns an error as 'height' is not an attribute of 'octagon'

- Invalid types

Validation ensures here that the correct types are sent to the properties.  
For instance, 'Draw a circle with a radius of abc' returns an error.

### Vertices coordinates calculation ###

In the controller, the method 'ToSvgString' of 'Shape' is called.  
'ToSvgString' is an abstract method that has multiple implementations, depending on the shape.  
'ToSvgString' calls the method 'CalculateVerticesPosition' which is also an abstract method that depends on the shape.

### Testing ###

The solution uses SpecFlow for Business Driven Development.  
The tests use the Gherkin syntax in plain English for better readability and maintainability of the tests.

## Technology used ##

- .Net Core
- Angular
- SVG
- xUnit
- SpecFlow