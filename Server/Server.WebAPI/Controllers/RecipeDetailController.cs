using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.RecipeDetails.CreateRecipeDetails;
using Server.Application.Features.RecipeDetails.DeleteRecipeDetailById;
using Server.Application.Features.RecipeDetails.UpdateRecipeDetail;
using Server.Application.Features.Recipes.GetByIdRecipteWithDetails;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class RecipeDetailController : ApiController
    {
        public RecipeDetailController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteRecipeDetailByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> GetRecipeByIdWithDetails(GetRecipeByIdWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
