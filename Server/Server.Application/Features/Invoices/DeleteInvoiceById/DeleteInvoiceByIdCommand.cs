using MediatR;
using TS.Result;

namespace Server.Application.Features.Invoices.DeleteInvoiceById
{
    public sealed record DeleteInvoiceByIdCommand (Guid Id) : IRequest<Result<string>>;
}
