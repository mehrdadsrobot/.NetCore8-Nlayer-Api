using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Models.Claims;
using Models.UserModels;


namespace Services.JwtServices
{
    public interface IJwtServices
    {
        Task<string> GenerateAsync(Users user);

        IEnumerable<Role> getClaimsAsync();
    }
}
