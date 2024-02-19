using Project.Entities;
using Project.Repositories.Interfaces;
using Project.Services.Interfaces;

namespace Project.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<CategoryEntity?> GetAll()
        {
            return _repository.GetAll();
        }

        public CategoryEntity? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public CategoryEntity? GetByName(string Name)
        {
            return _repository.GetByName(Name);
        }

        public void Add(CategoryEntity category)
        {
            _repository.Add(category);
        }
        public bool Change(CategoryEntity category)
        {
            var local = _repository.GetById(category.Id);
            if (local is not null)
            {
                _repository.Change(category);
                return true;
            }
            return false;
        }

        public void DeleteById(int id)
        {
            var category = _repository.GetById(id);
            if (category is not null)
            {
                _repository.Delete(category);
            }
        }

    }
}
