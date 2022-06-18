using System;
using System.Collections.Generic;
using System.Text;

namespace AppMercadoLibre.Models
{
    public class ProductModel
    {
        //Propiedades
        public int ID { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string PictureImgBase64 { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
