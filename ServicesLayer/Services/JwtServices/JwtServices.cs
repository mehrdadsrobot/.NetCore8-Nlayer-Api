using Models.Claims;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.JwtServices
{
    public class JwtServices : IJwtServices
    {
        public Task<string> GenerateAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> getClaimsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
