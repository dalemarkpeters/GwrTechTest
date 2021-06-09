using ShapeProcessor.Domain;
using System.Collections.Generic;
using System.IO;

namespace ShapesProcessor.Input
{
    public class ShapesReader
    {
        public IEnumerable<Shape> Read(string filePath, bool fileHasHeader)
        {
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
                        if (int.TryParse(parts[1], out int numSides) && int.TryParse(parts[2], out int sideLengthCm))
                        {
                            shapesFromFile.Add(new Shape(numSides, sideLengthCm));
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

            return shapesFromFile;
        }
    }
}
