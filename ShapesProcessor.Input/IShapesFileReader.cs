using ShapeProcessor.Domain;
using System.Collections.Generic;

namespace ShapesProcessor.Input
{
    public interface IShapesFileReader
    {
        ICollection<Shape> ReadShapes(string filePath, bool fileHasHeader);
    }
}