using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Models;
using WebSales.Domain.Services.Interfaces;

namespace WebSales.Application.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : APIResponse
    {
        private readonly IUserService _userService;
        public UserController(IUserService userServices) => _userService = userServices;
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id) => CreateAPIResult(await _userService.Get(id));

        [HttpGet]
        [Authorize]
        public async Task<IActionResult>  Get() => CreateAPIResult(await _userService.Get());

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(UserModel userModel) => CreateAPIResult(await _userService.Post(userModel));

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(UserModel userModel) => CreateAPIResult(await _userService.Put(userModel));

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id) => CreateAPIResult(await _userService.Delete(id));
    }
}
