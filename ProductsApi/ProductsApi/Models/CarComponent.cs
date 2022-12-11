namespace ProductsApi.Models
{
    public class CarComponent
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Store { get; set; }
        public double Price { get; set; }
        public double Manpower { get; set; }
        public string Img { get; set; }
        public List<Category> categories { get; set; } = new List<Category>();
    }
}
