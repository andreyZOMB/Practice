using AutoMapper;
using Project.DTObjects.Product;
using Project.DTObjects.Category;
using Project.Entities;

namespace Project.MappingProfiles
{
    public class ApplicationToApiMappingProfile : Profile
    {
        public ApplicationToApiMappingProfile()
        {
            CreateMap<AddProductInput, ProductEntity>();
            CreateMap<ChangeProductInput, ProductEntity>();
            CreateMap<ProductEntity, DefaultProductOutput>();

            CreateMap<AddCategoryInput, CategoryEntity>();
            CreateMap<ChangeCategoryInput, CategoryEntity>();
            CreateMap<CategoryEntity, DefaultCategoryOutput>();
        }

    }
}
