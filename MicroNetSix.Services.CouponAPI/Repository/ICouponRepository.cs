using MicroNetSix.Services.CouponAPI.Models.Dto;

namespace MicroNetSix.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}