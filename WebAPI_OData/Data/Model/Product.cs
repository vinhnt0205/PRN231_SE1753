namespace WebAPI_OData.Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public decimal Cost { get; set; }
        public string ImageName { get; set; }
        public string ProductType { get; set; }
    }
}
