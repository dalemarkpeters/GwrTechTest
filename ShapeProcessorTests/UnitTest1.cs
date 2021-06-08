using NUnit.Framework;

namespace ShapeProcessorTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CanCalculatePerimeterOfAShapeGivenItsSideLengthAndNumberOfSides()
        {
            var perimeterCalculator = new PerimeterCalculator();

            var result = perimeterCalculator.CalculatePerimeter(numberOfSides: 6, sideLength: 2);

            Assert.AreEqual(12, result);
        }

        [Test]
        public void CanCalculatePerimeterOfShapeGiven8SidesOfLength8cm()
        {
            var perimeterCalculator = new PerimeterCalculator();

            var result = perimeterCalculator.CalculatePerimeter(numberOfSides: 8, sideLength: 8);

            Assert.AreEqual(64, result);
        }

        [Test]
        public void CanCalculatePerimeterOfShapeGiven1SideOf4cm()
        {
            var perimeterCalculator = new PerimeterCalculator();

            var result = perimeterCalculator.CalculatePerimeter(numberOfSides: 1, sideLength: 4);

            Assert.AreEqual(4, result);
        }
    }
}
