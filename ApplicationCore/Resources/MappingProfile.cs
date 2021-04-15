using AutoMapper;
using Domain.Models;

namespace ApplicationCore.Resources
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductResource>()
                        .ForMember(gproduct => gproduct.MeasurementUnit, opt => opt.MapFrom(p => p.MeasurementUnit.Name));
            CreateMap<Manufacturer, ManufacturerResource>().ReverseMap();
            CreateMap<AddProductResource, Product>();
        }
    }
}
