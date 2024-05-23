namespace Server.Domain.Dtos
{
    public sealed record ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
    }
}
