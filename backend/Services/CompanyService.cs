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

        public async Task<CompanyResponse> SaveAsync(Company company){
            try{
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }

            catch(Exception ex){
                return new CompanyResponse($"An error occurred when saving the company: {ex.Message}");
            }

        }

        public async Task<CompanyResponse> UpdateAsync(int id,Company company){
            var existingCompany = await _companyRepository.FindByIdAsync(id);
            
            if(existingCompany == null){
                return new CompanyResponse(existingCompany);
            }

            existingCompany.CompanyName = company.CompanyName;
            existingCompany.FantasyName = company.FantasyName;
            existingCompany.Cnpj = company.Cnpj;
            existingCompany.Products = company.Products;
            
            try{
                
                _companyRepository.Update(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);


            }catch(Exception ex){
                return new CompanyResponse($"An error occurred when updating the company: ${ex.Message}");
            }

        }

         public async Task<CompanyResponse> DeleteAsync(int id){
            var existingCompany = await _companyRepository.FindByIdAsync(id);
            
            if(existingCompany == null){
                return new CompanyResponse("Company not found");
            }
            
            try{
                
                _companyRepository.Remove(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);


            }catch(Exception ex){
                return new CompanyResponse($"An error occurred when updating the company: ${ex.Message}");
            }

        }
        
    }
}