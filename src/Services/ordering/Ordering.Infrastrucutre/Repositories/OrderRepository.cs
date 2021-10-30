using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastrucutre.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastrucutre.Repositories
{
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext):base(dbContext)
        {
        }

        public virtual async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
           return await _dbContext.Orders.Where(o => o.UserName == userName).ToListAsync();
        }
    }
}
