using MediatR;
using Server.Domain.Dtos;
using TS.Result;

namespace Server.Application.Features.Invoices.CreateInvoice
{
    public sealed record CreateInvoiceCommand(
       Guid CustomerId,
       DateOnly Date,
       string InvoiceNumber,
       List<InvoiceDetailDto> InvoiceDetails,
       Guid? OrderId,
       int TypeValue) : IRequest<Result<string>>;
}
