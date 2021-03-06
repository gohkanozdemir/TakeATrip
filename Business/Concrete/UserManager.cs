using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.MakeMessage(user.FirstName + " " + user.LastName, Messages.AddedMessage));
        }

        [SecuredOperation("user,admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.MakeMessage(user.FirstName + " " + user.LastName, Messages.DeletedMessage));
        }

        [SecuredOperation("admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter: u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.ListedMessage);
        }

        [SecuredOperation("user, admin")]
        public IDataResult<User> GetUserByFullName(string firstName, string lastName)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=> u.FirstName == firstName && u.LastName == lastName), Messages.FetchedMessage);
        }

        [SecuredOperation("admin")]
        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.FetchedMessage);
        }

        [SecuredOperation("admin")]
        public IDataResult<User> GetUserByName(string firstName)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.FirstName == firstName), Messages.FetchedMessage);
        }

        
        [SecuredOperation("admin")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.MakeMessage(user.FirstName + " " + user.LastName, Messages.UpdatedMessage));
        }
    }
}
