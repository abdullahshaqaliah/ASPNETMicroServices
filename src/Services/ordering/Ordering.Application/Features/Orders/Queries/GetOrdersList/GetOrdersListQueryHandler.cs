using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
   public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, IEnumerable<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;


        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper )
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUserName(request.Username);
            return _mapper.Map<IEnumerable<OrdersVm>>(orders);
        }
    }
}
