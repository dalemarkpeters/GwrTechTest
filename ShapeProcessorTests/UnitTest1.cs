using NUnit.Framework;

namespace ShapeProcessorTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CanCalculatePerimeterOfAShapeGivenItsSideLengthAndNumberOfSides()
        {
            var diameterCalculator = new DiameterCalculator();

            var result = diameterCalculator.CalculateDiameter(numberOfSides: 6, sideLength: 2);

            Assert.AreEqual(12, result);
        }
    }
}
