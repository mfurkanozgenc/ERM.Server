using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Enums;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Reports.GetAllReport
{
    internal sealed class GetAllReportQueryHandler(
        IProductRepository productRepository,
        ICustomerRepository customerRepository,
        IDepotRepository depotRepository,
        IInvoiceRepository invoiceRepository,
        IOrderRepository orderRepository) : IRequestHandler<GetAllReportQuery, Result<GetAllReportQueryHandlerResponse>>
    {
        public async Task<Result<GetAllReportQueryHandlerResponse>> Handle(GetAllReportQuery request, CancellationToken cancellationToken)
        {
            GetAllReportQueryHandlerResponse response = new()
            {
                ProductCount = await productRepository.GetAll().CountAsync(),
                DepotCount = await depotRepository.GetAll().CountAsync(),
                CustomerCount = await customerRepository.GetAll().CountAsync(),
                PurchaseInvoicesCount = await invoiceRepository.Where(p => p.Type == InvoiceTypeEnum.Purchase).CountAsync(),
                SaleInvoicesCount = await invoiceRepository.Where(p => p.Type == InvoiceTypeEnum.Sales).CountAsync(),
                OrderCount = await orderRepository.GetAll().CountAsync(),
            };

            return response;
        }
    }
}
