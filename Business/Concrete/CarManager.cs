using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ListedMessage);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), Messages.ListedMessage);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId), Messages.ListedMessage);
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.CarName.Length <= 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else if(car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
            else
            {
                _carDal.Add(car);
                return new Result(true, Messages.MakeMessage(car.CarName , Messages.AddedMessage));
            }            
        }

        
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ListedMessage);
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(carId), Messages.FetchedMessage);
        }

        [SecuredOperation("car.update,admin")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.MakeMessage(car.CarName, Messages.UpdatedMessage));
        }

        [SecuredOperation("car.delete,admin")]
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
