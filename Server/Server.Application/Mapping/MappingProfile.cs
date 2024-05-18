using AutoMapper;
using Server.Application.Features.Customers.CreateCustomer;
using Server.Application.Features.Customers.UpdateCustomer;
using Server.Domain.Entities;

namespace Server.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
        }
    }
}
