using FluentValidation;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Features.Depots.CreateDepot
{
    public sealed class CreateDepotCommandValidator : AbstractValidator<Depot>
    {
        public CreateDepotCommandValidator()
        {
            RuleFor(d => d.Name).MinimumLength(3).NotEmpty().NotNull();
        }
    }
}
