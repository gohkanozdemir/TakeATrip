using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserById(int userId);
        IDataResult<User> GetUserByName(string firstName);
        IDataResult<User> GetUserByFullName(string firstName, string lastName);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
