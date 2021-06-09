using FluentAssertions;
using NUnit.Framework;
using ShapeProcessor.Domain;
using ShapesProcessor.Input;
using System.Collections.Generic;

namespace ShapeProcessor.Tests
{
    [TestFixture]
    public class FileInputTests
    {
        [Test]
        public void CanReturnNewListOfShapes()
        {
            var fileReader = new ShapesReader();

            var result = fileReader.Read("shapes.csv", true);

            result.Should().BeEquivalentTo(new List<Shape>
            {
                new Shape(4, 4)
            });
        }

        [Test]
        public void CanReadTextFileGivenName()
        {
            var fileReader = new ShapesReader();

            var result = fileReader.Read("shapes.csv", true);

            result.Should().BeEquivalentTo(new List<Shape>
            {
                new Shape(4, 4)
            });
        }
    }
}
