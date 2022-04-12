using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MovieStore.WebAPI.Authentication
{
    public class JwtAuthenticationManager : IJWTAuthenticationManager
    {
     
        private readonly string _key;
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }


        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"user1", "123" },
            {"user2", "456" }
        };


        public string Authenticate(string username, string password)
        {
            //token ı handle edecek kısım
            //bir kullanıcı var mı ? Kontrol et

            if(!users.Any(x => x.Key == username && x.Value == password))
            {
                return null;
            }

            //1 tane token ı handle edecek nesne lazım
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            //handler ımızın token oluştururken ihtiyacı olacağın parametreler
            var tokenDescriptor = new SecurityTokenDescriptor // token ı ayarlayacak olan açıklama parametrem
            {
                Subject = new ClaimsIdentity (new Claim [] // açıklama parametremin ana konusu bu kullanıcı ile ilgili ayarlanacak olan Claim ler ile ilgilidir.
                {
                    new Claim (ClaimTypes.Name, username)

                }),
                Expires = DateTime.UtcNow.AddHours(1), //token ömrü
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey) , SecurityAlgorithms.HmacSha256Signature),

            };

            //token bir yere atılsın
            var token  = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            throw new System.NotImplementedException();
        }
    }
}
