using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetailsById(Expression<Func<Car, bool>> filter = null);
    }
}
