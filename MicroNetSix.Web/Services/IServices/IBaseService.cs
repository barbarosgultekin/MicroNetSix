using MicroNetSix.Web.Models;

namespace MicroNetSix.Web.Services.IServices
{
    public interface IBaseService :IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
