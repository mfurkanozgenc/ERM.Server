using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Products.CreateProduct;
using Server.Application.Features.Products.DeleteProductById;
using Server.Application.Features.Products.GetAllProduct;
using Server.Application.Features.Products.UpdateProduct;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class ProductController : ApiController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
