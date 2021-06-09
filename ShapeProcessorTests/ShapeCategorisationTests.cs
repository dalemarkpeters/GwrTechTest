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
        public void ShapeWithPerimeterOf9cmIsCategorisedAsSuchUnder10cm()
        {
            var shape = new Shape(9, 1);

            Assert.AreEqual(PerimeterCategory.Under10cm, shape.PerimeterCategory);
        }

        [Test]
        public void ShapeWithPerimeterOf10cmIsCategorisedAsBetween10cmAnd19cm()
        {
            var shape = new Shape(10, 1);

            Assert.AreEqual(PerimeterCategory.Between10cmAnd19cm, shape.PerimeterCategory);
        }

        [Test]
        public void ShapeWithPerimeterOf19cmIsCategorisedAsBetween10cmAnd19cm()
        {
            var shape = new Shape(19, 1);

            Assert.AreEqual(PerimeterCategory.Between10cmAnd19cm, shape.PerimeterCategory);
        }
    }
}
