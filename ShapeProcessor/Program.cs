using ShapesProcessor.Input;
using System;
using System.IO;
using System.Linq;

namespace ShapeProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var headerIsIncluded = false;
            string filePath;
            if (args.Length == 0)
            {
                Console.WriteLine("Welcome to the Shape Processor command line interface!");
                Console.WriteLine("Please enter the name of the CSV file you wish to be processed:");
                filePath = Console.ReadLine();

                Console.WriteLine("Does the CSV file have a header? (Y/N)");
                var headerIncludedString = Console.ReadLine();
                if (headerIncludedString.ToLowerInvariant() == "y".ToLowerInvariant())
                {
                    headerIsIncluded = true;
                }
            }
            else
            {
                filePath = args[0];
                headerIsIncluded = true;
            }

            var shapesReader = new ShapesReader();
            var shapes = shapesReader.Read(filePath, headerIsIncluded);
        }
    }
}
