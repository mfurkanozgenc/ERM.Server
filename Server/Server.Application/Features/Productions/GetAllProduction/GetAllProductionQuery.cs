using MediatR;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Productions.GetAllProduction
{
    public sealed record GetAllProductionQuery() : IRequest<Result<List<Production>>>;
}
