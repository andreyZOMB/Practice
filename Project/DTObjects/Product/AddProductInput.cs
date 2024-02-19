namespace Project.DTObjects.Product
{
    public class AddProductInput
    {
        public required string Name { get; set; }
        public required int Count { get; set; }
        public required int Price { get; set; }
        public required int CategoryId { get; set; }
    }
}
