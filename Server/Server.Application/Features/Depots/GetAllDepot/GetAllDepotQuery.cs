using MediatR;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Server.Application.Features.Depots.GetAllDepot
{
    public sealed class GetAllDepotQuery() : IRequest<Result<List<Depot>>>
    {

    }
}
