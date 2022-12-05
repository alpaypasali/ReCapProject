using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public  class HashingHelper
    {

        public static void CreatePasswordHash(string password,out byte[] passswordHash,out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//key olusturduk
                passswordHash = hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(password));//password gelen veri hast edildi

            }


        }

        public static bool VerifyPasswordHash(string password,  byte[] passswordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passswordHash[i])
                    {
                        return false;


                    }
                }
            
            }
            return true;


        }
    }
}
