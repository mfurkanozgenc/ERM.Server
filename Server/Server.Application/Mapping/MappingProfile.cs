using AutoMapper;
using Server.Application.Features.Customers.CreateCustomer;
using Server.Application.Features.Customers.UpdateCustomer;
using Server.Application.Features.Depots.CreateDepot;
using Server.Application.Features.Depots.UpdateDepot;
using Server.Application.Features.Products.CreateProduct;
using Server.Application.Features.Products.UpdateProduct;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();

            CreateMap<CreateDepotCommand, Depot>();
            CreateMap<UpdateDepotCommand, Depot>();

            CreateMap<CreateProductCommand, Product>()
                .ForMember(member => member.Type,
                options =>
                options.MapFrom(p => ProductTypeEnum.FromValue(p.TypeValue)));

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(member => member.Type,
                 options =>
                options.MapFrom(p => ProductTypeEnum.FromValue(p.TypeValue)));
        }
    }
}

