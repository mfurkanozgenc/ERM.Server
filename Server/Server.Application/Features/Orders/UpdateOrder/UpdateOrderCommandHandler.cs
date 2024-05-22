using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using TS.Result;

namespace Server.Application.Features.Orders.UpdateOrder
{
    internal sealed class UpdateOrderCommandHandler(
        IOrderRepository orderRepository,
        IOrderDetailRepository orderDetailRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<UpdateOrderCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order? order = await orderRepository.Where(o => o.Id == request.Id).Include(d => d.OrderDetails).FirstOrDefaultAsync();

            if(order is null)
            {
                return Result<string>.Failure("Sipariş Bulunamadı");
            }

            orderDetailRepository.DeleteRange(order.OrderDetails);

            List<OrderDetail> newDetails = request.OrderDetails.Select(s => new OrderDetail
            {
                OrderId = order.Id,
                Price = s.Price,
                Quantity = s.Quantity,
                ProductId = s.ProductId
            }).ToList();

            await orderDetailRepository.AddRangeAsync(newDetails,cancellationToken);

            mapper.Map(request, order);

            orderRepository.Update(order);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Sipariş Güncelleme Başarılı";

        }
    }
}
