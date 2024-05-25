using Server.Domain.Abstractions;
using System;

namespace Server.Domain.Entities
{
    public sealed class Production : Entity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid DepotId { get; set; }
        public Depot? Depot { get; set; }
        public string ProductionNumber { get; set; } = string.Empty;

        public Production()
        {
            ProductionNumber = CreateProductionNumber();
        }

        public string CreateProductionNumber()
        {
            Random random = new Random();
            const int length = 14;
            char[] productionNumber = new char[length];

            for (int i = 0; i < length; i++)
            {
                productionNumber[i] = (char)('0' + random.Next(10));
            }
            return new string(productionNumber);
        }
    }
}
