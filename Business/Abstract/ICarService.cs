using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByCategoryId(int categoryId);
        IDataResult<List<Car>> GetCarsByModelYear(int modelYear);
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal dailyPrice);
        IDataResult<List<Car>> GetCarsByCarName(string carName);
        IDataResult<Car> GetCarById(int carId);
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IDataResult<List<CarDetailDto>> GetCarsDetailsByCategoryId(int categoryId);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId);
        IDataResult<CarDetailDto> GetCarDetailsById(int carId);
        IDataResult<Car> Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
