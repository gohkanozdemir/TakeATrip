using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {
        List<Category> _categories;
        public InMemoryCategoryDal()
        {
            CreateCategory();
        }
        public void Add(Category category)
        {
            _categories.Add(category);
            Console.WriteLine(category.CarCategoryId + " eklendi.");
        }

        public void Delete(Category category)
        {
            var categoryDelete = _categories.SingleOrDefault(c => c.Id == category.Id);
            _categories.Remove(categoryDelete);
            Console.WriteLine(category.CarCategoryId + " silindi.");
        }

        public List<Category> Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int categoryId)
        {
            return _categories.SingleOrDefault(c => c.Id == categoryId);
        }

        public void Update(Category category)
        {
            var categoryUpdate = _categories.SingleOrDefault(c => c.Id == category.Id);
            categoryUpdate.Description = category.Description;
            Console.WriteLine(category.CarCategoryId + " guncellendi.");
        }

        private void CreateCategory()
        {
            _categories = new List<Category>
            {
                new Category{Id=1, CarCategoryId=1, Doors=2, Seats=4, Description="City trips, for one or two people"},
                new Category{Id=2, CarCategoryId=1, Doors=4, Seats=4, Description="City trips, for one or two people"},
                new Category{Id=3, CarCategoryId=2, Doors=2, Seats=4, Description="City and short trips"},
                new Category{Id=4, CarCategoryId=2, Doors=4, Seats=4, Description="City and short trips"},
                new Category{Id=5, CarCategoryId=2, Doors=4, Seats=5, Description="City and short trips"},
                new Category{Id=6, CarCategoryId=3, Doors=2, Seats=5, Description="City and mid-length trips"},
                new Category{Id=7, CarCategoryId=3, Doors=4, Seats=5, Description="City and mid-length trips"},
                new Category{Id=8, CarCategoryId=3, Doors=4, Seats=5, Description="City and mid-length trips with extra luggage"},
                new Category{Id=9, CarCategoryId=3, Doors=4, Seats=5, Description="Mid-length to long trips"},
                new Category{Id=10, CarCategoryId=3, Doors=4, Seats=5, Description="Mid-length to long trips with extra luggage"},
                new Category{Id=11, CarCategoryId=3, Doors=4, Seats=5, Description="Mid-length to long trips with extra comfort"},
                new Category{Id=12, CarCategoryId=3, Doors=4, Seats=5, Description="Mid-length to long trips with extra comfort and luggage"},
                new Category{Id=13, CarCategoryId=3, Doors=4, Seats=5, Description="Long trips, extra comfort and better performance"},
                new Category{Id=14, CarCategoryId=3, Doors=4, Seats=5, Description="Long trips with extra luggage"},
                new Category{Id=15, CarCategoryId=5, Doors=4, Seats=5, Description="Travelling in style"},
                new Category{Id=16, CarCategoryId=5, Doors=2, Seats=4, Description="Open-air driving experience"},
                new Category{Id=17, CarCategoryId=5, Doors=4, Seats=5, Description="Long trips and rural roads"},
                new Category{Id=18, CarCategoryId=5, Doors=4, Seats=7, Description="Groups and large families"}
            };
        }

        Category IEntityRepository<Category>.Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
