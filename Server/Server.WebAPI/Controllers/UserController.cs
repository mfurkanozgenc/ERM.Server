using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Reports.GetAllReport;
using Server.Application.Features.Users.CreateUser;
using Server.Application.Features.Users.GetAllUser;
using Server.Application.Features.Users.UpdateUser;
using Server.Domain.Entities;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class UserController : ApiController
    {

        public UserController(IMediator mediator, UserManager<AppUser> userManager) : base(mediator,userManager)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            request.userManager = this._userManager;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.userManager = this._userManager;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            request.userManager = this._userManager;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            request.userManager = this._userManager;
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
