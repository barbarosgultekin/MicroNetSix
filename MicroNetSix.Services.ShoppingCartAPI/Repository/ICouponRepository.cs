using MicroNetSix.Services.ShoppingCartAPI.Models.Dto;

namespace MicroNetSix.Services.ShoppingCartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
