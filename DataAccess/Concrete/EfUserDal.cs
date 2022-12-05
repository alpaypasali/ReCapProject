using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal:EfEntityRepositoryBase<User,CarDbContext>,IUserDal
    {

        public List<OperationClaim> GetClaims(User user)
        {
            using(var context = new CarDbContext())
            {

                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.Id
                             where UserOperationClaim.UserId == user.UserId 
                             select new OperationClaim { Id = UserOperationClaim.Id  ,Name = OperationClaim.Name};

                return result.ToList();


            }


        }
        
    }
}
