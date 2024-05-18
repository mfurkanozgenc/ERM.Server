using Server.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public sealed class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string TaxDepartment { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
