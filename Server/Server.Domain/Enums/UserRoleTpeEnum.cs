using Ardalis.SmartEnum;

namespace Server.Domain.Enums
{
    public sealed class UserRoleTypeEnum : SmartEnum<UserRoleTypeEnum>
    {
        public static readonly UserRoleTypeEnum Admin = new("Admin", 1);
        public static readonly UserRoleTypeEnum Employee = new("Çalışan", 2);
        public UserRoleTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
