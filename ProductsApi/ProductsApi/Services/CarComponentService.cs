using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Interfaces;
using ProductsApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProductsApi.Services
{
    public class CarComponentService : ICarComponent
    {
        readonly SqlConnection _Conexion;
        readonly string _ambient;

        public CarComponentService(IConfiguration configuration)
        {
            string ambient = configuration.GetValue<string>("Ambient");

            if (ambient.Equals("prd"))
                _Conexion = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:Lap"));
            else
                _Conexion = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:PC"));

            _ambient = ambient;

        }
        public async Task<IActionResult> PostCarComponent(CarComponentRequest carcomponent)
        {
            int row;
            try
            {
                _Conexion.Open();
                SqlCommand cmd = _Conexion.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_CARCOMPONENT";

                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(carcomponent.Description) ? string.Empty : carcomponent.Description);
                cmd.Parameters.AddWithValue("@Stroe", string.IsNullOrEmpty(carcomponent.Store) ? string.Empty : carcomponent.Store);
                cmd.Parameters.AddWithValue("@Price", carcomponent.Price);
                cmd.Parameters.AddWithValue("@Manpower", carcomponent.Manpower);
                cmd.Parameters.AddWithValue("@Img", string.IsNullOrEmpty(carcomponent.Img) ? string.Empty : carcomponent.Img);
                cmd.Parameters.AddWithValue("@IdCategory", carcomponent.IdCategory);
                cmd.Parameters.AddWithValue("@IdCar", carcomponent.IdCar);
                
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
