using System;
using WebSales.Domain.Models;
using WebSales.Shared.Entities;
using WebSales.Shared.Enums;

namespace WebSales.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public User(int id, string userName, string passWord, string name, Gender gender, string phone, DateTime bornDate, string address, string email) : base(id)
        {
            UserName = userName;
            PassWord = passWord;
            Name = name;
            Gender = gender;
            Phone = phone;
            BornDate = bornDate;
            Address = address;
            Email = email;
        }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public string Phone { get; private set; }
        public DateTime BornDate { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }

        public void MergeProperties(User user, UserModel userModel)
        {
            user.Name = userModel.Name;
            user.Gender = userModel.Gender;
            user.Phone = userModel.Phone;
            user.BornDate = userModel.BornDate;
            user.Address = userModel.Address;
            user.Email = userModel.Email;
            user.UpdatedDate = DateTime.Now;
        }
    }
}
