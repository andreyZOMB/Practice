using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DBObjects
{
    [Index(nameof(Name), IsUnique = true)]
    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int Count { get; set; }
        public required int Price { get; set; }
        [ForeignKey("Category")]
        public required int CategoryId { get; set; }
    }
}
