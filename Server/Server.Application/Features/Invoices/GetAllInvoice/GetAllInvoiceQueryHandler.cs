using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Enums;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Invoices.GetAllInvoice
{
    public sealed class GetAllInvoiceQueryHandler(
        IInvoiceRepository invoiceRepository) : IRequestHandler<GetAllInvoiceQuery, Result<List<Invoice>>>
    {
        public async Task<Result<List<Invoice>>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
        {
            List<Invoice> invoices = await invoiceRepository
                .Where(p => p.Type == InvoiceTypeEnum.FromValue(request.Type))
                .Include(p => p.Customer)
                .Include(p => p.InvoiceDetails!)
                .ThenInclude(p => p.Product)
                .Include(p => p.InvoiceDetails!)
                .ThenInclude(p => p.Depot)
                .OrderBy(p => p.Date)
                .ToListAsync(cancellationToken);

            return invoices;
        }
    }
}
