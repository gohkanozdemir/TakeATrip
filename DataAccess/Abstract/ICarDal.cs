using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetails();
        List<CarDetailDto> GetCarsDetailsByCategoryId(int categoryId);
        List<CarDetailDto> GetCarsDetailsByColorId(int colorId);
        List<CarDetailDto> GetCarsDetailsByBrandId(int brandId);
        CarDetailDto GetCarDetailsById(int carId);
    }
}
