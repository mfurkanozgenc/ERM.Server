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
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
