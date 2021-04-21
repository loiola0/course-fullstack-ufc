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

        public async Task<UserResponse> SaveAsync(User user){
            try{
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }

            catch(Exception ex){
                return new UserResponse($"An error occurred when saving the user: {ex.Message}");
            }

        }

        public async Task<UserResponse> UpdateAsync(int id,User user){
            var existingUser = await _userRepository.FindByIdAsync(id);
            
            if(existingUser == null){
                return new UserResponse(existingUser);
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Cpf = user.Cpf;
            
            try{
                
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);


            }catch(Exception ex){
                return new UserResponse($"An error occurred when updating the user: ${ex.Message}");
            }

        }

         public async Task<UserResponse> DeleteAsync(int id){
            var existingUser = await _userRepository.FindByIdAsync(id);
            
            if(existingUser == null){
                return new UserResponse("User not found");
            }
            
            try{
                
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);


            }catch(Exception ex){
                return new UserResponse($"An error occurred when updating the user: ${ex.Message}");
            }

        }


        



    }
}