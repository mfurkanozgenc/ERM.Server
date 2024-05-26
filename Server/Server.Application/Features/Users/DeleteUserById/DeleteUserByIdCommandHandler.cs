using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Users.UpdateUser
{
    internal sealed class DeleteUserByIdCommandHandler() : IRequestHandler<DeleteUserByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            UserManager<AppUser>? manager = request.userManager;
            if (manager is not null)
            {
                AppUser? user = await manager.Users.FirstOrDefaultAsync(p => p.Id == request.Id);
                if (user is null)
                {
                    return Result<string>.Failure("Kullanıcı Bulunamadı");
                }

                if(manager.Users.Count() == 1)
                {
                    return Result<string>.Failure("Kullanıcı Silinemedi . En Az 1 Adet Kullanıcı Bulunmalıdır.");
                }
                await manager.DeleteAsync(user);
                return "Kullanıcı Silindi";
            }
            return Result<string>.Failure("Hata ! İşlem Yapılamadı");
        }
    }
}
