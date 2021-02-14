using Xunit;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.IO;
using ShapeGenerator.Core.Classes;
using Core.Services.Classes;

namespace ShapeGenerator.Test
{
    [Binding]
    public class TestNaturalLanguageService
    {
        private readonly NaturalLanguageService parser = new NaturalLanguageService();
        private readonly List<object> result_parsing = new List<object>();
        private string input_shape;
        private Shape result_shape;
        private const int center_x = 400;
        private const int center_y = 400;

        // AAA pattern: Arrange, Act, Assert
        // Using SpecFlow for Behavior Driven Development

        // Arrange

        [Given(@"the input is '(.*)'")]
        public void GivenTheInputIs(string input)
        {
            input_shape = input;
        }

        [Given(@"the input is the following")]
        public void GivenTheInputIsTheFollowing(Table table)
        {
            foreach (var item in table.Rows)
            {
                try
                {
                    result_parsing.Add(parser.Compile(item[0], center_x, center_y));
                }
                catch (Exception e)
                {
                    result_parsing.Add(e);
                }
            }
        }

        // Act

        [When(@"the input is compiled")]
        public void WhenTheInputIsCompiled()
        {
            result_shape = parser.Compile(input_shape, center_x, center_y);
        }

        // Assert

        [Then(@"the parser should return an error")]
        public void ThenTheParserShouldReturnAnError()
        {
            foreach (var item in result_parsing)
            {
                Assert.True(item is InvalidDataException);
            }
        }

        [Then(@"the parser should return a square with (.*) vertices")]
        public void ThenTheParserShouldReturnASquareWithVertices(int vertices_count)
        {
            var square = (Square)result_shape;
            square.CalculateVerticesPosition();

            Assert.True(square is Square);
            Assert.Equal(vertices_count, square.Vertices.Count);
        }

        [Then(@"the parser should return a regular polygon with (.*) vertices")]
        public void ThenTheParserShouldReturnARegularPolygonWithVertices(int vertices_count)
        {
            Assert.True(result_shape is RegularPolygon);
            Assert.Equal(vertices_count, ((RegularPolygon)result_shape).VerticesCount);
        }

        [Then(@"a side length of (.*)")]
        public void ThenASideLengthOf(int side_length)
        {
            var regular_polygon = (RegularPolygon)result_shape;
            regular_polygon.CalculateVerticesPosition();

            for (int i = 0; i < regular_polygon.VerticesCount - 1; i++)
            {
                Assert.Equal(side_length, regular_polygon.Vertices[i].Distance(regular_polygon.Vertices[i + 1]), 0);
            }
        }
    }
}
