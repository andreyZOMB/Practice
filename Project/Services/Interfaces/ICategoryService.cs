using Project.Entities;

namespace Project.Services.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryEntity?> GetAll();
        public CategoryEntity? GetById(int id);
        public CategoryEntity? GetByName(string Name);
        public void Add(CategoryEntity category);
        public bool Change(CategoryEntity category);
        public void DeleteById(int id);
    }
}
