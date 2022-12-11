using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Interfaces;
using ProductsApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProductsApi.Services
{
    public class CarService : ICar
    {
        readonly SqlConnection _Conexion;
        readonly string _ambient;

        public CarService(IConfiguration configuration)
        {
            string ambient = configuration.GetValue<string>("Ambient");

            if (ambient.Equals("prd"))
                _Conexion = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:Lap"));
            else
                _Conexion = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:PC"));

            _ambient = ambient;

        }
        public async Task<IActionResult> PostCar(CarRequest car)
        {
            int row;
            try
            {
                _Conexion.Open();
                SqlCommand cmd = _Conexion.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_CAR";

                cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(car.Name) ? string.Empty : car.Name);
                cmd.Parameters.AddWithValue("@IdModel", car.IdModel);
                cmd.Parameters.AddWithValue("@Year", string.IsNullOrEmpty(car.Year) ? string.Empty : car.Year);
                cmd.Parameters.AddWithValue("@Engine", string.IsNullOrEmpty(car.Engine) ? string.Empty : car.Engine);
                cmd.Parameters.AddWithValue("@IdUser", car.IdUser) ;
                
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
