using AutoMapper;
using Discount.API.Entitites;
using Discount.Grpc.Protos;

namespace Discount.API.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
            //CreateMap<Coupon, CreateDiscountRequset>().ReverseMap();
            //CreateMap<Coupon, UpdateDiscountRequset>().ReverseMap();
        }
    }
}
