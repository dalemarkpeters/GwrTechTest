using System;

namespace ShapeProcessorTests
{
    internal class PerimeterCalculator
    {
        internal int CalculateDiameter(int numberOfSides, int sideLength)
        {
            return numberOfSides * sideLength;
        }
    }
}