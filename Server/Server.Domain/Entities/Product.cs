using Server.Domain.Abstractions;
using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; set; } = string.Empty;
        public ProductTypeEnum Type { get; set; } = ProductTypeEnum.Product;
    }
}
