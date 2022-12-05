using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }//kullanici bilgisi
        public string Issuer { get; set; }//imzasi gibi
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
