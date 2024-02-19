using AutoMapper;
using Project.DBObjects;
using Project.Entities;

namespace Project.MappingProfiles
{
    public class DataToApplicationMappingProfile : Profile
    {
        public DataToApplicationMappingProfile()
        {
            CreateMap<Product, ProductEntity>().ReverseMap();

            CreateMap<Category, CategoryEntity>().ReverseMap();
        }
    }
}
