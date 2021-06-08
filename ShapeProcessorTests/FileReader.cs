using ShapeProcessor.Domain;
using System;
using System.Collections.Generic;

namespace ShapeProcessor.Tests
{
    internal class FileReader
    {
        public FileReader()
        {
        }

        internal object Read()
        {
            return new List<Shape>
            {
                new Shape(4, 4)
            };
        }
    }
}