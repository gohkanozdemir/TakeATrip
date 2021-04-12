using Business.Abstract;
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

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetCategoryByCategoryName(string categoryName)
        {
            return _categoryDal.GetAll(c=> c.CategoryName == categoryName);
        }

        public List<Category> GetCategoryByDoors(short doors)
        {
            return _categoryDal.GetAll(c => c.Doors == doors);
        }

        public List<Category> GetCategoryBySeats(short seats)
        {
            return _categoryDal.GetAll(c => c.Seats == seats);
        }
    }
}
