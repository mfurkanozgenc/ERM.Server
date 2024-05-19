using AutoMapper;
using GenericRepository;
using MediatR;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Depots.UpdateDepot
{
    internal sealed class UpdateDepotCommandHandler(
        IDepotRepository depotRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateDepotCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateDepotCommand request, CancellationToken cancellationToken)
        {
            var depot = await depotRepository.GetByExpressionWithTrackingAsync(c => c.Id == request.Id, cancellationToken);

            if (depot is null)
            {
                return Result<string>.Failure("Depo Bulunamadı");
            }

            if(depot.Name != request.Name)
            {
                var isNameExsist = await depotRepository.AnyAsync(d => d.Name == request.Name);

                if(isNameExsist)
                {
                    return Result<string>.Failure("Aynı Depo İsmi Daha Önce Kayıt Edilmiştir");
                }
            }
            mapper.Map(request, depot);
            await unitOfWork.SaveChangesAsync();

            return "Depo Güncelleme Başarıyla Tamamlandı";
        }
    }
}
