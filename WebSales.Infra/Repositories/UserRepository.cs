using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Domain.Entities;
using WebSales.Domain.Models;
using WebSales.Infra.DBContext;
using WebSales.Domain.Repositories.Interfaces;

namespace WebSales.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLDbContext _sqlDbContext;
        public UserRepository(SQLDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }
        public async Task<User> Login(LoginModel loginModel)
        {
            return await _sqlDbContext.User.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == loginModel.UserName && x.PassWord == loginModel.PassWord);
        }

        public async Task<List<User>> Get() => await _sqlDbContext.User.AsNoTracking().ToListAsync();

        public async Task<User> Get(int id) => await _sqlDbContext.User.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        
        public async Task<User> Post(User user)
        {
            _sqlDbContext.User.Add(user);
            await _sqlDbContext.SaveChangesAsync();
            return user;
        }

        public async Task Put(User user)
        {
            _sqlDbContext.User.Update(user);
            await _sqlDbContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _sqlDbContext.User.Remove(user);
            await _sqlDbContext.SaveChangesAsync();
        }

        public async Task<bool> Any(int id) => await _sqlDbContext.User.AsNoTracking().AnyAsync(x => x.Id == id);

    }
}
