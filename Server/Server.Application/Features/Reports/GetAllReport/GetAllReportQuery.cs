using MediatR;
using TS.Result;

namespace Server.Application.Features.Reports.GetAllReport
{
    public sealed record GetAllReportQuery() : IRequest<Result<GetAllReportQueryHandlerResponse>>;
}
