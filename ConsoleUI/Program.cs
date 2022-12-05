using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Program
    {

        static void Main(string[] args)
        {

            CustomerManager userManager = new CustomerManager(new EfCustomerDal());
            var result = userManager.GetAll();
            if (result.Success == true)
            {

                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.Id + "/" + user.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental newRentalforError = new Rental() { CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now };

            var resultSave = rentalManager.Add(newRentalforError);
            Console.WriteLine(resultSave.Message);
            /*  CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            foreach (var carDetail in result.Data)
            {
                Console.WriteLine("Car Name: {0}, Brand Name: {1}, Color Name: {2}, DailyPrice: {3}", carDetail.CarName, carDetail.BrandName, carDetail.ColorName, Convert.ToInt32(carDetail.DailyPrice));

            }*/

        }
        
    }
}
