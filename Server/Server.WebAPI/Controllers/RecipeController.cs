using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Recipes.CreateRecipe;
using Server.Application.Features.Recipes.DeleteRecipeById;
using Server.Application.Features.Recipes.GetAllRecipe;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class RecipeController : ApiController
    {
        public RecipeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllRecipeQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
