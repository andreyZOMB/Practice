namespace Project.DTObjects.Product
{
    public class DefaultProductOutput
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int Count { get; set; }
        public required int Price { get; set; }
        public required int CategoryId { get; set; }
    }
}
