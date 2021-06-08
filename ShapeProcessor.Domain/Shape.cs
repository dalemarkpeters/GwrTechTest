namespace ShapeProcessor.Domain
{
    public class Shape
    {
        public int NumberOfSides { get; set; }

        public int SideLengthInCentimetres { get; set; }

        public Shape(int numberOfSides, int sideLengthInCentimetres)
        {
            NumberOfSides = numberOfSides;
            SideLengthInCentimetres = sideLengthInCentimetres;
        }

        public int CalculatePerimeter()
        {
            return NumberOfSides * SideLengthInCentimetres;
        }
    }
}
