using ShapeProcessor.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShapesProcessor.Input
{
    public class ShapesReader
    {
        private const int SampleSize = 65;
        private readonly Random _randomNumberGenerator;

        public ShapesReader()
        {
            _randomNumberGenerator = new Random();
        }

        public ICollection<Shape> Read(string filePath, bool fileHasHeader)
        {
            // Does the file exist?

            var shapesFromFile = new List<Shape>();

            using (var reader = new StreamReader(filePath))
            {
                if (fileHasHeader)
                {
                    reader.ReadLine();
                }

                while (!reader.EndOfStream)
                {
                    var currentLine = reader.ReadLine();
                    var parts = currentLine.Split(',');

                    if (parts.Length == 3)
                    {
                        if (int.TryParse(parts[1], out int numSides) && int.TryParse(parts[2], out int sideLengthCm) && int.TryParse(parts[0], out int originalId))
                        {
                            shapesFromFile.Add(new Shape(originalId, numSides, sideLengthCm));
                        }
                        else
                        {
                            // Log
                        }
                    }
                    else
                    {
                        // Log
                    }
                }
            }

            var randomShapesSample = shapesFromFile.OrderBy(x => _randomNumberGenerator.Next())
                .Take(SampleSize)
                .ToList();

            return randomShapesSample;
        }
    }
}
