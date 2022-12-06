using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static  string AccessTokenCreated = "Access Token Created";
        public static string UserRegistered = "User Registered";
        public static  string UserAlreadyExists = "User Already Exists";
        public static  string SuccesfulLogin = "Succesfull Login";
        public static string  UserNotFound = "User Not Found";


        public static string CarAdded = "Car Added Successfully";
        public static string CarAddError = "Car Not Added";
        
        
        
        public static string CustomerAdded = "Customer Added Successfully";
       
        
        
        public static string RentalListed = "Rental Listed";
        public static string RentalAdded = "Rental kaydı eklendi, araç kiralandı.";
        public static string RentalDeleted = "Rental silindi.";
        public static string RentalUpdated = "Rental güncellendi.";


        //public static string ReturnDateCannotBeNull = "Teslim tarihi mutlaka olmalıdır.";
        //public static string RentalDayLessThanZero = "Kiralanacak arabanın teslim ve alım tarihi sıfırdan büyük olmalıdır.";
        public static string RentalCarNotAvailable = "Kiralanacak araba daha teslim edilmemiş.";
        public static string FailedRentalDelete = "Teslim edilmemiş araç için kayıt silinemez.";
        public static string PasswordError = "Password Wrong";


        public static string AuthorizationDenied = "You don't have authorized ";
    }
}
