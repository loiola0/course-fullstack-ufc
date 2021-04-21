using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains.Models;
using backend.Domains.Services;
using backend.Domains.Services.Communication;
using backend.Domains.Repositories;

namespace backend.Services
{
    public class PurchaseService : IPurchaseService
    {

        public readonly IPurchaseRepository _purchaseRepository;
        public readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IPurchaseRepository purchaseRepository,IUnitOfWork unitOfWork){
            _purchaseRepository = purchaseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Purchase>> ListAsync(){
            return await _purchaseRepository.ListAsync();
        }

        public async Task<PurchaseResponse> SaveAsync(Purchase purchase){
            try{
                await _purchaseRepository.AddAsync(purchase);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(purchase);
            }

            catch(Exception ex){
                return new PurchaseResponse($"An error occurred when saving the purchase: {ex.Message}");
            }

        }

        public async Task<PurchaseResponse> UpdateAsync(int id,Purchase purchase){
            var existingPurchase = await _purchaseRepository.FindByIdAsync(id);
            
            if(existingPurchase == null){
                return new PurchaseResponse(existingPurchase);
            }

            existingPurchase.Note = purchase.Note;
            existingPurchase.Value = purchase.Value;
            existingPurchase.PaymentFormat = purchase.PaymentFormat;
            existingPurchase.Status = purchase.Status;
            existingPurchase.Cep = purchase.Cep;
            existingPurchase.Address = purchase.Address;
            existingPurchase.Date = purchase.Date;
            
            

            
            try{
                
                _purchaseRepository.Update(existingPurchase);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(existingPurchase);


            }catch(Exception ex){
                return new PurchaseResponse($"An error occurred when updating the purchase: ${ex.Message}");
            }

        }

         public async Task<PurchaseResponse> DeleteAsync(int id){
            var existingPurchase = await _purchaseRepository.FindByIdAsync(id);
            
            if(existingPurchase == null){
                return new PurchaseResponse("Purchase not found");
            }
            
            try{
                
                _purchaseRepository.Remove(existingPurchase);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(existingPurchase);


            }catch(Exception ex){
                return new PurchaseResponse($"An error occurred when updating the purchase: ${ex.Message}");
            }

        }

    }
}