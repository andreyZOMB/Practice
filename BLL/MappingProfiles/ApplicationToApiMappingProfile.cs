using AutoMapper;
using BLL.DTObjects.Product;
using BLL.DTObjects.Category;
using BLL.Entities;

namespace BLL.MappingProfiles
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
