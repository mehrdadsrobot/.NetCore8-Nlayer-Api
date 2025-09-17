using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Access;
using Models.UserModels;

namespace Repositories.UserRepository
{
    public class UserRepository<User> : BaseRepository<User>,IUserRepository<User> where User : class
    {
        private readonly TbotDbContext _context;

        public UserRepository(TbotDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


    }
}
