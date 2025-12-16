
namespace RealEstateApi.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PropertyType { get; set; }
        public string Location { get; set; }
        public string OwnershipType { get; set; }
        public string Details { get; set; }
        public string Images { get; set; }
        public string UserName { get; set; }
        public string AdminName { get; set; }
    }
}
