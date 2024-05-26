using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Server.Application.Features.Users.UpdateUser
{
    public sealed class UpdateUserCommand : IRequest<Result<string>>
    {
        public UserManager<AppUser>? userManager;
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleValueNumber { get; set; }
    }
}
