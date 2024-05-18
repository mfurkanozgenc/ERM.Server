using Server.Application.Features.Auth.Login;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
