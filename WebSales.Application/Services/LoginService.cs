using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Application.Authentication;
using WebSales.Shared.Response;
using WebSales.Domain.Services.Interfaces;
using WebSales.Domain.Entities;
using WebSales.Domain.Models;
using WebSales.Domain.Validators;
using WebSales.Domain.Repositories.Interfaces;
using WebSales.Shared.Extensions;

namespace WebSales.Application.Services
{
    public sealed class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<APIResult<ErrorResult, string>> Login(LoginModel loginModel)
        {
            var validationResult = ExecuteValidator(loginModel);
            if (validationResult.Count > 0)
                return new ErrorResult(validationResult);

            loginModel.PassWord = loginModel.PassWord.StringEncode();

            User user = await _userRepository.Login(loginModel);
            if (user != null && user.Id > 0)
                return TokenService.CreateToken(loginModel);
            else
                return "User or PassWord is invalid.";
        }

        private static ICollection<string> ExecuteValidator(LoginModel loginModel)
        {
            LoginValidator validator = new();
            return ValidatorResult<LoginModel>.Validate(validator, loginModel);
        }
    }
}
