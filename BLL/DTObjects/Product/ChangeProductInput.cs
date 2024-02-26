namespace BLL.DTObjects.Product
{
    public class ChangeProductInput
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int Count { get; set; }
        public required int Price { get; set; }
        public required int CategoryId { get; set; }
    }
}
