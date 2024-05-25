using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Enums;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Invoices.UpdateInvoice
{
    public sealed class UpdateInvoiceCommandHandler(
        IInvoiceRepository invoiceRepository,
        IStockMovementRepository stockMovementRepository,
        IInvoiceDetailRepository invoiceDetailRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateInvoiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await invoiceRepository
                     .WhereWithTracking(p => p.Id == request.Id)
                     .Include(p => p.InvoiceDetails)
                     .FirstOrDefaultAsync(cancellationToken);

            if (invoice is null)
            {
                return Result<string>.Failure("Fatura Bulunamadı");
            }

            List<StockMovement> stocks = await stockMovementRepository.Where(p => p.InvoiceId == invoice.Id).ToListAsync(cancellationToken);

            stockMovementRepository.DeleteRange(stocks);

            invoiceDetailRepository.DeleteRange(invoice.InvoiceDetails);

            invoice.InvoiceDetails = request.InvoiceDetails.Select(s => new InvoiceDetail
            {
                DepotId = s.DepotId,
                InvoiceId = invoice.Id,
                ProductId = s.ProductId,
                Price = s.Price,
                Quantity = s.Quantity
            }).ToList();

            await invoiceDetailRepository.AddRangeAsync(invoice.InvoiceDetails,cancellationToken);

            mapper.Map(request, invoice);

            if (request.InvoiceDetails is not null)
            {
                List<StockMovement> newkMovements = new();
                foreach (var detail in request.InvoiceDetails)
                {
                    StockMovement movement = new()
                    {
                        InvoiceId = invoice.Id,
                        NumberOfEntries = request.TypeValue == 1 ? detail.Quantity : 0,
                        NumberOfOutputs = request.TypeValue == 2 ? detail.Quantity : 0,
                        DepotId = detail.DepotId,
                        Price = detail.Price,
                        ProductId = detail.ProductId
                    };
                    newkMovements.Add(movement);
                }

                await stockMovementRepository.AddRangeAsync(newkMovements);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Fatura Güncelleme Başarılı";
        }
    }
}
