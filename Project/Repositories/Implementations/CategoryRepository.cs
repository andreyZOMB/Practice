using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DBObjects;
using Project.Entities;
using Project.Repositories.Interfaces;

namespace Project.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CategoryEntity?> GetAll()
        {
            var rez = _dbContext.Categories.AsNoTracking();
            return _mapper.Map<IEnumerable<CategoryEntity?>>(rez);
        }


        public CategoryEntity? GetByName(string name)
        {
            var rez = _dbContext.Categories.AsNoTracking().SingleOrDefault(category => category.Name == name);
            return _mapper.Map<CategoryEntity?>(rez);
        }

        public CategoryEntity? GetById(int id)
        {
            var rez = _dbContext.Categories.AsNoTracking().SingleOrDefault(category => category.Id == id);
            return _mapper.Map<CategoryEntity?>(rez);
        }

        public void Add(CategoryEntity input)
        {
            var local = _mapper.Map<Category>(input);
            _dbContext.Categories.Add(local);
            _dbContext.SaveChanges();
        }

        public void Change(CategoryEntity input)
        {
            var local = _mapper.Map<Category>(input);
            _dbContext.Categories.Update(local);
            _dbContext.SaveChanges();
        }

        public void Delete(CategoryEntity input)
        {
            var local = _mapper.Map<Category>(input);
            _dbContext.Categories.Remove(local);
            _dbContext.SaveChanges();
        }
    }
}
