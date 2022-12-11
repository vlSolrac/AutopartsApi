namespace ProductsApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public int IdModel { get; set; }
        public int IdUser { get; set; }
    }
}
