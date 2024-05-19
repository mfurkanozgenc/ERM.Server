namespace Server.Domain.Dtos
{
    public sealed record RecipeDetailDTO(
        Guid ProductId,
        decimal Quantity);
}
