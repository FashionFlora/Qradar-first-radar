using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Generic;

namespace LogicLyric.MVM.Model
{
    public interface IUserRepository
    {

        string  AuthenticateUser(NetworkCredential credential);
        bool AuthenticateUserTimeOut(NetworkCredential credential);



        void AuthenticateUserLoginTime(NetworkCredential credential);

        void Add(UserModel userModel);
        void Edit(UserModel userModel);
       
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetByAll();
    }
}
