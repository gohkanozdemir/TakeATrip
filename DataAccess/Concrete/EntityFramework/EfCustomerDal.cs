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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();

            }
        }
    }
}
