using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShapeProcessor.Output;
using ShapesProcessor.Input;
using ShapesProcessor.Logging;
using System;
using System.IO;

namespace ShapeProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = BuildConfig();
            var serviceProvider = BuildServiceProvider(config);

            string filePath;
            bool headerIsIncluded;

            Console.WriteLine("Welcome to the Shape Processor command line interface.");

            if (args.Length == 0)
            {
                Console.WriteLine("Please enter the name of the CSV file you wish to be processed:");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[0];
                Console.WriteLine($"Attempting to use the file located at {filePath} as the input file");
            }

            Console.WriteLine("Does the CSV file have a header? (Y/N)");
            var headerIncludedString = Console.ReadLine();
            headerIsIncluded = IsHeaderIncluded(headerIncludedString);

            var shapesReader = serviceProvider.GetService<IShapesFileReader>();
            var shapes = shapesReader.ReadShapes(filePath, headerIsIncluded);

            var shapesWriter = serviceProvider.GetService<IShapesWriter>();
            shapesWriter.WriteShapes(shapes);
        }

        private static ServiceProvider BuildServiceProvider(IConfiguration config)
        {
            return new ServiceCollection()
                .AddSingleton<IShapesWriter, ShapesDatabaseWriter>()
                .AddSingleton<IShapesFileReader, ShapesFileReader>()
                .AddSingleton(config)
                .AddSingleton<ILogger, Logger>()
                .BuildServiceProvider();
        }

        private static IConfiguration BuildConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
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
