using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(CarDbContext db=new CarDbContext())
            {

                var result = from c in db.Cars
                             join b in db.Brands
                             on c.BrandId equals b.BrandID
                             join p in db.Colors
                             on c.ColorId equals p.ColorID

                             select new CarDetailDto
                             {

                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = p.ColorName,
                                 DailyPrice = c.DailyPrice



                             };

                return result.ToList(); 


            }
        }
    }
}
