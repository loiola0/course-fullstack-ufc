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

        public async Task<SavePurchaseResponse> SaveAsync(Purchase purchase){
            try{
                await _purchaseRepository.AddAsync(purchase);
                await _unitOfWork.CompleteAsync();

                return new SavePurchaseResponse(purchase);
            }

            catch(Exception ex){
                return new SavePurchaseResponse($"An error occurred when saving the company: {ex.Message}");
            }

        }

        public async Task<SavePurchaseResponse> UpdateAsync(int id,Purchase purchase){
            var existingPurchase = await _purchaseRepository.FindByIdAsync(id);
            
            if(existingPurchase == null){
                return new SavePurchaseResponse(existingPurchase);
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

                return new SavePurchaseResponse(existingPurchase);


            }catch(Exception ex){
                return new SavePurchaseResponse($"An error occurred when updating the company: ${ex.Message}");
            }

        }

    }
}