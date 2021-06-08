using NUnit.Framework;

namespace ShapeProcessorTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CanCalculatePerimeterOfAShapeGivenItsSideLengthAndNumberOfSides()
        {
            var diameterCalculator = new PerimeterCalculator();

            var result = diameterCalculator.CalculateDiameter(numberOfSides: 6, sideLength: 2);

            Assert.AreEqual(12, result);
        }

        [Test]
        public void CanCalculatePerimeterOfShapeGiven8SidesOfLength8cm()
        {
            var diameterCalculator = new PerimeterCalculator();

            var result = diameterCalculator.CalculateDiameter(numberOfSides: 8, sideLength: 8);

            Assert.AreEqual(64, result);
        }
    }
}
