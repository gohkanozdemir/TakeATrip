﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

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

        public IDataResult<List<Category>> GetCategoryByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c=> c.Id == categoryId), Messages.ListedMessage);
        }
    }
}
