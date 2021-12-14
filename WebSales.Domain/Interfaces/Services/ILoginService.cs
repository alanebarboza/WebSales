using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Models;

namespace WebSales.Domain.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<APIResult<ErrorResult, string>> Login(LoginModel loginModel);
    }
}
