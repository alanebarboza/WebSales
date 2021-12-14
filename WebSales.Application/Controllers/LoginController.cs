using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Services.Interfaces;
using WebSales.Domain.Models;

namespace WebSales.Application.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : APIResponse
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel loginModel) => CreateAPIResult(await _loginService.Login(loginModel));
        
    }
}
