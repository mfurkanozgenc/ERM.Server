using AutoMapper;
using GenericRepository;
using MediatR;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Server.Application.Features.Depots.CreateDepot
{
    internal sealed class CreateDepotCommandHandler(
        IDepotRepository depotRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateDepotCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateDepotCommand request, CancellationToken cancellationToken)
        {
            bool isNameExsist = await depotRepository.AnyAsync(d => d.Name == request.Name);

            if(isNameExsist)
            {
                return Result<string>.Failure("Aynı Depo İsmi Daha Önce Kayıt Edilmiştir");
            }

            var depot = mapper.Map<Depot>(request);

            await depotRepository.AddAsync(depot);
            await unitOfWork.SaveChangesAsync();

            return "Depo Kaydı Başarıyla Tamamlandı";
        }
    }
}
