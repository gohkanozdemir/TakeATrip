using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var categoryDelete = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            _categories.Remove(categoryDelete);
            Console.WriteLine(category.CategoryName + " silindi.");
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int categoryId)
        {
            return _categories.SingleOrDefault(c => c.CategoryId == categoryId);
        }

        public void Update(Category category)
        {
            var categoryUpdate = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            categoryUpdate.Description = category.Description;
            Console.WriteLine(category.CategoryName + " guncellendi.");
        }

        private void CreateCategory()
        {
            _categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Mini", Doors=2, Seats=4, Description="City trips, for one or two people"},
                new Category{CategoryId=2, CategoryName="Mini", Doors=4, Seats=4, Description="City trips, for one or two people"},
                new Category{CategoryId=3, CategoryName="Economy", Doors=2, Seats=4, Description="City and short trips"},
                new Category{CategoryId=4, CategoryName="Economy", Doors=4, Seats=4, Description="City and short trips"},
                new Category{CategoryId=5, CategoryName="Economy", Doors=4, Seats=5, Description="City and short trips"},
                new Category{CategoryId=6, CategoryName="Compact", Doors=2, Seats=5, Description="City and mid-length trips"},
                new Category{CategoryId=7, CategoryName="Compact", Doors=4, Seats=5, Description="City and mid-length trips"},
                new Category{CategoryId=8, CategoryName="Compact Estate", Doors=4, Seats=5, Description="City and mid-length trips with extra luggage"},
                new Category{CategoryId=9, CategoryName="Intermediate", Doors=4, Seats=5, Description="Mid-length to long trips"},
                new Category{CategoryId=10, CategoryName="Intermediate Estate", Doors=4, Seats=5, Description="Mid-length to long trips with extra luggage"},
                new Category{CategoryId=11, CategoryName="Standard", Doors=4, Seats=5, Description="Mid-length to long trips with extra comfort"},
                new Category{CategoryId=12, CategoryName="Standard Estate", Doors=4, Seats=5, Description="Mid-length to long trips with extra comfort and luggage"},
                new Category{CategoryId=13, CategoryName="Full-size", Doors=4, Seats=5, Description="Long trips, extra comfort and better performance"},
                new Category{CategoryId=14, CategoryName="Full-size Estate", Doors=4, Seats=5, Description="Long trips with extra luggage"},
                new Category{CategoryId=15, CategoryName="Luxury", Doors=4, Seats=5, Description="Travelling in style"},
                new Category{CategoryId=16, CategoryName="Convertible", Doors=2, Seats=4, Description="Open-air driving experience"},
                new Category{CategoryId=17, CategoryName="SUV", Doors=4, Seats=5, Description="Long trips and rural roads"},
                new Category{CategoryId=18, CategoryName="People Carrier", Doors=4, Seats=7, Description="Groups and large families"}
            };
        }
    }
}
