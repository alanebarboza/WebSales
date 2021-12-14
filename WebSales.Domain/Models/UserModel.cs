using System;
using WebSales.Shared.Enums;

namespace WebSales.Domain.Models
{
    public sealed class UserModel
    {
        public UserModel(int id, string userName, string passWord, string name, Gender gender, string phone, DateTime bornDate, string address, string email)
        {
            Id = id;
            UserName = userName;
            PassWord = passWord;
            Name = name;
            Gender = gender;
            Phone = phone;
            BornDate = bornDate;
            Address = address;
            Email = email;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public DateTime BornDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
