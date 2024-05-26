using Server.Domain.Enums;

namespace Server.Application.Features.Users.GetAllUser
{
    public sealed class GetAllUserQueryResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public UserRoleTypeEnum UserRole { get; set; } = UserRoleTypeEnum.Employee;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
    }
}
