using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Domain.Entities;
using WebSales.Domain.Models;

namespace WebSales.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Get(int id);
        public Task<List<User>> Get();
        public Task<User> Post(User user);
        public Task Put(User user);
        public Task Delete(User user);
        public Task<User> Login(LoginModel loginModel);
        public Task<bool> Any(int id);

    }
}
