using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Users.GetAllUser
{
    internal sealed class GetAllUserQueryHandler(
        IMapper mapper) : IRequestHandler<GetAllUserQuery, Result<List<GetAllUserQueryResponse>>>
    {
        public async Task<Result<List<GetAllUserQueryResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            List<AppUser> appUsers = await request!.userManager!.Users.ToListAsync();

            List<GetAllUserQueryResponse> response = mapper.Map<List<GetAllUserQueryResponse>>(appUsers);

            return response;
        }
    }
}
