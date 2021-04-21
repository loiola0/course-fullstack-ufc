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

        public async Task<ProductResponse> SaveAsync(Product product){
            try{
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(product);
            }

            catch(Exception ex){
                return new ProductResponse($"An error occurred when saving the product: {ex.Message}");
            }

        }

        public async Task<ProductResponse> UpdateAsync(int id,Product product){
            var existingProduct = await _productRepository.FindByIdAsync(id);
            
            if(existingProduct == null){
                return new ProductResponse(existingProduct);
            }

            existingProduct.Name = product.Name;
            existingProduct.Value = product.Value;
            existingProduct.Note = product.Note;
            existingProduct.Description = product.Description;
           
            
            try{
                
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);


            }catch(Exception ex){
                return new ProductResponse($"An error occurred when updating the product: ${ex.Message}");
            }

        }

        public async Task<ProductResponse> DeleteAsync(int id){
            var existingProduct = await _productRepository.FindByIdAsync(id);
            
            if(existingProduct == null){
                return new ProductResponse("Product not found");
            }
            
            try{
                
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);


            }catch(Exception ex){
                return new ProductResponse($"An error occurred when updating the product: ${ex.Message}");
            }

        }

    }
}