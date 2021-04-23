using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarCategoryManager : ICarCategoryService
    {

        ICarCategoryDal _carCategoryDal;

        public CarCategoryManager(ICarCategoryDal carCategoryDal)
        {
            _carCategoryDal = carCategoryDal;
        }

        public IDataResult<List<CarCategory>> GetAll()
        {
            return new SuccessDataResult<List<CarCategory>>(_carCategoryDal.GetAll(), Messages.ListedMessage);
        }
    }
}
