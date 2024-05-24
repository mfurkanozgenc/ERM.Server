using AutoMapper;
using Server.Application.Features.Customers.CreateCustomer;
using Server.Application.Features.Customers.UpdateCustomer;
using Server.Application.Features.Depots.CreateDepot;
using Server.Application.Features.Depots.UpdateDepot;
using Server.Application.Features.Invoices.CreateInvoice;
using Server.Application.Features.Invoices.UpdateInvoice;
using Server.Application.Features.Orders.CreateOrder;
using Server.Application.Features.Orders.UpdateOrder;
using Server.Application.Features.Products.CreateProduct;
using Server.Application.Features.Products.UpdateProduct;
using Server.Application.Features.RecipeDetails.CreateRecipeDetails;
using Server.Application.Features.RecipeDetails.UpdateRecipeDetail;
using Server.Domain.Dtos;
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

            CreateMap<CreateRecipeDetailsCommand, RecipeDetail>();
            CreateMap<UpdateRecipeDetailCommand, RecipeDetail>();

            CreateMap<CreateOrderCommand, Order>()
                  .ForMember(member => member.OrderDetails,
                  options =>
                  options.MapFrom(p => p.OrderDetails.Select(s => new OrderDetail
                  {
                      Price = s.Price,
                      Quantity = s.Quantity,
                      ProductId = s.ProductId
                  }).ToList()));

            CreateMap<UpdateOrderCommand, Order>()
                .ForMember(member =>
                member.OrderDetails,
                options =>
                options.Ignore());

            CreateMap<CreateInvoiceCommand, Invoice>()
             .ForMember(member => member.Type, options =>
             options.MapFrom(p => InvoiceTypeEnum.FromValue(p.TypeValue)))
            .ForMember(member => member.InvoiceDetails,
            options =>
            options.MapFrom(p => p.InvoiceDetails.Select(s => new InvoiceDetail
            {
                Price = s.Price,
                Quantity = s.Quantity,
                ProductId = s.ProductId,
                DepotId = s.DepotId
            }).ToList()));

            CreateMap<UpdateInvoiceCommand, Invoice>()
            .ForMember(member =>
            member.InvoiceDetails,
            options =>
            options.Ignore());
        }
    }
}

