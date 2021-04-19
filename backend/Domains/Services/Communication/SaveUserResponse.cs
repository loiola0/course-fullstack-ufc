using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class SaveUserResponse : BaseResponse
    {
        
        public User User {get;private set;}

        private SaveUserResponse(bool success,string message, User _user) : base(success,message){
            User = _user;
        }

        public SaveUserResponse(User user) : this(true,string.Empty,user){}

        public SaveUserResponse(string message) : this(false,message,null){}



    }
}