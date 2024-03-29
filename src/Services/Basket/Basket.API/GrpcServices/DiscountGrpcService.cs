﻿using Discount.Grpc.Protos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }


        public  async Task<CouponModel> GetDiscount(string productName)
        {

            return await _discountProtoService.GetDiscountAsync(new GetDiscountRequset() { ProductName= productName });

        }
    }
}
