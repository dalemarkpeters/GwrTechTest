using ShapeProcessor.Domain;
using System.Collections.Generic;

namespace ShapeProcessor.Output
{
    public interface IShapesWriter
    {
        void WriteShapes(ICollection<Shape> shapes);
    }
}