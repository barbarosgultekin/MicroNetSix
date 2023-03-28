using MicroNetSix.Services.IdentityAPI.Models;

namespace MicroNetSix.Services.IdentityAPI.Services
{
    public interface IIdentityService
    {
        Task<LoginResponseModel> Login(LoginRequestModel requestModel);
    }
}
