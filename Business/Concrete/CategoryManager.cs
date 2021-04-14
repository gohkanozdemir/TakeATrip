using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.ListedMessage); 
        }

        public IDataResult<List<Category>> GetCategoryByCategoryName(string categoryName)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c=> c.CategoryName == categoryName), Messages.ListedMessage);
        }

        public IDataResult<List<Category>> GetCategoryByDoors(short doors)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c => c.Doors == doors), Messages.ListedMessage);
        }

        public IDataResult<List<Category>> GetCategoryBySeats(short seats)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c => c.Seats == seats), Messages.ListedMessage);
        }
    }
}
