using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Entities;
using WebSales.Domain.Models;

namespace WebSales.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public Task<APIResult<ErrorResult, User>> Get(int id);
        public Task<APIResult<ErrorResult, List<User>>> Get();
        public Task<APIResult<ErrorResult, User>> Post(UserModel userModel);
        public Task<APIResult<ErrorResult, string>> Put(UserModel saleMuserModelodel);
        public Task<APIResult<ErrorResult, string>> Delete(int id);
    }
}
