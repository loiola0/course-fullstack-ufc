using System;
using AutoMapper;
using backend.Domains.Models;
using backend.Resources;

namespace backend.Mapping
{
    public class ModelToResourceProfile : Profile
    {

        public ModelToResourceProfile()
        {
            CreateMap<Company,CompanyResource>();
            CreateMap<Product,ProductResource>();
            CreateMap<Purchase,PurchaseResource>();
            CreateMap<User,UserResource>();
            
        }


    }
}