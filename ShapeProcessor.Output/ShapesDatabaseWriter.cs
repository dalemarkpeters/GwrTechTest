using Microsoft.Extensions.Configuration;
using ShapeProcessor.Domain;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShapeProcessor.Output
{
    public class ShapesDatabaseWriter : IShapesWriter
    {
        private readonly IConfiguration _configuration;

        public ShapesDatabaseWriter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void WriteShapes(ICollection<Shape> shapes)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            connection.Open();
            foreach (var shape in shapes)
            {
                using var cmd = new SqlCommand(
                    @"INSERT INTO dbo.Shapes(OriginalId, NumberOfSides, SideLengthInCentimetres, PerimeterCategoryId, CalculatedPerimeterInCentimetres) 
                    VALUES(@originalId, @numSides, @sideLengthInCentimetres, @perimeterCategoryId, @calculatedPerimeterInCentimetres)", connection);
                cmd.Parameters.Add("@numSides", SqlDbType.Int).Value = shape.NumberOfSides;
                cmd.Parameters.Add("@sideLengthInCentimetres", SqlDbType.Int).Value = shape.SideLengthInCentimetres;
                cmd.Parameters.Add("@perimeterCategoryId", SqlDbType.Int).Value = shape.PerimeterCategory;
                cmd.Parameters.Add("@originalId", SqlDbType.Int).Value = shape.OriginalId;
                cmd.Parameters.Add("@calculatedPerimeterInCentimetres", SqlDbType.Int).Value = shape.PerimeterInCentimetres;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
