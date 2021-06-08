using FluentAssertions;
using NUnit.Framework;
using ShapeProcessor.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeProcessor.Tests
{
    [TestFixture]
    public class FileInputTests
    {
        [Test]
        public void CanReadTextFile()
        {
            var fileReader = new FileReader();

            var result = fileReader.Read();

            result.Should().BeEquivalentTo(new List<Shape>
            {
                new Shape(4, 4)
            });
        }
    }
}
