using System.Collections.Generic;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Services.Interfaces;
using WebSales.Domain.Entities;
using WebSales.Domain.Models;
using WebSales.Domain.Validators;
using WebSales.Domain.Repositories.Interfaces;
using WebSales.Shared.Extensions;

namespace WebSales.Application.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) => _userRepository = userRepository;
        public async Task<APIResult<ErrorResult, User>> Get(int id)
        {
            User user = await _userRepository.Get(id);
            if (user == null)
                return new ErrorResult(new List<string>() { "User invalid." });
            return await _userRepository.Get(id);
        }

        public async Task<APIResult<ErrorResult, List<User>>> Get()
        {
            return await _userRepository.Get();
        }
        public async Task<APIResult<ErrorResult, User>> Post(UserModel userModel)
        {
            var validationResult = ExecuteValidator(userModel);
            if (validationResult.Count > 0)
                return new ErrorResult(validationResult);

            userModel.PassWord = userModel.PassWord.StringEncode().ToString();
            User user = new(0, userModel.UserName, userModel.PassWord, userModel.Name, userModel.Gender, userModel.Phone, userModel.BornDate, userModel.Address, userModel.Email);

            return await _userRepository.Post(user);
        }

        public async Task<APIResult<ErrorResult, string>> Put(UserModel userModel)
        {
            var validationResult = ExecuteValidator(userModel);
            if (validationResult.Count > 0)
                return new ErrorResult(validationResult);

            User user = await _userRepository.Get(userModel.Id);
            if (user == null)
                return new ErrorResult(new List<string>() { "User invalid." });

            user.MergeProperties(user, userModel);
            await _userRepository.Put(user);
            return "User successfully updated.";
        }

        public async Task<APIResult<ErrorResult, string>> Delete(int id)
        {
            User user = await _userRepository.Get(id);
            if (user == null)
                return new ErrorResult(new List<string>() { "User invalid." });
            await _userRepository.Delete(user);
            return "User successfully removed.";

        }

        private static ICollection<string> ExecuteValidator(UserModel user)
        {
            UserValidator validator = new();
            return ValidatorResult<UserModel>.Validate(validator, user);
        }
    }
}
