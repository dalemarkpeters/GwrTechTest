namespace ShapeProcessor.Domain
{
    public class Shape
    {
        public int NumberOfSides { get; set; }

        public int SideLengthInCentimetres { get; set; }
        public PerimeterCategory PerimeterCategory { get { return GetPerimeterCategory(); } }

        private PerimeterCategory GetPerimeterCategory()
        {
            return CalculatePerimeter() switch
            {
                int p when p >= 10 && p <= 19 => PerimeterCategory.Between10cmAnd19cm,
                int p when p >= 20 && p <= 49 => PerimeterCategory.Between20cmAnd49cm,
                int p when p >= 50 && p <= 99 => PerimeterCategory.Between50cmAnd99cm,
                _ => PerimeterCategory.Under10cm,
            };
        }

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
