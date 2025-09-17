using Microsoft.AspNetCore.Mvc;
using Models.UserModels;

namespace Repositories.UserRepository
{
    public interface IUserRepository<User> : IBaseRepository<User> where User : class
    {
       
    }
}
