using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Interfaces;
using ProductsApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProductsApi.Services
{
    public class CategotyService : ICategory
    {
        readonly SqlConnection _Conexion;
        readonly string _ambient;

        public CategotyService(IConfiguration configuration)
        {
            string ambient = configuration.GetValue<string>("Ambient");

            if (ambient.Equals("prd"))
                _Conexion = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:Lap"));
            else
                _Conexion = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:PC"));

            _ambient = ambient;

        }
        public async Task<IActionResult> PostCategory(CategoryRequest category)
        {
            int row;
            try
            {
                _Conexion.Open();
                SqlCommand cmd = _Conexion.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_CATEGORY";

                cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(category.Name) ? string.Empty : category.Name);
                
                row = await cmd.ExecuteNonQueryAsync();
                if (row != 0)
                    return new OkObjectResult("Registro insertado correctamente.");
                else
                    return new BadRequestObjectResult("No se pudo insertar el registro.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Error - {ex}");
            }
            finally
            {
                _Conexion.Close();
            }
        }
    }
}
