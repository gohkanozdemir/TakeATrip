using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("car.list")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ListedMessage);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), Messages.ListedMessage);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId), Messages.ListedMessage);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CategoryId == categoryId), Messages.ListedMessage);
        }

        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IDataResult<Car> Add(Car car)
        {
            if (car.CarName.Length <= 2)
            {
                return new ErrorDataResult<Car>(Messages.CarNameInvalid);
            }
            else if(car.DailyPrice <= 0)
            {
                return new ErrorDataResult<Car>(Messages.CarDailyPriceInvalid);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessDataResult<Car>(_carDal.GetLastAdded<int>(c=> c.Id), Messages.MakeMessage(car.CarName , Messages.AddedMessage));
            }            
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(), Messages.ListedMessage);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailsByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c=> c.CategoryId == categoryId), Messages.FetchedMessage);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.ColorId == colorId), Messages.FetchedMessage);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.BrandId == brandId), Messages.FetchedMessage);
        }

        [CacheAspect]
        public IDataResult<CarDetailDto> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(c => c.Id == carId), Messages.FetchedMessage);
        }



        [SecuredOperation("car.update,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.MakeMessage(car.CarName, Messages.UpdatedMessage));
        }

        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, Messages.MakeMessage(car.CarName, Messages.DeletedMessage));

        }

        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId), Messages.FetchedMessage);
        }

        public IDataResult<List<Car>> GetCarsByModelYear(int modelYear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ModelYear == modelYear), Messages.ListedMessage);
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal dailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice == dailyPrice), Messages.ListedMessage);
        }

        public IDataResult<List<Car>> GetCarsByCarName(string carName)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarName== carName), Messages.ListedMessage);
        }
    }
}
