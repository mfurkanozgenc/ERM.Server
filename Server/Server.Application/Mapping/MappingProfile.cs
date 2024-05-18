using AutoMapper;
using Server.Application.Features.Customers.CreateCustomer;
using Server.Domain.Entities;

namespace Server.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
        }
    }
}
