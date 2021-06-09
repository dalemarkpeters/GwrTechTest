using NUnit.Framework;
using ShapeProcessor.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeProcessor.Tests
{
    [TestFixture]
    public class ShapeCategorisationTests
    {
        [Test]
        public void ShapeWithPerimeterOf9cmIsCategorisedAsUnder10cm()
        {
            var shape = new Shape(9, 1);

            Assert.AreEqual(PerimeterCategory.Under10cm, shape.PerimeterCategory);
        }

        [TestCase(10,1)]
        [TestCase(19,1)]
        [TestCase(15,1)]
        public void ShapeWithPerimeterOfBetween10cmAnd19cmIsCategorisedAsSuch(int numSides, int sideLengthCm)
        {
            var shape = new Shape(numSides, sideLengthCm);

            Assert.AreEqual(PerimeterCategory.Between10cmAnd19cm, shape.PerimeterCategory);
        }

        [TestCase(20, 1)]
        [TestCase(49, 1)]
        [TestCase(35, 1)]
        public void ShapeWithPerimeterOfBetween20cmAnd49cmIsCategorisedAsSuch(int numSides, int sideLengthCm)
        {
            var shape = new Shape(numSides, sideLengthCm);

            Assert.AreEqual(PerimeterCategory.Between20cmAnd49cm, shape.PerimeterCategory);
        }
    }
}
