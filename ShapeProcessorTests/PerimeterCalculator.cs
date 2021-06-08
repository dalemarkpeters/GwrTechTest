using System;

namespace ShapeProcessorTests
{
    internal class PerimeterCalculator
    {
        internal int CalculatePerimeter(int numberOfSides, int sideLength)
        {
            return numberOfSides * sideLength;
        }
    }
}