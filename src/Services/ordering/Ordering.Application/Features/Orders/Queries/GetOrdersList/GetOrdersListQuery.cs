using MediatR;
using System;
using System.Collections.Generic;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<IEnumerable<OrdersVm>>
    {
        public string Username { get; set; }

        public GetOrdersListQuery(string username)
        {
            Username = username ?? throw new ArgumentException(nameof(username));
        }
    }
}
