using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }
        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public void Add(Car car)
        {
            if (car.CarName.Length <= 2)
            {
                Console.WriteLine("Operation failed. The car name must be greater then 2 chcracters.");
                return;
            }
            else if(car.DailyPrice <= 0)
            {
                Console.WriteLine("Operation failed. The car daily price must be greater then 0.");
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Car added successfully.");
            }            
        }
    }
}
