using Microsoft.EntityFrameworkCore;

namespace Project.DBObjects
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
