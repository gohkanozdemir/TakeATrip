using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByModelYear(int modelYear);
        List<Car> GetCarsByDailyPrice(decimal dailyPrice);
        List<Car> GetCarsByCarName(string carName);
        Car GetCarById(int carId);
        //Car GetCarByName(string carName);
        List<CarDetailDto> GetCarDetails();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
