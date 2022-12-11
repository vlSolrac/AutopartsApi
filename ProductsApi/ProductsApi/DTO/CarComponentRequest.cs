namespace ProductsApi.DTO
{
    public class CarComponentRequest
    {
        public string Description { get; set; }
        public string Store { get; set; }
        public double Price { get; set; }
        public double Manpower { get; set; }
        public string Img { get; set; }
        public int IdCar { get; set; }
        public int IdCategory { get; set; }
    }
}
