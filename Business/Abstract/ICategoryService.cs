using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<List<Category>> GetCategoryByDoors(short doors);
        IDataResult<List<Category>> GetCategoryBySeats(short seats);
        IDataResult<List<Category>> GetCategoryByCategoryName(string categoryName);
    }
}
