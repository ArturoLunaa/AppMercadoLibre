using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProducts.Models
{
    public class ProductModel
    {
        // Variables
        string ConnectionString = "";

        //Propiedades
        public int ID { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string PictureImgBase64 { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        //Métodos
        public ApiResponse GetAll()
        {
            List<ProductModel> list = new List<ProductModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    //aqui no se que va
                    string tsql = "SELECT * FROM Product " +
                                  "INNER JOIN Position On Product.IDActualPosition = Position.IDPosition";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ProductModel
                                {
                                    ID = (int)reader["IDProduct"],
                                    Category = reader["Category"].ToString(),
                                    Model = reader["Model"].ToString(),
                                    Price = (float)reader["Price"],
                                    PictureImgBase64 = reader["Model"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Longitude = (double)reader["Model"],
                                    Latitude = (double)reader["Model"],
                                });
                            }
                        }
                    }
                }
                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "Los productos fueron obtenidos correctamente",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = $"Se generó un error al obtener los productos: {ex.Message}",
                    Result = null
                };
            }
        }

    }
}
