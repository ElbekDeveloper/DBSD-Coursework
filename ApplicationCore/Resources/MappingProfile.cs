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
            CreateMap<Product, AddProductResource>()
                        .ForMember(p => p.ManufacturerId, opt => opt.MapFrom(pr => pr.Manufacturer.ManufacturerId))
                        .ForMember(p => p.ManufacturerId, opt => opt.MapFrom(pr => pr.MeasurementUnit.MeasurementUnitId))
                        .ForMember(p => p.QuantityAtWarehouse, opt => opt.MapFrom(pr => pr.QuantityAtWarehouse))
                        .ReverseMap();


        }
    }
}
