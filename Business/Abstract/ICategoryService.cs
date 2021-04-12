using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetCategoryByDoors(short doors);
        List<Category> GetCategoryBySeats(short seats);
        List<Category> GetCategoryByCategoryName(string categoryName);
    }
}
