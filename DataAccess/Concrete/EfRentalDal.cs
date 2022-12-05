using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,CarDbContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDbContext db = new CarDbContext())
            {

                var result = from r in db.Rentals
                             join ca in db.Cars on r.CarId equals ca.CarId
                             join b in db.Brands on ca.BrandId equals b.BrandID
                             join cu in db.Customers on r.CustomerId equals cu.Id
                             join u in db.Users on cu.UserId equals u.UserId
                             select new RentalDetailDto { Id = r.Id, BrandName = b.BrandName, CustomerFullName = u.FirstName + " " + u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return result.ToList();


            }
        }
    }
}
