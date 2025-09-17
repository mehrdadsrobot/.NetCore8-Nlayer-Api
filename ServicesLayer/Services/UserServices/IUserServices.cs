using Microsoft.AspNetCore.Mvc;
using Models.UserModels;
using ServicesLayer.Services.ResponseType;

namespace Services.UserServices
{
    public interface IUserServices
    {
        public Task<ServiceResponse<string>> Login (Users user);

        public Task<ServiceResponse<Users>> Create (Users user);

        public Task<ServiceResponse<Users>> Update (int  id, Users user);

        public Task<ServiceResponse<Users>> Delete (int id);

        public Task<ServiceResponse<Users>> Get (int id);

        public Task<IEnumerable<Users>> GetAll();
        

    }
}
