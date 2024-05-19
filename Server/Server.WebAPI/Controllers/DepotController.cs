using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Customers.GetAllCustomer;
using Server.Application.Features.Depots.CreateDepot;
using Server.Application.Features.Depots.DeleteDepotById;
using Server.Application.Features.Depots.GetAllDepot;
using Server.Application.Features.Depots.UpdateDepot;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class DepotController : ApiController
    {
        public DepotController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllDepotQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepotCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDepotCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteDepotByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
