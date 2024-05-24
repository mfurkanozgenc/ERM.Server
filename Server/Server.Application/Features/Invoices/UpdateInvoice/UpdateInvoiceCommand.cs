using MediatR;
using Server.Domain.Dtos;
using TS.Result;

namespace Server.Application.Features.Invoices.UpdateInvoice
{
    public sealed record UpdateInvoiceCommand(
       Guid Id,
       Guid CustomerId,
       DateOnly Date,
       string InvoiceNumber,
       List<InvoiceDetailDto> InvoiceDetails,
       int TypeValue) : IRequest<Result<string>>;
}
