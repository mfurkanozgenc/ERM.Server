using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Invoices.DeleteInvoiceById
{
    public sealed class DeleteInvoiceByIdCommandHandler(
        IInvoiceRepository invoiceRepository,
        IStockMovementRepository stockMovementRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteInvoiceByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteInvoiceByIdCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await invoiceRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id);

            if(invoice is null)
            {
                return Result<string>.Failure("Fatura Bulunamadı");
            }

            List<StockMovement> stocks = await stockMovementRepository.Where(p => p.InvoiceId == invoice.Id).ToListAsync(cancellationToken);

            stockMovementRepository.DeleteRange(stocks);

            invoiceRepository.Delete(invoice);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Fatura Silme Başarılı";
        }
    }
}
