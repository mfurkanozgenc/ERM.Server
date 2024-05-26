using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Users.GetAllUser
{
    public  sealed class GetAllUserQuery : IRequest<Result<List<GetAllUserQueryResponse>>>
    {
        public UserManager<AppUser>? userManager;
    } 
}
