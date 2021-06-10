using Microsoft.Extensions.Configuration;
using ShapesProcessor.Input;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShapeProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration Configuration = GetConfiguration();
            string filePath;

            bool headerIsIncluded;
            if (args.Length == 0)
            {
                Console.WriteLine("Welcome to the Shape Processor command line interface!");
                Console.WriteLine("Please enter the name of the CSV file you wish to be processed:");
                filePath = Console.ReadLine();

                Console.WriteLine("Does the CSV file have a header? (Y/N)");
                var headerIncludedString = Console.ReadLine();
                headerIsIncluded = IsHealderIncluded(headerIncludedString);
            }
            else
            {
                filePath = args[0];
                headerIsIncluded = IsHealderIncluded(args[1]);
            }

            var shapesReader = new ShapesReader();
            var shapes = shapesReader.Read(filePath, headerIsIncluded);

            using var connection = new SqlConnection(Configuration.GetConnectionString("Default"));
            connection.Open();
            foreach (var shape in shapes)
            {
                using var cmd = new SqlCommand("INSERT INTO dbo.Shapes(Id, NumberOfSides, SideLengthInCentimetres, PerimeterCategoryId) VALUES(@id, @numSides, @sideLengthInCentimetres, @perimeterCategoryId)", connection);
                cmd.Parameters.Add("@numSides", SqlDbType.Int).Value = shape.NumberOfSides;
                cmd.Parameters.Add("@sideLengthInCentimetres", SqlDbType.Int).Value = shape.SideLengthInCentimetres;
                cmd.Parameters.Add("@perimeterCategoryId", SqlDbType.Int).Value = shape.PerimeterCategory;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = shape.Id;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        private static bool IsHealderIncluded(string headerIncludedString)
        {
            if (headerIncludedString.ToLowerInvariant() == "y".ToLowerInvariant())
            {
                return true;
            }

            return false;
        }
    }
}
