using System;

namespace ShapeProcessor.Domain
{
    public class Shape
    {
        public int NumberOfSides { get; set; }

        public int SideLengthInCentimetres { get; set; }
        public PerimeterCategory PerimeterCategory { get { return GetPerimeterCategory(); }}

        private PerimeterCategory GetPerimeterCategory()
        {
            switch (CalculatePerimeter())
            {
                case int p when p >= 10 && p <= 19:
                    return PerimeterCategory.Between10cmAnd19cm;
                default:
                    return PerimeterCategory.Under10cm;
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
