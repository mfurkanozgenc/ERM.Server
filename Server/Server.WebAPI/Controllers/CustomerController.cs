using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Customers.CreateCustomer;
using Server.Application.Features.Customers.DeleteCustomerById;
using Server.Application.Features.Customers.GetAllCustomer;
using Server.Application.Features.Customers.UpdateCustomer;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class CustomerController : ApiController
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCustomerQuery request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode,response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
