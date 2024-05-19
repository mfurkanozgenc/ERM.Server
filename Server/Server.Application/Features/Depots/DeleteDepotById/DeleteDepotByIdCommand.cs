using MediatR;
using TS.Result;

namespace Server.Application.Features.Depots.DeleteDepotById
{
    public sealed record DeleteDepotByIdCommand(Guid Id) : IRequest<Result<string>>;
}
