using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Domain.Entities;
using Server.Domain.Enums;
using TS.Result;

namespace Server.Application.Features.Users.CreateUser
{
    internal sealed class CreateUserCommandHandler() : IRequestHandler<CreateUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserManager<AppUser>? manager = request.userManager;
            if (manager is not null)
            {
                bool existsControl = !manager.Users.Any(u => u.UserName == request.UserName);
                if (existsControl)
                {
                    AppUser user = new()
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        UserName = request.UserName,
                        Email = request.Email,
                        EmailConfirmed = true,
                        UserRole = request.UserRole
                    };

                    if(request.RoleValueNumber == 1) { user.UserRole = UserRoleTypeEnum.Admin; }
                    if(request.RoleValueNumber == 2) { user.UserRole = UserRoleTypeEnum.Employee; }

                    user.LockoutEnabled = false;
                    await request.userManager!.CreateAsync(user, request.Password);

                    return "Kullanıcı Eklendi";
                }
                return Result<string>.Failure("Aynı Kullanıcı Adına Sahip Başka Bir Kullanıcı Bulunmakta");
            }
            return Result<string>.Failure("Hata ! İşlem Yapılamadı");
        }
    }
}
