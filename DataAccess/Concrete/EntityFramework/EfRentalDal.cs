using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id
                             join u in context.Users
                             on cus.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 CarName = c.CarName,
                                 CustomerName = u.FirstName + " " + u.LastName
                             };
                return result.ToList();

            }
        }
    }
}
