using Server.Domain.Dtos;

namespace Server.Application.Features.Orders.RequirementsPlanningByOrderId
{
    public sealed record RequirementsPlanningByOrderIdCommandResponse(
        DateOnly Date,
        string Title,
        List<ProductDto> Products);
}
