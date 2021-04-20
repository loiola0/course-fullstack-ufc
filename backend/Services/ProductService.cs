using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services;
using backend.Domains.Services.Communication;
using backend.Domains.Repositories;

namespace backend.Services
{
    public class ProductService : IProductService
    {

        public readonly IProductRepository _productRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,IUnitOfWork unitOfWork){
            _productRepository =  productRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<Product>> ListAsync(){
            return await _productRepository.ListAsync();
        }

        public async Task<SaveProductResponse> SaveAsync(Product product){
            try{
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new SaveProductResponse(product);
            }

            catch(Exception ex){
                return new SaveProductResponse($"An error occurred when saving the company: {ex.Message}");
            }

        }

    }
}