using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
            Console.WriteLine(category.CategoryName + " eklendi.");
        }

        public void Delete(Category category)
        {
            var categoryDelete = _categories.SingleOrDefault(c => c.Id == category.Id);
            _categories.Remove(categoryDelete);
            Console.WriteLine(category.CategoryName + " silindi.");
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
            Console.WriteLine(category.CategoryName + " guncellendi.");
        }

        private void CreateCategory()
        {
            _categories = new List<Category>
            {
                new Category{Id=1, CategoryName="Mini", Doors=2, Seats=4, Description="City trips, for one or two people"},
                new Category{Id=2, CategoryName="Mini", Doors=4, Seats=4, Description="City trips, for one or two people"},
                new Category{Id=3, CategoryName="Economy", Doors=2, Seats=4, Description="City and short trips"},
                new Category{Id=4, CategoryName="Economy", Doors=4, Seats=4, Description="City and short trips"},
                new Category{Id=5, CategoryName="Economy", Doors=4, Seats=5, Description="City and short trips"},
                new Category{Id=6, CategoryName="Compact", Doors=2, Seats=5, Description="City and mid-length trips"},
                new Category{Id=7, CategoryName="Compact", Doors=4, Seats=5, Description="City and mid-length trips"},
                new Category{Id=8, CategoryName="Compact Estate", Doors=4, Seats=5, Description="City and mid-length trips with extra luggage"},
                new Category{Id=9, CategoryName="Intermediate", Doors=4, Seats=5, Description="Mid-length to long trips"},
                new Category{Id=10, CategoryName="Intermediate Estate", Doors=4, Seats=5, Description="Mid-length to long trips with extra luggage"},
                new Category{Id=11, CategoryName="Standard", Doors=4, Seats=5, Description="Mid-length to long trips with extra comfort"},
                new Category{Id=12, CategoryName="Standard Estate", Doors=4, Seats=5, Description="Mid-length to long trips with extra comfort and luggage"},
                new Category{Id=13, CategoryName="Full-size", Doors=4, Seats=5, Description="Long trips, extra comfort and better performance"},
                new Category{Id=14, CategoryName="Full-size Estate", Doors=4, Seats=5, Description="Long trips with extra luggage"},
                new Category{Id=15, CategoryName="Luxury", Doors=4, Seats=5, Description="Travelling in style"},
                new Category{Id=16, CategoryName="Convertible", Doors=2, Seats=4, Description="Open-air driving experience"},
                new Category{Id=17, CategoryName="SUV", Doors=4, Seats=5, Description="Long trips and rural roads"},
                new Category{Id=18, CategoryName="People Carrier", Doors=4, Seats=7, Description="Groups and large families"}
            };
        }

        Category IEntityRepository<Category>.Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
