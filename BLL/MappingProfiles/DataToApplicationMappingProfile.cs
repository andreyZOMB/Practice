using AutoMapper;
using DAL.DBObjects;
using BLL.Entities;

namespace BLL.MappingProfiles
{
    public class DataToApplicationMappingProfile : Profile
    {
        public DataToApplicationMappingProfile()
        {
            CreateMap<ProductDB, ProductEntity>().ReverseMap();

            CreateMap<CategoryDB, CategoryEntity>().ReverseMap();
        }
    }
}
