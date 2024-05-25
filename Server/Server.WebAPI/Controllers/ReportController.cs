using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Reports.GetAllReport;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class ReportController : ApiController
    {
        public ReportController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllReportQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
