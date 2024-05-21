using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Orders.CreateOrder;
using Server.Application.Features.Orders.DeleteOrder;
using Server.Application.Features.Orders.GetAllOrderQuery;
using Server.Application.Features.Orders.UpdateOrder;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class COrderrController : ApiController
    {
        public COrderrController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllOrderQuery request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode,response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
