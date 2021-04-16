using AutoMapper;
using Domain.Models;

namespace ApplicationCore.Resources
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductResource>();
            CreateMap<AddInvoiceProductResource, InvoiceProduct>();
            //CreateMap<AddInvoiceResource, Invoice>()
            //    .ForMember(i => i.CreatedStaff.StaffMemberId, opt => opt.MapFrom(ir => ir.CreatedStaffId))
            //    .ForMember(i => i.CreatedDate, opt => opt.MapFrom(ir => ir.CreatedDate))
            //    .ForMember(i => i.CounterAgent.CounterAgentId, opt => opt.MapFrom(ir => ir.AgentId))
            //    .ForMember(i => i.TotalCost, opt => opt.MapFrom(ir => ir.TotalCost))
            //    .ForMember(i => i.Warehouse.WarehouseId, opt => opt.MapFrom(ir => ir.WarehouseId));

            CreateMap<Manufacturer, ManufacturerResource>().ReverseMap();
            CreateMap<MeasurementUnit, MeasurementUnitResource>().ReverseMap();
            CreateMap<Warehouse,WarehouseResource>().ReverseMap();
            CreateMap<CounterAgent, CounterAgentResource>().ReverseMap();
            CreateMap<StaffMember, StaffMemberResource>().ReverseMap();
            CreateMap<InvoiceProduct, GetInvoiceProductResource>().ReverseMap();
            CreateMap<Invoice, GetInvoiceResource>();
            CreateMap<Product, AddProductResource>()
                        .ForMember(p => p.ManufacturerId, opt => opt.MapFrom(pr => pr.Manufacturer.ManufacturerId))
                        .ForMember(p => p.MeasurementUnitId, opt => opt.MapFrom(pr => pr.MeasurementUnit.MeasurementUnitId))
                        .ForMember(p => p.QuantityAtWarehouse, opt => opt.MapFrom(pr => pr.QuantityAtWarehouse))
                        .ReverseMap();


        }
    }
}
