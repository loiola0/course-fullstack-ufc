using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services;
using backend.Domains.Services.Communication;
using backend.Domains.Repositories;

namespace backend.Services
{
    public class CompanyService : ICompanyService
    {

        public readonly ICompanyRepository _companyRepository;
        public readonly IUnitOfWork _unitOfWork;


        public CompanyService(ICompanyRepository companyRepository,IUnitOfWork unitOfWork){
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Company>> ListAsync(){
            return await _companyRepository.ListAsync();
        }

        public async Task<SaveCompanyResponse> SaveAsync(Company company){
            try{
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();

                return new SaveCompanyResponse(company);
            }

            catch(Exception ex){
                return new SaveCompanyResponse($"An error occurred when saving the company: {ex.Message}");
            }

        }
        
    }
}