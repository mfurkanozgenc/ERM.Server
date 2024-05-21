using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Dtos;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Orders.UpdateOrder
{
    public sealed record UpdateOrderCommand(
        Guid OrderId,
        Guid CustomerId,
        DateTime Date,
        DateTime DeliveryDate,
        List<OrderDetailDto> OrderDetails) : IRequest<Result<string>>;


    internal sealed class UpdateOrderCommandHandler(
        IOrderRepository orderRepository,
        IOrderDetailRepository orderDetailRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateOrderCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order? order = await orderRepository.Where(o => o.Id == request.OrderId).Include(d => d.OrderDetails).FirstOrDefaultAsync();

            if(order is null)
            {
                return Result<string>.Failure("Sipariş Bulunamadı");
            }

            orderDetailRepository.DeleteRange(order.OrderDetails);

            mapper.Map(request, order);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Sipariş Güncellee Başarılı";

        }
    }
}
