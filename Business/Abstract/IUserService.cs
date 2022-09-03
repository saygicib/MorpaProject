using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetUserList();
        bool AddUser(AddUserDto dto);
        bool Login(UserLoginDto dto);
        bool IsThereUser(string email);
    }
}
