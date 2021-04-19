using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class SaveCompanyResponse : BaseResponse
    {
        
        public Company Company {get;private set;}

        private SaveCompanyResponse(bool success,string message, Company _company) : base(success,message){
            Company = _company;
        }

        public SaveCompanyResponse(Company company) : this(true,string.Empty,company){}

        public SaveCompanyResponse(string message) : this(false,message,null){}



    }
}