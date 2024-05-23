using MediatR;
using TS.Result;

namespace Server.Application.Features.Orders.RequirementsPlanningByOrderId
{
    public sealed record RequirementsPlanningByOrderIdCommand(Guid OrderId) : IRequest<Result<RequirementsPlanningByOrderIdCommandResponse>>;
}
