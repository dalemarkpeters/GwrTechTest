using ShapeProcessor.Domain;
using ShapesProcessor.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShapesProcessor.Input
{
    public class ShapesFileReader : IShapesFileReader
    {
        private const int SampleSize = 65;
        private const string RequiredFormat = "Shape Id,No. of Sides,Side Length (in cm)";

        private readonly Random _randomNumberGenerator;
        private readonly ILogger _logger;

        public ShapesFileReader(ILogger logger)
        {
            _randomNumberGenerator = new Random();
            _logger = logger;
        }

        public ICollection<Shape> ReadShapes(string filePath, bool fileHasHeader)
        {
            var shapesFromFile = new List<Shape>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file path given (\"{filePath}\") could not be found");
            }

            using (var reader = new StreamReader(filePath))
            {
                if (fileHasHeader)
                {
                    reader.ReadLine();
                }

                int lineNumber = 1;
                while (!reader.EndOfStream)
                {
                    _logger.Log($"Reading line {lineNumber}");
                    lineNumber++;
                    var currentLine = reader.ReadLine();
                    var elements = currentLine.Split(',');
                    ProcessElementsOfLine(shapesFromFile, lineNumber, elements);
                }
            }

            var randomShapesSample = shapesFromFile.OrderBy(x => _randomNumberGenerator.Next())
                .Take(SampleSize)
                .ToList();

            return randomShapesSample;
        }

        private void ProcessElementsOfLine(List<Shape> shapesFromFile, int lineNumber, string[] parts)
        {
            if (parts.Length >= 3)
            {
                if (int.TryParse(parts[1], out int numSides) && int.TryParse(parts[2], out int sideLengthCm) && int.TryParse(parts[0], out int originalId))
                {
                    shapesFromFile.Add(new Shape(originalId, numSides, sideLengthCm));
                }
                else
                {
                    _logger.Log($"One of the elements on line {lineNumber} could not be parsed. The required CSV format is \"{RequiredFormat}\"");
                }
            }
            else
            {
                _logger.Log($"There were not enough elements on line number {lineNumber} to be able to parse it. Required CSV format is \"{RequiredFormat}\"");
            }
        }
    }
}
