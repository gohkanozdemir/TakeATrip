using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarFeatureManager : ICarFeatureService
    {

        ICarFeatureDal _carFeatureDal;

        public CarFeatureManager(ICarFeatureDal carFeatureDal)
        {
            _carFeatureDal = carFeatureDal;
        }

        public IDataResult<List<CarFeature>> GetAll()
        {
            return new SuccessDataResult<List<CarFeature>>(_carFeatureDal.GetAll(), Messages.ListedMessage);
        }
        public IDataResult<List<CarFeature>> GetCarFeatureByDoors(short doors)
        {
            return new SuccessDataResult<List<CarFeature>>(_carFeatureDal.GetAll(c => c.Doors == doors), Messages.ListedMessage);
        }

        public IDataResult<List<CarFeature>> GetCarFeatureBySeats(short seats)
        {
            return new SuccessDataResult<List<CarFeature>>(_carFeatureDal.GetAll(c => c.Seats == seats), Messages.ListedMessage);
        }
    }
}
