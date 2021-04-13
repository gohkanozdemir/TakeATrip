using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddedMessage);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeletedMessage);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<List<RentalDetailDto>> GetCompanyDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<Rental> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId));
        }

        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult((Messages.UpdatedMessage));
        }

        public bool CarIsAvailable(Rental rental)
        {
            bool isAvaileable = true;
            if (rental != null && rental.ReturnDate == new DateTime(1900,01, 01,00,00,00))
            {
                isAvaileable = false;
            }
            return isAvaileable;
        }
    }
}
