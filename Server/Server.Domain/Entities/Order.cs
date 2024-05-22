using Server.Domain.Abstractions;
using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public sealed class Order : Entity
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int OrderNumberYear { get; set; }
        public int OrderNumber { get; set; }
        public string Number => SetNumber();
        public DateOnly Date { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;
        public List<OrderDetail>? OrderDetails { get; set; }


        public string SetNumber()
        {
            string prefix = "TS";

            string initialString = prefix + OrderNumberYear.ToString() + OrderNumber.ToString();

            int targetLength = 16;
            int missingLenth = targetLength - initialString.Length;
            string finalString = prefix + OrderNumberYear.ToString() + new string('0', missingLenth) + OrderNumber.ToString();

            return finalString;
        }
    }
}
