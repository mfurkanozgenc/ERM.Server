using MediatR;
using Server.Domain.Entities;
using TS.Result;

namespace Server.Application.Features.Invoices.GetAllInvoice
{
    public sealed record GetAllInvoiceQuery(int Type) : IRequest<Result<List<Invoice>>>;
}
