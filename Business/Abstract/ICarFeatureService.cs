using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarFeatureService
    {
        IDataResult<List<CarFeature>> GetAll();
        IDataResult<List<CarFeature>> GetCarFeatureByDoors(short doors);
        IDataResult<List<CarFeature>> GetCarFeatureBySeats(short seats);
    }
}
