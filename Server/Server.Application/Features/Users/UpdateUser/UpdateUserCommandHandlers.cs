using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Enums;
using TS.Result;

namespace Server.Application.Features.Users.UpdateUser
{
    internal sealed class UpdateUserCommandHandlers() : IRequestHandler<UpdateUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            UserManager<AppUser>? manager = request.userManager;
            if (manager is not null)
            {
                AppUser? user = await manager.Users.FirstOrDefaultAsync(p => p.Id == request.Id);
                if (user is null)
                {
                    return Result<string>.Failure("Kullanıcı Bulunamadı");
                }
                if(user.UserName != request.UserName)
                {
                    var userNameControl = await manager.Users.AnyAsync(u => u.UserName == request.UserName);
                    if (userNameControl)
                    {
                        return Result<string>.Failure("Kullanıcı Adı Başka Hesapta Kullanılmaktadır");
                    }
                }

                if (user.Email != request.Email)
                {
                    var mailControl = await manager.Users.AnyAsync(u => u.Email == request.Email);
                    if (mailControl)
                    {
                        return Result<string>.Failure("Mail Başka Hesapta Kullanılmaktadır");
                    }
                }

                if (request.RoleValueNumber == 1) { user.UserRole = UserRoleTypeEnum.Admin; }
                if (request.RoleValueNumber == 2) { user.UserRole = UserRoleTypeEnum.Employee; }

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.UserName  = request.UserName;
                user.Email = request.Email;
                if(!string.IsNullOrEmpty(request.Password))
                {
                    user.PasswordHash = manager.PasswordHasher.HashPassword(user, request.Password);
                }
                await manager.UpdateAsync(user);
                return "Kullanıcı Güncellendi";
            }
            return Result<string>.Failure("Hata ! İşlem Yapılamadı");
        }
    }
}
