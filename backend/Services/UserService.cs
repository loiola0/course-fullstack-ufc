using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services;
using backend.Domains.Services.Communication;
using backend.Domains.Repositories;

namespace backend.Services
{
    public class UserService : IUserService
    {

        public readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository,IUnitOfWork unitOfWork){
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> ListAsync(){
            return await _userRepository.ListAsync();
        }

        public async Task<SaveUserResponse> SaveAsync(User user){
            try{
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new SaveUserResponse(user);
            }

            catch(Exception ex){
                return new SaveUserResponse($"An error occurred when saving the company: {ex.Message}");
            }

        }

    }
}