using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            using (RentalContext context = new RentalContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (RentalContext context = new RentalContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (RentalContext context = new RentalContext())
            {
                return context.Set<Category>().SingleOrDefault(filter);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (RentalContext context = new RentalContext())
            {
                return filter == null ? context.Set<Category>().ToList() : context.Set<Category>().Where(filter).ToList();
            }
        }

        public void Update(Category entity)
        {
            using (RentalContext context = new RentalContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
