using Discount.API.Entitites;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [Route("api/v/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase, IDiscountRepository
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            return await _repository.CreateDiscount(coupon);
        }


        [HttpDelete("{productName}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

        public async Task<bool> DeleteDiscount(string productName)
        {
            return await _repository.DeleteDiscount(productName);
        }


        [Route("[action]/{productName}")]
        [HttpGet]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<Coupon> GetDiscount(string productName)
        {
            return await _repository.GetDiscount(productName);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            return await _repository.UpdateDiscount(coupon);
        }
    }
}
