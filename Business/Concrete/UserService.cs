using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }
        public bool AddUser(AddUserDto dto)
        {
            if (IsThereUser(dto.Email))
                return false;

            User user = new User();
            user.Name = dto.Name;
            user.SurName = dto.SurName;
            user.Email = dto.Email;
            user.Password = textToEncrypt(dto.Password);
            user.CreatedDate = DateTime.Now;

            _userDal.Add(user);
            return true;
        }
        public static string textToEncrypt(string password)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public bool Login(UserLoginDto dto)
        {
            var user = _userDal.Get(x => x.Email == dto.Email && x.Password == textToEncrypt(dto.Password));
            if (user != null)
                return true;
            return false;
        }
        public bool IsThereUser(string email)
        {
            var user = _userDal.Get(x => x.Email == email);
            if (user != null)
                return true;
            return false;
        }
    }
}
