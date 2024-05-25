using AutoMapper;
using GenericRepository;
using MediatR;
using Server.Domain.Entities;
using Server.Domain.Enums;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Invoices.CreateInvoice
{
    public sealed class CreateInvoiceCommandHandler(
        IInvoiceRepository invoiceRepository,
        IStockMovementRepository stockMovementRepository,
        IUnitOfWork unitOfWork,
        IOrderRepository orderRepository,
        IMapper mapper) : IRequestHandler<CreateInvoiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {

            Invoice invoice = mapper.Map<Invoice>(request);

            if (invoice.InvoiceDetails is not null)
            {
                List<StockMovement> stockMovements = new();
                foreach (var detail in invoice.InvoiceDetails)
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
                    stockMovements.Add(movement);
                }

                await stockMovementRepository.AddRangeAsync(stockMovements);
            }
            await invoiceRepository.AddAsync(invoice, cancellationToken);

            if(request.OrderId is not null)
            {
                Order? order = await orderRepository.GetByExpressionWithTrackingAsync(o => o.Id == request.OrderId);

                if(order is not null)
                {
                    order.Status = OrderStatusEnum.Completed;
                }
            }
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Fatura Oluşturma Başarılı";
        }
    }
}
