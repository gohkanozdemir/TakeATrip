using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageMenager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageMenager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[SecuredOperation("image.add,admin")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            // en fazla 5 resim yukleyebilir
            var resultBussines = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            if (resultBussines != null)
            {
                return resultBussines;
            }


            var resultUpload = FileHelper.Upload(file, FileConstants.FileImageExtensions, FileConstants.RescourceFolderName, FileConstants.ImageFolderName);
            if (!resultUpload.Item1.Success)
            {
                return resultUpload.Item1;
            }


            carImage.ImagePath = resultUpload.dbPath;
            carImage.CreateDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new Result(true, Messages.AddedMessage);
        }

        [SecuredOperation("image.delete,admin")]
        public IResult Delete(IFormFile file, CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new Result(true, Messages.DeletedMessage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ListedMessage);
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                result.Add(new CarImage { ImagePath = FileConstants.DefaultImagePath });
            }
            return new SuccessDataResult<List<CarImage>>(result, Messages.ListedMessage);
        }

        public IDataResult<CarImage> Get(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carId), Messages.FetchedMessage);
        }

        [SecuredOperation("image.update,admin")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new Result(true, Messages.UpdatedMessage);
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (result >=5)
            {
                return new ErrorResult(Messages.CarImageLimitedExceded);
            }
            return new SuccessResult();
        }
    }
}
