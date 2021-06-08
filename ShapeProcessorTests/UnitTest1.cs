using NUnit.Framework;
using ShapeProcessor.Domain;

namespace ShapeProcessorTests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(6, 2, 12)]
        [TestCase(8, 8, 64)]
        [TestCase(1, 4, 4)]
        public void CanCalculatePerimeterOfAShapeGivenItsSideLengthAndNumberOfSides(int numSides, int sideLength, int expectedResult)
        {
            var shape = new Shape(numSides, sideLength);

            var result = shape.CalculatePerimeter();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
