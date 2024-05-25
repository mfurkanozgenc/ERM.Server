using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Productions.CreateProduction;
using Server.Application.Features.Productions.DeleteProductionById;
using Server.Application.Features.Productions.GetAllProduction;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class ProductionController : ApiController
    {
        public ProductionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllProductionQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductionCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteProductionByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
