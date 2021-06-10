using Microsoft.Extensions.Configuration;
using ShapeProcessor.Output;
using ShapesProcessor.Input;
using System;

namespace ShapeProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath;
            bool headerIsIncluded;

            if (args.Length == 0)
            {
                Console.WriteLine("Welcome to the Shape Processor command line interface!");
                Console.WriteLine("Please enter the name of the CSV file you wish to be processed:");
                filePath = Console.ReadLine();

                Console.WriteLine("Does the CSV file have a header? (Y/N)");
                var headerIncludedString = Console.ReadLine();
                headerIsIncluded = IsHeaderIncluded(headerIncludedString);
            }
            else
            {
                filePath = args[0];
                headerIsIncluded = IsHeaderIncluded(args[1]);
            }

            var shapesReader = new ShapesFileReader();
            var shapes = shapesReader.ReadShapes(filePath, headerIsIncluded);

            var shapesWriter = new ShapesDatabaseWriter(GetConfiguration());
            shapesWriter.WriteShapes(shapes);
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        private static bool IsHeaderIncluded(string headerIncludedString)
        {
            if (headerIncludedString.ToLowerInvariant() == "y".ToLowerInvariant())
            {
                return true;
            }

            return false;
        }
    }
}
