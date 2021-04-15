using AutoMapper;
using Domain.Models;

namespace ApplicationCore.Resources
{
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, GetProductResource>();

        CreateMap<Manufacturer, ManufacturerResource>().ReverseMap();
        CreateMap<MeasurementUnit, MeasurementUnitResource>().ReverseMap();
        CreateMap<Warehouse,WarehouseResource>().ReverseMap();
        CreateMap<CounterAgent, CounterAgentResource>().ReverseMap();
        CreateMap<StaffMember, StaffMemberResource>().ReverseMap();
        CreateMap<Product, AddProductResource>()
        .ForMember(p => p.ManufacturerId, opt => opt.MapFrom(pr => pr.Manufacturer.ManufacturerId))
        .ForMember(p => p.MeasurementUnitId, opt => opt.MapFrom(pr => pr.MeasurementUnit.MeasurementUnitId))
        .ForMember(p => p.QuantityAtWarehouse, opt => opt.MapFrom(pr => pr.QuantityAtWarehouse))
        .ReverseMap();


    }
}
}
