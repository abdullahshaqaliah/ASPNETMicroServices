using AutoMapper;
using Discount.Grpc.Entitites;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository, ILogger<DiscountService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequset request, ServerCallContext context)
        {
            var coupon= await _repository.GetDiscount(request.ProductName);

            if (coupon == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with product name {request.ProductName} is not found."));

            _logger.LogInformation("Discount Is OK");
            return _mapper.Map<CouponModel>(coupon);

        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequset request, ServerCallContext context)
        {
            var coupon= await _repository.CreateDiscount(_mapper.Map<Coupon>(request.Coupon));

            _logger.LogInformation("Created");
            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequset request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _repository.UpdateDiscount(coupon);

            _logger.LogInformation("Updated");

            return request.Coupon;
        }

        public override async Task<DeleteRequestResponse> DeleteDiscount(DeleteDiscountRequset request, ServerCallContext context)
        {
            _logger.LogInformation("Deleted");

            return new DeleteRequestResponse() { Success= await _repository.DeleteDiscount(request.ProductName) };
        }

    }
}
