﻿using Server.Domain.Abstractions;
using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public sealed class Invoice : Entity
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public InvoiceTypeEnum Type { get; set; } = InvoiceTypeEnum.Purchase;
        public List<InvoiceDetail>? InvoiceDetails { get; set; }
    }
}
