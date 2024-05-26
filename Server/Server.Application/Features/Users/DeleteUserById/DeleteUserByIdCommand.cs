using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Users.UpdateUser
{
    public sealed class DeleteUserByIdCommand : IRequest<Result<string>>
    {
        public UserManager<AppUser>? userManager;
        public Guid Id { get; set; }
    }
}
