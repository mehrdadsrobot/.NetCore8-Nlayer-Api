using AutoMapper;
using Common.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.UserModels;
using Repositories.UserRepository;
using Services.JwtServices;
using ServicesLayer.Services.ResponseType;

namespace Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository<Users> _IUserRepository;
        private readonly IJwtServices _jwtServices;
        //private readonly IMapper _mapper;
        public UserServices(IUserRepository<Users> IUserRepository,
                             IJwtServices jwtServices /*IMapper mapper*/) 
        {
            _IUserRepository = IUserRepository;
            _jwtServices = jwtServices;
            //_mapper = mapper;
        }

        public async Task<ServiceResponse<Users>> Create(Users userDto)
        {

            await _IUserRepository.AddAsync(userDto);
            await _IUserRepository.SaveChangesAsync();

            return new ServiceResponse<Users> { Success = true , Message = $"User {userDto.UserName} Created", Data = null};
        }

        public async Task<ServiceResponse<Users>> Get(int id)
        {
            var response = await _IUserRepository.GetByIdAsync(id);

            return new ServiceResponse<Users>{ Success = true , Message = null , Data = response};
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            var response = await _IUserRepository.GetAllAsync();

            return response;
        } 
        public async Task<ServiceResponse<Users>> Update(int id, Users userDto)
        {
            var response = await _IUserRepository.GetByIdAsync(id);

            if (response == null)
            {
                return new ServiceResponse<Users> { Success = false, Data = null, Message = "User not found !!" };
            }

            else
            {
                //_mapper.Map(userDto, response);
                _IUserRepository.Update(response);
                await _IUserRepository.SaveChangesAsync();
                return new ServiceResponse<Users> { Success = true, Data = response, Message = $"User {response.UserName} Updated." };

            }

        }

        public async Task<ServiceResponse<Users>> Delete(int id)
        {
            var response = await _IUserRepository.GetByIdAsync(id);

            if (response == null)
            {
                return new ServiceResponse<Users> { Success = false , Data = null , Message = "User not found !!" };
            }

            else
            {
                _IUserRepository.Delete(response);
                await _IUserRepository.SaveChangesAsync();
                return new ServiceResponse<Users> { Success = true, Data = response, Message = $"User {response.UserName} Deleted." };
            }
        }

        public async Task<ServiceResponse<string>> Login(Users user)
        {
            var resp = await _IUserRepository.GetByIdAsync(user.Id);

            var passHash = PasswordUtils.Hash(user.Password);

            if(user == null)
            {
                return new ServiceResponse<string> { Success = false,Data = null , Message = "user not found" };
            }

            else if (passHash != resp.Password)
            {
                return new ServiceResponse<string> { Success = false, Data = null, Message = "Wrong Password" };
            }

            var token = await _jwtServices.GenerateAsync(user);

            return new ServiceResponse<string> { Success = true, Data = token };
        }

    }
}
