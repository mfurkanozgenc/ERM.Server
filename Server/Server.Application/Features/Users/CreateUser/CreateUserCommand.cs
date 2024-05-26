using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Enums;
using TS.Result;

namespace Server.Application.Features.Users.CreateUser
{
    public sealed class CreateUserCommand : IRequest<Result<string>>
    {
        public UserManager<AppUser>? userManager;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleValueNumber { get; set; }
        public UserRoleTypeEnum UserRole { get; set; } = UserRoleTypeEnum.Employee;
    }
}
