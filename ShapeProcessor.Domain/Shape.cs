namespace ShapeProcessor.Domain
{
    public class Shape
    {
        public int OriginalId { get; set; }

        public int NumberOfSides { get; set; }

        public int SideLengthInCentimetres { get; set; }

        public int PerimeterInCentimetres { get { return NumberOfSides * SideLengthInCentimetres; } }

        public PerimeterCategory PerimeterCategory { get { return GetPerimeterCategory(); } }

        private PerimeterCategory GetPerimeterCategory()
        {
            return PerimeterInCentimetres switch
            {
                int p when p >= 10 && p <= 19 => PerimeterCategory.Between10cmAnd19cm,
                int p when p >= 20 && p <= 49 => PerimeterCategory.Between20cmAnd49cm,
                int p when p >= 50 && p <= 99 => PerimeterCategory.Between50cmAnd99cm,
                int p when p >= 100 => PerimeterCategory.GreaterThanOrEqualTo100cm,
                _ => PerimeterCategory.Under10cm,
            };
        }

        public Shape(int originalId, int numberOfSides, int sideLengthInCentimetres)
        {
            OriginalId = originalId;
            NumberOfSides = numberOfSides;
            SideLengthInCentimetres = sideLengthInCentimetres;
        }
    }
}
