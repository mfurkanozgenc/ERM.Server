using GenericRepository;
using MediatR;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Depots.DeleteDepotById
{
    internal sealed class DeleteDepotByIdHandler(
        IDepotRepository depotRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteDepotByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteDepotByIdCommand request, CancellationToken cancellationToken)
        {
            var depot = await depotRepository.GetByExpressionAsync(d => d.Id == request.Id,cancellationToken);

            if(depot is null)
            {
                return Result<string>.Failure("Depo Bulunamadı");
            }

            depotRepository.Delete(depot);
            await unitOfWork.SaveChangesAsync();

            return "Depo Silme İşlemi Başarılı";
        }
    }
}
