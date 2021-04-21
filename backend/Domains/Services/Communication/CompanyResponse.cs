using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class CompanyResponse : BaseResponse
    {
        
        public Company Company {get;private set;}

        private CompanyResponse(bool success,string message, Company _company) : base(success,message){
            Company = _company;
        }

        public CompanyResponse(Company company) : this(true,string.Empty,company){}

        public CompanyResponse(string message) : this(false,message,null){}



    }
}