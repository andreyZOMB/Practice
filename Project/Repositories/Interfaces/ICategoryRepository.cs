using Project.Entities;

namespace Project.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<CategoryEntity?> GetAll();
        public CategoryEntity? GetByName(string name);
        public CategoryEntity? GetById(int id);
        public void Add(CategoryEntity category);
        public void Change(CategoryEntity category);
        public void Delete(CategoryEntity category);
    }
}
