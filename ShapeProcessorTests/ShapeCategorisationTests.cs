using NUnit.Framework;
using ShapeProcessor.Domain;

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

        [TestCase(10, 1)]
        [TestCase(19, 1)]
        [TestCase(15, 1)]
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

        [TestCase(50, 1)]
        [TestCase(99, 1)]
        [TestCase(75, 1)]
        public void ShapeWithPerimeterOfBetween50cmAnd99cmIsCategorisedAsSuch(int numSides, int sideLengthCm)
        {
            var shape = new Shape(numSides, sideLengthCm);

            Assert.AreEqual(PerimeterCategory.Between50cmAnd99cm, shape.PerimeterCategory);
        }

        [TestCase(100, 1)]
        [TestCase(101, 1)]
        [TestCase(int.MaxValue, 1)]
        public void ShapeWithPerimeterOf100cmOrOverIsCategorisedAsSuch(int numSides, int sideLengthCm)
        {
            var shape = new Shape(numSides, sideLengthCm);

            Assert.AreEqual(PerimeterCategory.GreaterThanOrEqualTo100cm, shape.PerimeterCategory);
        }
    }
}
